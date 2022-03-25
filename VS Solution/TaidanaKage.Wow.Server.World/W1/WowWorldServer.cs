using NLog;
using SuperSimpleTcp;
using System.Text;

namespace TaidanaKage.Wow.Server.World.W1;

/// <summary>
/// Wow World Server - version W1.
/// <br/>
/// Communicating with the client during the gameplay.
/// </summary>
public static class WowWorldServer
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    private static SimpleTcpServer? _server;

    // Loose coupling. We can call this library from a console application, Windows Forms application, etc.
    public delegate void DisplayInfo(string message);

    public static void Start(DisplayInfo displayInfo)
    {
        // Listening IP and Port
        _server = new SimpleTcpServer("127.0.0.1", 8085);

        // Server configuration
        _server.Events.ClientConnected += (sender, e) => ClientConnected(sender, e, displayInfo);
        _server.Events.ClientDisconnected += (sender, e) => ClientDisconnected(sender, e, displayInfo);
        _server.Events.DataReceived += (sender, e) => DataReceived(sender, e, displayInfo);

        _server.StartAsync();

        //PacketManager.Start();

        string message = "WoW World Server started.";
        logger.Info(message);
        displayInfo(message);
    }

    public static void Stop(DisplayInfo displayInfo)
    {
        if (_server != null)
        {
            _server.Stop();
            _server.Dispose();
            string message = "WoW World Server stopped.";
            logger.Info(message);
            displayInfo(message);
        }
    }

    static void ClientConnected(object sender, ConnectionEventArgs e, DisplayInfo displayInfo)
    {
        string message = "[" + e.IpPort + "] client connected";
        logger.Info(message);
        displayInfo(message);
    }

    static void ClientDisconnected(object sender, ConnectionEventArgs e, DisplayInfo displayInfo)
    {
        string message = "[" + e.IpPort + "] client disconnected: " + e.Reason.ToString();
        logger.Info(message);
        displayInfo(message);
    }

    static void DataReceived(object sender, DataReceivedEventArgs e, DisplayInfo displayInfo)
    {
        //IIncomingPacket packet = PacketManager.PacketReader.Parse(e.Data);

        //string message = "[" + e.IpPort + "]: Data received, length " + packet.Length;
        string message = "[" + e.IpPort + "]: Data received, length " + e.Data.Length;
        displayInfo(message);
        logger.Info(message);
        logger.Debug(Encoding.UTF8.GetString(e.Data));
    }
}
