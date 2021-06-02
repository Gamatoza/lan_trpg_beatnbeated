using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream Stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server; // объект сервера

        //Logs
        StreamWriter log;
        //DateTime.Today.TimeOfDay + "\n" +

        //GameExp
        //public string opponent { get; private set; }
        public int hp { get; private set; } = 100;
        public int atk { get; private set; } = 10;
        public ClientObject opponent { get; private set; }
        Random rand = new Random();

        public string getStat {
            get{
                return userName + ";" + hp + ";" + atk;
            } }
        public bool isException { get; private set; }//false //isOnFight && isOnWaiting


        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public ClientObject(TcpClient tcpClient, ServerObject serverObject, StreamWriter logWriter)
        {
            Id = Guid.NewGuid().ToString();
            client = tcpClient;
            server = serverObject;
            serverObject.AddConnection(this);
            log = logWriter;
        }

        public void Process()
        {
            try
            {
                Stream = client.GetStream(); //!!!!!!!!!!!!
                // получаем имя пользователя
                string message = GetMessage();
                userName = message;

                message = userName + " enter the game";
                // посылаем сообщение о входе в чат всем подключенным пользователям
                server.BroadcastMessage(message, this.Id);
                if(log != null)
                log.WriteLine(DateTime.Now.TimeOfDay + "\n" + message);
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        if(message[0] == '/')
                        {
                            /*Ping list:
                             p - in peace
                             b - in battle
                             u - update stats
                             f - fight pvp
                             l - leave fights
                             */

                            if (message[1] == 'u') //update stats
                            {
                                string[] parts = message.Split(';');
                                hp = int.Parse(parts[1]);
                                atk = int.Parse(parts[2]);
                            }

                            if (isException)
                            {
                                if (message[1] == 'q')
                                {
                                    if(opponent != null)
                                    server.PingBack("q;" + this.hp, opponent);
                                }

                                if (message[1] == 'a') //attack
                                {
                                    if (opponent != null)
                                    server.PingBack("a;" + this.atk, opponent);
                                }
                                else if(message[1] == 'l') //leave
                                {
                                    if (opponent != null)
                                    {
                                        server.PingBack("l;", opponent);
                                        opponent.isException = false;
                                    }
                                    isException = false;
                                    opponent = null;
                                }
                            }

                            else
                            if (message[1] == 'p') //peace
                            {
                                isException = false;
                            }
                            else if(message[1] == 'b') //battle
                            {
                                isException = true;
                            }
                            else if(message[1] == 'f') //fight pvp
                            {
                                if(server.clients.Count >= 2) //Здесь можно добавить логику распределения по хп атаке тд тп, но пока пох
                                {
                                    List<ClientObject> buf = new List<ClientObject>();
                                    //делаем копию массива id клиентов         
                                    for (int i = 0; i < server.clients.Count; i++)
                                    {
                                        if(server.clients[i].Id != this.Id && !server.clients[i].isException)
                                        {
                                            buf.Add(server.clients[i]);
                                        }
                                    }
                                    if (buf.Count >= 0)
                                    {
                                        //рандомно выбираем оппонента 
                                        opponent = buf[rand.Next(buf.Count)];
                                        isException = true;
                                        opponent.isException = true;
                                        server.StartFight(this, opponent);
                                    }
                                    else server.PingBack("n;", this); //not accepted
                                }
                                else 
                                {
                                    server.PingBack("n;", this); //not accepted
                                }
                            }
                        }
                        else
                        if (!String.IsNullOrEmpty(message))
                        {
                            message = String.Format("{0}: {1}", userName, message);
                            if(log != null)
                            log.WriteLineAsync(DateTime.Now.TimeOfDay + "\n" + message);
                            if (isException && opponent != null)
                            {
                                server.MessageTo(message, opponent);
                            }
                            else server.BroadcastMessage(message, this.Id);
                            if (log != null)
                                log.FlushAsync();
                        }
                    }
                    catch
                    {
                        message = String.Format("{0}: left the game", userName);
                        server.BroadcastMessage(message, this.Id);
                        if (log != null)
                        {
                            log.WriteLineAsync(DateTime.Now.TimeOfDay + "\n" + message);
                            log.FlushAsync();
                        }
                        break;
                    }
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
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        // чтение входящего сообщения и преобразование в строку
        private string GetMessage() //TODO: Добавить проверку по ключу, а то взламывать начнут, хехе
        {
            byte[] data = new byte[64]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            }
            while (Stream.DataAvailable);

            return builder.ToString();
        }

        // закрытие подключения
        protected internal void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
        }
    }
}