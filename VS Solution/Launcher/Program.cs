using NLog;
using System.Globalization;

namespace TaidanaKage.Kek;

public static class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    ///  KeK Launcher.
    ///  <br/>
    ///  A temporary launcher based on Windows Forms.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        logger.Info("----- Launcher started -----");

        // TODO Is this needed?
        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

        // Configuration
        ApplicationConfiguration.Initialize();

        // Show the main form
        Application.Run(new FormLauncher());
    }
}
