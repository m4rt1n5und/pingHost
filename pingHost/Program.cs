using DojoNorthSoftware.Pushover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace pingHost
{

    class Program
    {
        public static bool pingHost(string host, string port)
        {
            try
            {
                TcpClient client = new TcpClient(host, Int32.Parse(port));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void sendPush(string host, string port)
        {
            Exception except;
            // Your pushover key goes here
            //bool notify = Pushover.SendNotification("LJNNaBNdqGKaVQeT38V8Y58EjMqA4d", "PUSHOVER KEY", "Host " + host + " port " + port + " is down", out except);

        }

        public static void checkHost(string host, string port)
        {
            if (!pingHost(host, port))
            {
                Console.Out.WriteLine("Host " + host + " port " + port + " is down");
                sendPush(host, port);
            }
            else
            {
                Console.Out.WriteLine("Host " + host + " port " + port + " is up");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                string host;
                string port;

                if (args == null || args.Length == 0)
                {
                    Console.Out.WriteLine("No arguments, try pingHost ip-adress");
                }
                else
                {
                    host = args[0];
                    port = args[1];

                    Console.Out.WriteLine("Checking host..." + host + " port " + port);
                    checkHost(host, port);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong with the host and port control");
            }

        }
    }
}


