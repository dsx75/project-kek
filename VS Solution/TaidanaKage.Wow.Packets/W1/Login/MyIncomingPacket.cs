namespace TaidanaKage.WoW.Packets.W1.Login;

internal class MyIncomingPacket : IIncomingPacket
{
    private readonly byte[] _data;

    internal MyIncomingPacket(byte[] data)
    {
        _data = data;
    }

    public byte[] RawData => _data;

    public int Length => _data.Length;
}
