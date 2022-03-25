using NLog;

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
        ApplicationConfiguration.Initialize();
        Application.Run(new FormLauncher());
    }
}
