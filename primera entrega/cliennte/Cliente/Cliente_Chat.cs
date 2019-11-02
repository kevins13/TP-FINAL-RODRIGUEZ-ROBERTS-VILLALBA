using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cliente
{
    public class Cliente_Chat
    {
        static Socket servidor;
        IPEndPoint miDireccion;

        public Cliente_Chat(string ip, int puerto)
        {
            servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.miDireccion = new IPEndPoint(IPAddress.Parse(ip), puerto);
            try
            {
                servidor.Connect(miDireccion);
                Console.WriteLine("Conexion con servidor exitosa");
            }
            catch (Exception error)
            {
                Console.WriteLine("Error: {0}", error.ToString());
            }


        }

        private static void RecibirMensaje()
        {
            while (true)
            {
                byte[] b = new byte[100];
                int k = servidor.Receive(b);
                string msg = Encoding.ASCII.GetString(b, 0, k);
                byte[] bytes = Encoding.ASCII.GetBytes(msg);
                Console.WriteLine("nuevo mensaje: ");
                Console.WriteLine(msg);
            }
        }

        public void enviarMensajes()
        {
            bool algo = true;

            while (true)
            {

                Console.WriteLine("Escriba su mensaje: ");
                string msg = Console.ReadLine();
                byte[] bytes = Encoding.ASCII.GetBytes(msg);
                servidor.Send(bytes);



                Thread thr = new Thread(Cliente_Chat.RecibirMensaje);
                if (algo)
                {
                    thr.Start();
                    algo = false;
                }

            }
        }

        public void Desconectar() => servidor.Close();
    }
}