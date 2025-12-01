using Microsoft.VisualBasic.Logging;
using System.Runtime.InteropServices;

namespace BotGUI
{
    public partial class mainForm : Form, IListener, IBackListener
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void autoButton_Click(object sender, EventArgs e)
        {
            if (!stepTimer.Enabled)
            {
                stepTimer.Enabled = true;
                autoButton.Text = "Stop Auto";
                backButton.Enabled = false;
                stepButton.Enabled = false;
            }
            else
            {
                stepTimer.Enabled = false;
                autoButton.Text = "Auto";
                backButton.Enabled = true;
                stepButton.Enabled = true;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void stepTimer_Tick(object sender, EventArgs e)
        {
            Market.getInstance().tick();
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            Market.getInstance().tick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateBotForm newBotForm = new CreateBotForm();
            newBotForm.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // due to some really stupid autocode generation error
            // and my computer slowly updating
            // this form is accidentally misnamed, after breaking a
            // lot of stuff. i am not going to try and fix this name
            numSharesBox newStrategyForm = new numSharesBox();
            newStrategyForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveBotForm removeBotForm = new RemoveBotForm();
            removeBotForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Market.getInstance().back();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            Market.getInstance(this);
        }

        public bool back()
        {
            notify();
            return false;
        }

        public void notify()
        {
            Market m = Market.getInstance();
            richTextBox1.Text = m.getBLog();
            richTextBox2.Text = m.getLog();
            valueLabel.Text = "$" + Math.Round(m.calcVal(), 2);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            RemoveStrategyForm removeStrategyForm = new RemoveStrategyForm();
            removeStrategyForm.Show();
        }
    }
}
