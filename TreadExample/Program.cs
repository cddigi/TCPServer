using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ThreadExample
{
    class Program
    {
        // Random number generator used to generate random intervals
        static Random randy = new Random();

        // Number of times each thread will write a letter
        static int Count = 50;

        // This is the thread method for a thread that prints the letter 'A'
        static void MyAThreadMethod()
        {
            for (int k = 0; k < Count; k++)
            {
                System.Console.Write('A');
                Thread.Sleep(randy.Next(100));
            }
        }

        // This is a thread method for a thread that prints a letter 
        // passed in as parameter when Start is called on the thread
        static void MyParametrizedThreadMethod(Object ch)
        {
            // Cast the object ch to the type you know it should be.
            char ch1 = (char)ch;

            // Print the character  passed in as parameter
            for (int k = 0; k < Count; k++)
            {
                System.Console.Write(ch1);
                Thread.Sleep(randy.Next(100));
            }
        }

        static void Main(string[] args)
        {
            // Create a thread to print the letter A.
            Thread aThread = new Thread(MyAThreadMethod);

            // Create a thread to print a letter that will be passed 
            //in as parameter when the thread is started.
            Thread bThread = new Thread(MyParametrizedThreadMethod);

            // Create a thread to print a letter that will be passed 
            //in as parameter when the thread is started.
            Thread cThread = new Thread(MyParametrizedThreadMethod);

            // Start the thread to print A
            aThread.Start();
            // Start the thread to print B
            bThread.Start('B');
            // Start the thread to print C
            cThread.Start('C');

            // The Main thread will print  D
            for (int k = 0; k < Count; k++)
            {
                System.Console.Write('D');
                Thread.Sleep(randy.Next(100));
            }

            // If Main thread terminates first, it will wait for all other 
            // threads to terminate.
            aThread.Join();
            bThread.Join();
            cThread.Join();

            Console.WriteLine("Press any key to terminate");
            Console.ReadKey();
        }
    }
}
