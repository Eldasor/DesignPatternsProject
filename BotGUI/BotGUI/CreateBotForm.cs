using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotGUI
{
    public partial class CreateBotForm : Form
    {
        public CreateBotForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Market.getInstance().addBot(new Bot(botNameTextBox.Text, float.Parse(botInitialCashBox.Value.ToString())));
            this.Close();
        }
    }
}
