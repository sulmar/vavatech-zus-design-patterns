﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonPattern
{

    public class Singleton<T>
        where T : new()
    {
        private static object syncLock = new object();

        private static T _instance;
        public static T Instance
        {
            get
            {
                lock (syncLock)                 // Monitor.Enter(syncLock)
                {
                    _instance ??= new T();
                }                               // Monitor.Exit(syncLock)

                return _instance;
            }
        }
    }

    public class LoadBalancer : Singleton<LoadBalancer>
    {
        private readonly List<Server> servers;

        private readonly Random random = new Random();

        public LoadBalancer()
        {
            Console.WriteLine("Initialize");

            servers = new List<Server>
            {
                new Server { Name = "ServerA", IP = "192.168.0.18" },
                new Server { Name = "ServerB", IP = "192.168.0.19" },
                new Server { Name = "ServerC", IP = "192.168.0.20" },
                new Server { Name = "ServerD", IP = "192.168.0.21" },
                new Server { Name = "ServerE", IP = "192.168.0.22" },
            };
        }

        // Simple Load Balancer
        public Server NextServer => servers[random.Next(servers.Count)];

       
        
    }

    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }
}
