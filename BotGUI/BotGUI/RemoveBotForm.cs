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
    public partial class RemoveBotForm : Form
    {
        public RemoveBotForm()
        {
            InitializeComponent();
        }

        private void RemoveBotForm_Load(object sender, EventArgs e)
        {
            List<DataItem> botCombo = new List<DataItem>();
            List<Bot> bots = Market.getBots();
            for (int i = 0; i < bots.Count(); ++i)
                botCombo.Add(new DataItem(i, bots.ElementAt(i).getName()));
            comboBox1.DataSource = botCombo;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Market.getBots().RemoveAt(comboBox1.SelectedIndex);
            this.Close();
        }
    }
}
