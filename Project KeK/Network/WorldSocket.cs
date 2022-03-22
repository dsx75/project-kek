﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using TaidanaKage.Kek;

namespace WorldServer.Network;

public class WorldSocket
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public bool Started { get; private set; } = false;

    private readonly CancellationTokenSource token;
    private TcpListener worldListener;

    public WorldSocket() => token = new CancellationTokenSource();


    public bool Start()
    {
        try
        {
            worldListener = new TcpListener(IPAddress.Parse("127.0.0.1"), Program.Sandbox.WorldPort);
            worldListener.Start();
            Started = true;
        }
        catch (Exception e)
        {
            logger.Error(e, "{0}", e.Message);
            logger.Info("");
            Started = false;
        }

        return Started;
    }

    public void StartConnectionThread() => new Thread(AcceptConnection).Start();


    private void AcceptConnection()
    {
        while (true)
        {
            Thread.Sleep(1);
            if (worldListener.Pending())
            {
                WorldManager World = new WorldManager
                {
                    Socket = worldListener.AcceptSocket()
                };

                World.Handshake();
                Task.Run(World.Recieve, token.Token);
            }
        }
    }

    private void Dispose()
    {
        token.Cancel();
        worldListener.Stop();
    }
}
