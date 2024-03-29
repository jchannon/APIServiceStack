﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APIServiceStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var listeningOn = args.Length == 0 ? "http://172.16.0.163:1234/" : args[0];
            var appHost = new AppHost();
            appHost.Init();
            appHost.Start(listeningOn);

            Console.WriteLine("AppHost Created at {0}, listening on {1}", DateTime.Now, listeningOn);
            Console.ReadKey();
        }
    }
}
