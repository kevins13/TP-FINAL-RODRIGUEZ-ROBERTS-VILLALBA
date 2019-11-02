using System;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente_Chat cliente = new Cliente_Chat("192.168.0.15", 1234);
            cliente.enviarMensajes();
        }
    }
}
