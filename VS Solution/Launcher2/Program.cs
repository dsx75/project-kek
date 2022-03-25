namespace TaidanaKage.Kek;

public static class Program
{
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
