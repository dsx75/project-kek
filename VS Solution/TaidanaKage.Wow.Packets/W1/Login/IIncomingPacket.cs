namespace TaidanaKage.WoW.Packets.W1.Login;

/// <summary>
/// An incoming (Client --> Server) W1 Login Packet.
/// </summary>
public interface IIncomingPacket
{
    byte[] RawData { get; }

    int Length { get; }
}
