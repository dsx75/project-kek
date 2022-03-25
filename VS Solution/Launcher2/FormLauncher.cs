using TaidanaKage.Wow.Server.Meta.W1;

namespace TaidanaKage.Kek;

public partial class FormLauncher : Form
{
    public FormLauncher()
    {
        InitializeComponent();
        buttonPlay.Enabled = true;
        buttonStop.Enabled = false;
    }

    private void buttonPlay_Click(object sender, EventArgs e)
    {
        buttonPlay.Enabled = false;
        buttonStop.Enabled = true;
        WowMetaServer.Start();
    }

    private void ButtonStop_Click(object sender, EventArgs e)
    {
        buttonStop.Enabled = false;
        buttonPlay.Enabled = true;
        WowMetaServer.Stop();
    }

    private void buttonAbout_Click(object sender, EventArgs e)
    {

    }

    private void buttonWorldVersions_Click(object sender, EventArgs e)
    {

    }

    private void buttonManageClients_Click(object sender, EventArgs e)
    {

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
}
