using System;
using System.Globalization;
using Common.Constants;
using Common.Cryptography;
using Common.Interfaces;
using NLog;
using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta;
using WorldServer.Network;
using WorldServer.Packets;

namespace TaidanaKage.Kek;

public static class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public static SandboxHost Sandbox;

    public static void Main(string[] args)
    {
        Console.WriteLine("START");

        // Only during testing (create a new meta database for each run)
        InitializeMeta();

        IMeta meta = MetaFactory.Meta;

        // As the first thing in the Launcher player should select which client he wants to play
        meta.ClientManager.SelectedClientId = 3;

        if (meta.ClientManager.SelectedClient == null)
        {
            logger.Error("No selected client.");
            return;
        }
        else
        {
            logger.Info("Selected client: " + meta.ClientManager.SelectedClient.ExeFile);
        }

        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        ISandbox sandbox = WotLK_12340.Sandbox.Instance;
        Sandbox = new SandboxHost(sandbox);

        RealmManager.RealmSession = new RealmSocket();
        WorldManager.WorldSession = new WorldSocket();

        if (WorldManager.WorldSession.Start() && RealmManager.RealmSession.Start())
        {
            RealmManager.RealmSession.StartRealmThread();
            RealmManager.RealmSession.StartProxyThread();
            WorldManager.WorldSession.StartConnectionThread();

            logger.Info("");
            logger.Info("Loading {0}", Sandbox.RealmName);
            logger.Info("RealmProxy listening on {0} port(s) {1}.", "127.0.0.1", Sandbox.RealmPort);
            logger.Info("RedirectServer listening on {0} port {1}.", "127.0.0.1", Sandbox.RedirectPort);
            logger.Info("WorldServer listening on {0} port {1}.", "127.0.0.1", Sandbox.WorldPort);
            logger.Info("Started {0}", Sandbox.RealmName);
            logger.Info("");
            logger.Info("Default client password set to \"{0}\"", Authenticator.Password);
            logger.Info("");

            HandlerDefinitions.InitializePacketHandler();
            AreaTriggers.Initialize(Sandbox);
            Worldports.Initialize(Sandbox);
        }
        else
        {
            if (!WorldManager.WorldSession.Started)
                logger.Error("WorldServer couldn't be started.");
            if (!RealmManager.RealmSession.Started)
                logger.Error("RealmServer couldn't be started.");
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("END");
    }

    /// <summary>
    /// For testing purposes
    /// </summary>
    private static void InitializeMeta()
    {
        // Let's delete Meta Folder to enforce Meta Database re-creation every times
        if (Directory.Exists(Utils.MetaFolder))
        {
            Directory.Delete(Utils.MetaFolder, true);
        }

        IMeta meta = MetaFactory.Meta;

        meta.ClientManager.AddClient(@"F:\WoW\Clients\W1\WoW.exe");
        meta.ClientManager.AddClient(@"F:\WoW\Clients\W2\WoW.exe");
        meta.ClientManager.AddClient(@"F:\WoW\Clients\W3\WoW.exe");
        meta.ClientManager.AddClient(@"F:\WoW\Clients\W4\WoW.exe");
        meta.ClientManager.AddClient(@"F:\WoW\Clients\W5\Wow64.exe");
    }
}
