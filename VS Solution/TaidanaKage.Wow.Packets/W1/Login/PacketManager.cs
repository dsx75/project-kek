namespace TaidanaKage.WoW.Packets.W1.Login;

/// <summary>
/// Basic processing of W1 Login Packets.
/// <br/>
/// Converting incomming packets: raw data --> object
/// <br/>
/// Converting oubound packets: object --> raw data
/// </summary>
public static class PacketManager
{
    private static IPacketReader? _packetReader;

    public static void Start()
    {
        _packetReader = new MyPacketReader();
    }

    public static IPacketReader PacketReader
    {
        get
        {
            if (_packetReader == null)
            {
                InvalidOperationException ex = new("Before using any functionality, Packet Manager must be started first.");
                throw (ex);
            }
            return _packetReader;
        }
    }

    public static void Stop()
    {
        _packetReader = null;
    }
}
