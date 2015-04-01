using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create client socket
            TcpClient socket = new TcpClient("localhost", 50000);

            // Get NetworkStream from client
            NetworkStream netStream = socket.GetStream();

            // Put a StreamReader  and a StreamWriter on the networkStream
            StreamReader reader = new StreamReader(netStream);
            StreamWriter writer = new StreamWriter(netStream);
            writer.AutoFlush = true;

            Console.WriteLine("Enter up to 5 messages to send to the server as prompted:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Next Message>");
                String str = Console.ReadLine();
                if(str.Equals("bye")) break;
                writer.WriteLine(str);
                str = reader.ReadLine();
                Console.WriteLine(str);
            }

            socket.Close();
        }
    }
}
