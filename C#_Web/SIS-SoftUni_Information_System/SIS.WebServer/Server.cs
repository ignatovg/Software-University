﻿using SIS.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SIS.WebServer
{
   public class Server
    {
        private const string LocalHostIpAdress = "127.0.0.1";

        private readonly int port;
        private readonly TcpListener listener;
        private readonly ServerRoutingTable serverRoutingTable;
        private bool isRunning;

        public Server(int port, ServerRoutingTable serverRoutingTable)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(LocalHostIpAdress), this.port);
            this.serverRoutingTable = serverRoutingTable;
        }
        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server is running on http://{LocalHostIpAdress}:{this.port}");

            var task = Task.Run(this.ListenLoop);
            task.Wait();
        }

        public async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, serverRoutingTable);
                var responseTask = connectionHandler.ProcessRequestAsync();
                responseTask.Wait();
            }
        }
    }
}
