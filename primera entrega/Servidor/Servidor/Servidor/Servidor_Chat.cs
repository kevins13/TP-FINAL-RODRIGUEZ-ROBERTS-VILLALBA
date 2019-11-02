using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;//para usar hilos 
using System.Net.Sockets;//para usar sockets
using System.IO;//para usar el flujo de informacion
using System.Net;//para trabajar en red

namespace Servidor
{
    class Servidor_Chat
    {
        /*        
            TcpListener--------> Espera la conexion del Cliente.        
            TcpClient----------> Proporciona la Conexion entre el Servidor y el Cliente.        
            NetworkStream------> Se encarga de enviar mensajes atravez de los sockets.        
        */

        private TcpListener server;//objeto de tcplistener, para esperar las conexiones de otros clientes,ecucha
        private TcpClient client = new TcpClient();//para crear la conexion entre el servidor y los clientes
        private IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Any, 8000);//para almacenar una direccion ip y un puerto
        private List<Connection> list = new List<Connection>();//lista para guardar las conexiones

        Connection con;


        private struct Connection
        {
            public NetworkStream stream;
            public StreamWriter streamw;
            public StreamReader streamr;
            public string nick;
        }

        public Servidor_Chat()
        {
            Inicio();//se llama del constructor al metodo incio
        }

        public void Inicio()
        {

            Console.WriteLine("Servidor OK!");
            server = new TcpListener(ipendpoint);//va a empezar conexiones
            server.Start();//arranca el servidor

            while (true)//bucle infinito para dar ciclos
            {
                client = server.AcceptTcpClient();//se espera que un cliente se conecte

                con = new Connection();//se crea nueva conexion
                con.stream = client.GetStream();//se obtiene el flujo de conexion
                con.streamr = new StreamReader(con.stream);//flujo de lectura 
                con.streamw = new StreamWriter(con.stream);//flujo de escritura para mandar la informacion

                con.nick = con.streamr.ReadLine();//se lee por el flujo de informacion el nick

                list.Add(con);//se agreaga a nuestra lista de econxiones
                Console.WriteLine(con.nick + " se a conectado.");



                Thread t = new Thread(Escuchar_conexion);//se crea un hilo para que a medida que se conecta mas clientes se hace mas bubles while en paralelo

                t.Start();//se arranca el hilo
            }


        }

        void Escuchar_conexion()
        {
            Connection hcon = con;//se pasa para nere una nueva conexion y se pasa las variables

            do
            {
                try
                {
                    string tmp = hcon.streamr.ReadLine();//se lee el flujo de lectura del cliente 
                    Console.WriteLine(hcon.nick + ": " + tmp);//se escribe el nick y lo que escribio
                    foreach (Connection c in list)//recorre todas las conexiones y escribe si se mandaron mas mensajes y luego los borra
                    {
                        try
                        {
                            c.streamw.WriteLine(hcon.nick + ": " + tmp);
                            c.streamw.Flush();
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                    list.Remove(hcon);
                    Console.WriteLine(con.nick + " se a desconectado.");
                    break;
                }
            } while (true);
        }
       
    }
}
