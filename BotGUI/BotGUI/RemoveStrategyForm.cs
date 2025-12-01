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
    public partial class RemoveStrategyForm : Form
    {
        public RemoveStrategyForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RemoveStrategyForm_Load(object sender, EventArgs e)
        {
            List<DataItem> botCombo = new List<DataItem>();
            List<Bot> bots = Market.getInstance().getBots();
            for (int i = 0; i < bots.Count(); ++i)
                botCombo.Add(new DataItem(i, bots.ElementAt(i).getName()));
            comboBox1.DataSource = botCombo;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Market.getInstance().getBots()[comboBox1.SelectedIndex].removeStrategy(int.Parse(numericUpDown1.Value.ToString()));
            this.Close();
        }
    }
}
