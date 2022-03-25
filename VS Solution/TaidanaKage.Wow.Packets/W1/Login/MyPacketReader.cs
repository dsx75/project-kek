namespace TaidanaKage.WoW.Packets.W1.Login;

internal class MyPacketReader : IPacketReader
{
    internal MyPacketReader()
    {

    }

    public IIncomingPacket Parse(byte[] data)
    {
        return new MyIncomingPacket(data);
    }
}
