using System.Net.Sockets;
using System.Reflection;
using Common.Interfaces;
using NLog;

namespace Common.Extensions;

public static class Extensions
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public static void SendData(this Socket socket, IPacketWriter packet, string packetname = "")
    {
        byte[] buffer = packet.ReadDataToSend();
        try
        {
            socket.Send(buffer, 0, buffer.Length, SocketFlags.None);
            if (!string.IsNullOrEmpty(packetname))
                logger.Debug("SENT {0}.", packetname);
        }
        catch (Exception e)
        {
            logger.Error(e, "{0}", e.Message);
        }
    }

    public static string ToUpperFirst(this string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;

        return char.ToUpper(s[0]) + s.ToLower().Substring(1);
    }

    public static byte Clamp(this byte i, byte min, byte max) => Math.Max(Math.Min(i, max), min);

    public static void SetValueEx(this PropertyInfo pi, object obj, string value)
    {
        Type type = pi.PropertyType.IsEnum ? pi.PropertyType.GetEnumUnderlyingType() : pi.PropertyType;
        pi.SetValue(obj, Convert.ChangeType(value, type));
    }

    public static IEnumerable<T> Yield<T>(this T item)
    {
        yield return item;
    }

    public static string Sanitize(this string value)
    {
        if (value == null || value.Length <= 1)
            return value;

        return string.Join("", value.Split(new char[] { ' ', '\t', '\r', '\n', '\'', ',' }));
    }
}