using System.Net.Sockets;
using Common.Extensions;
using NLog;
using TaidanaKage.Kek;

namespace WorldServer.Network;

public class RealmManager
{
    private readonly Logger logger = LogManager.GetCurrentClassLogger();

    public static RealmSocket RealmSession { get; set; }
    public Socket RealmSocket { get; set; }
    public Socket ProxySocket { get; set; }

    public void RecieveRealm() => Program.Sandbox.AuthHandler.HandleRealmList(RealmSocket);

    public void RecieveProxy()
    {
        logger.Info("");
        logger.Info("Begin redirection to WorldServer.");

        ProxySocket.SendData(Program.Sandbox.AuthHandler.HandleRedirect());
        ProxySocket.Close();

        logger.Info("Successfully redirected to WorldServer.");
        logger.Info("");
    }
}
