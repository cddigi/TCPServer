using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TcpIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the TcpListener
            TcpListener listener = new TcpListener(IPAddress.Any, 50000);

            //Start the listener
            listener.Start();
            // Loop waiting for up to 5 connection requests from TcpClients
            while(true)
            {
                Console.WriteLine("Waiting for a connection request");
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Got a connection request");
                Thread th = new Thread(ParametrizedStart);
                th.Start(client);
            }

        }

        //static void talkEchoToClient(TcpClient client)
        //{
        //    // Get NetworkStream from client
        //    NetworkStream netStream = client.GetStream();

        //    // Put a StreamReader  and a StreamWriter on the networkStream
        //    StreamReader reader = new StreamReader(netStream);
        //    StreamWriter writer = new StreamWriter(netStream);
        //    writer.AutoFlush = true;

        //    String input = reader.ReadLine();
        //    while (true)
        //    {
        //        // Echo upper-cased version of what you got
        //        writer.WriteLine(input.ToUpper());
        //        // Read another line from the client.
        //        input = reader.ReadLine();
        //        if (input.Equals("bye")) break;
        //    }
        //    client.Close();
        //}

        static void ParametrizedStart(Object client)
        {
            TcpClient socket = (TcpClient)client;
            // Get NetworkStream from client
            NetworkStream netStream = socket.GetStream();

            // Put a StreamReader  and a StreamWriter on the networkStream
            StreamReader reader = new StreamReader(netStream);
            StreamWriter writer = new StreamWriter(netStream);
            writer.AutoFlush = true;

            String input = reader.ReadLine();
            while (true)
            {
                // Echo upper-cased version of what you got
                writer.WriteLine(input.ToUpper());
                // Read another line from the client.
                input = reader.ReadLine();
                if (input.Equals("bye")) break;
            }
            socket.Close();
        }
    }
}