using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace Server
{
    public class ServerObject
    {
        static TcpListener tcpListener; // сервер для прослушивания
        public List<ClientObject> clients { get; private set; } = new List<ClientObject>(); // все подключения
        

        //Logs
        static internal StreamWriter log;
        //DateTime.Today.TimeOfDay + "\n" +

        public ServerObject() { }

        int port = 8888;
        public ServerObject(Stream sw) //for logs
        {
            log = new StreamWriter(sw,Encoding.Default);
        }

        protected internal void AddConnection(ClientObject clientObject)
        {
            clients.Add(clientObject);
        }
        protected internal void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }
        // прослушивание входящих подключений
        protected internal void Listen()
        {
            try
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                if (log != null)
                {
                    log.WriteLineAsync(DateTime.Now.TimeOfDay + "\n" + "Сервер запущен. Ожидание подключений...");
                    log.FlushAsync();
                }
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();
                    ClientObject clientObject;
                    if (log!=null)
                    clientObject = new ClientObject(tcpClient, this, log);
                    else clientObject = new ClientObject(tcpClient, this);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                    Thread infoDistrib = new Thread(new ThreadStart(InfoDistrib));
                    infoDistrib.Start();
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                if (log != null)
                {
                    log.WriteLine(ex.Message);
                    log.Flush();
                }

            }
        }

        protected internal async void InfoDistrib()
        {
            try
            {
                while (true) {
                    byte[] data = Encoding.Unicode.GetBytes("/o;" + clients.Count);
                    Task.WaitAll();
                    for (int i = 0; i < clients.Count; i++)
                    {
                        await clients[i].Stream.WriteAsync(data, 0, data.Length); //передача данных
                    }
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                if (log != null)
                {
                    log.WriteLine(ex.Message);
                    log.Flush();
                }
            }
        }

        protected internal void PingBack(string signal, ClientObject client)
        {
            byte[] data = Encoding.Unicode.GetBytes("/" + signal);
            Task.WaitAll();
            client.Stream.Write(data, 0, data.Length);
        }

        protected internal void PingBack(string signal, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes("/" + signal);
            Task.WaitAll();
            clients.Where(i => i.Id == id).First().Stream.Write(data, 0, data.Length);
        }

        protected internal void MessageTo(string message, ClientObject client)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Stream.Write(data, 0, data.Length);
        }

        protected internal void MessageTo(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            clients.Where(i=>i.Id == id).First().Stream.Write(data, 0, data.Length);
        }

        protected internal void StartFight(ClientObject first, ClientObject second)
        {
            //пересылаем данные друг о друге и начинаем бой
            byte[] data = Encoding.Unicode.GetBytes("/f;" + second.getStat);
            first.Stream.Write(data, 0, data.Length);
            data = Encoding.Unicode.GetBytes("/f;" + first.getStat);
            second.Stream.Write(data, 0, data.Length);
        }

        // трансляция сообщения подключенным клиентам
        protected internal void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].Id != id && !clients[i].isException) // если id клиента не равно id отправляющего
                {
                    clients[i].Stream.Write(data, 0, data.Length); //передача данных
                }
            }
        }
        // отключение всех клиентов
        protected internal void Disconnect()
        {
            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }

            if(log != null)
            log.WriteLine("server down");
            Environment.Exit(0); //завершение процесса
        }
    }
}