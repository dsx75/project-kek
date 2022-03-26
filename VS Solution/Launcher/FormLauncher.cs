using TaidanaKage.Kek.Common;
using TaidanaKage.Kek.Meta;
using TaidanaKage.Kek.Meta.Clients;
using TaidanaKage.Wow.Server.Meta.W1;
using TaidanaKage.Wow.Server.World.W1;

namespace TaidanaKage.Kek;

public partial class FormLauncher : Form
{
    private readonly IMeta _meta;

    public FormLauncher()
    {
        InitializeComponent();

        buttonPlay.Enabled = true;
        buttonStop.Enabled = false;

        // Only during testing (create a new meta database for each run)
        //DeleteMetaFolder();

        _meta = MetaFactory.Meta;

        ReloadClients();
    }

    private void buttonPlay_Click(object sender, EventArgs e)
    {
        buttonPlay.Enabled = false;
        buttonStop.Enabled = true;

        // TODO Check these periodically, or maybe some push system from servers?
        labelWowMetaServerStatus.ForeColor = Color.Green;
        labelWowMetaServerStatus.Text = "Running";

        labelWowWorldServerStatus.ForeColor = Color.Green;
        labelWowWorldServerStatus.Text = "Running";

        //labelKekWorldServerStatus.ForeColor = Color.Green;
        //labelKekWorldServerStatus.Text = "Running";

        WowMetaServer.Start(AddToLog);
        WowWorldServer.Start(AddToLog);
    }

    private void ButtonStop_Click(object sender, EventArgs e)
    {
        buttonStop.Enabled = false;
        buttonPlay.Enabled = true;

        // TODO Check these periodically, or maybe some push system from servers?
        labelWowMetaServerStatus.ForeColor = Color.Red;
        labelWowMetaServerStatus.Text = "Stopped";

        labelWowWorldServerStatus.ForeColor = Color.Red;
        labelWowWorldServerStatus.Text = "Stopped";

        //labelKekWorldServerStatus.ForeColor = Color.Red;
        //labelKekWorldServerStatus.Text = "Stopped";

        WowWorldServer.Stop(AddToLog);
        WowMetaServer.Stop(AddToLog);
    }

    private void buttonAbout_Click(object sender, EventArgs e)
    {

    }

    private void buttonWorldVersions_Click(object sender, EventArgs e)
    {

    }

    private void buttonManageClients_Click(object sender, EventArgs e)
    {
        // TODO temporary hack
        _meta.ClientManager.AddClient(@"F:\WoW\Clients\W1\WoW.exe");
        _meta.ClientManager.AddClient(@"F:\WoW\Clients\W2\WoW.exe");
        _meta.ClientManager.AddClient(@"F:\WoW\Clients\W3\WoW.exe");
        _meta.ClientManager.AddClient(@"F:\WoW\Clients\W4\WoW.exe");
        _meta.ClientManager.AddClient(@"F:\WoW\Clients\W5\Wow64.exe");

        ReloadClients();
    }

    private void buttonManageAccounts_Click(object sender, EventArgs e)
    {

    }

    private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void comboBoxRulesets_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void comboBoxWorlds_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void buttonManageRulesets_Click(object sender, EventArgs e)
    {

    }

    private void buttonManageWorlds_Click(object sender, EventArgs e)
    {

    }

    private void textBoxLog_TextChanged(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// This method (a delegate) provides a way for the WoW Meta Server to write directly into the Launcher's Log.
    /// </summary>
    /// <param name="message"></param>
    private void AddToLog(string message)
    {
        textBoxLog.Text += message + Environment.NewLine;
    }

    /// <summary>
    /// For testing purposes
    /// </summary>
    [Obsolete]
    private void DeleteMetaFolder()
    {
        // Let's delete Meta Folder to enforce Meta Database re-creation every times
        if (Directory.Exists(Utils.MetaFolder))
        {
            Directory.Delete(Utils.MetaFolder, true);
        }
    }

    private void ReloadClients()
    {
        comboBoxClients.Items.Clear();
        foreach (int idClient in _meta.ClientManager.Clients())
        {
            IClient? client = _meta.ClientManager.GetClient(idClient);
            if (client != null)
            {
                comboBoxClients.Items.Add(client.ExeFile);
            }
        }
    }
}
