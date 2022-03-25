namespace TaidanaKage.WoW.Packets.W1.Login;

/// <summary>
/// Parser of W1 Login Packets.
/// </summary>
public interface IPacketReader
{
    IIncomingPacket Parse(byte[] packet);
}
