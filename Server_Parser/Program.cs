using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            int recv;
            byte[] data = new byte[1024];
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 15000);
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            ServerSocket.Bind(ipep);
            Console.WriteLine("Ожидаем соединение с клиентом...");
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)(sender);

            recv = ServerSocket.ReceiveFrom(data, ref Remote);
            Console.Write("Сообщение получено от {0}:", Remote.ToString());
            Console.WriteLine(Encoding.UTF8.GetString(data, 0, recv));

            string welcome = "Подключение установлено.";
            data = Encoding.UTF8.GetBytes(welcome);
            ServerSocket.SendTo(data, data.Length, SocketFlags.None, Remote);


            while (true)
            {
                data = new byte[1024];

                recv = ServerSocket.ReceiveFrom(data, ref Remote);
                string ClientCommand = Encoding.UTF8.GetString(data, 0, recv);

                if (ClientCommand == "exit") break;
                Command CommandObject = new Command();

                var TupleResult = CommandObject.Parser(ClientCommand);
  
                
                    Console.WriteLine("Получили данные: " + ClientCommand);
                    Console.WriteLine($"Номер команды: {TupleResult.CommandNumber}");
                    Console.Write("Набор параметров: ");
                
                try
                {
                    if (TupleResult.parameters != null)
                    {
                        foreach (var i in TupleResult.parameters)
                        {
                            Console.Write("{0} " + " ", i);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("параметры отсутствуют");
                }

                
                    Console.Write("Код цвета: ");
                
                try
                {
                    foreach (var i in TupleResult.color)
                    {
                        Console.Write("{0} " + " ", i);
                    }
                    Console.WriteLine();
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("параметры отсутствуют");
                }
            }








            Console.ReadKey();
        }

    }

}

