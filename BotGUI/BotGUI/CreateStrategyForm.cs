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
    public partial class numSharesBox : Form
    {
        public numSharesBox()
        {
            InitializeComponent();
        }

        private void CreateStrategyForm_Load(object sender, EventArgs e)
        {
            // error in generation - code doesn't execute
            List<DataItem> botCombo = new List<DataItem>();
            List<Bot> bots = Market.getInstance().getBots();
            Console.Write("got here and bots is " + bots.ToString());
            for (int i = 0; i < bots.Count(); ++i)
                botCombo.Add(new DataItem(i, bots.ElementAt(i).getName()));
            botCBox.DataSource = botCombo;
            botCBox.DisplayMember = "Name";
            botCBox.ValueMember = "Id";
        }

        private void numSharesBox_Load(object sender, EventArgs e)
        {
            List<DataItem> botCombo = new List<DataItem>();
            List<Bot> bots = Market.getInstance().getBots();
            Console.Write("got here and bots is " + bots.ToString());
            for (int i = 0; i < bots.Count(); ++i)
                botCombo.Add(new DataItem(i, bots.ElementAt(i).getName()));
            botCBox.DataSource = botCombo;
            botCBox.DisplayMember = "Name";
            botCBox.ValueMember = "Id";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Market m = Market.getInstance();
            Bot b = m.getBots()[botCBox.SelectedIndex];
            IStrategy ret = new CoreStrategy(buyRButton.Checked, fokRButton.Checked, b);
            if (costBaseAboveCBox.Checked)
            {
                if (relativeAboveCBox.Checked)
                    ret = new RelativeCostBasisDetail(ret, float.Parse(costBaseAboveBox.Value.ToString()) / 100f, false);
                else ret = new CostBasisDetail(ret, float.Parse(costBaseAboveBox.Value.ToString()), false);
            }
            if (costBaseBelowCBox.Checked)
            {
                if (relativeBelowCBox.Checked)
                    ret = new RelativeCostBasisDetail(ret, float.Parse(costBaseBelowBox.Value.ToString()) / 100f, true);
                else ret = new CostBasisDetail(ret, float.Parse(costBaseBelowBox.Value.ToString()), true);
            }
            if (linearRegressAboveCBox.Checked)
            {
                float temp1 = float.Parse(linearRegressAboveSlopeBox.Value.ToString());
                int temp2 = int.Parse(linearRegressAboveLengthBox.Value.ToString());
                float temp3 = float.Parse(linearRegressAboveRsqBox.Value.ToString());
                bool useR = linearRegressAboveRsqCBox.Checked;
                bool nomiss = linearRegressAboveMissCBox.Checked;
                ret = new LinearPredictionStrategyDetail(ret, temp2, false, temp1, (useR) ? temp3 : null, nomiss);
            }
            if (linearRegressBelowCBox.Checked)
            {
                float temp1 = float.Parse(linearRegressBelowSlopeBox.Value.ToString());
                int temp2 = int.Parse(linearRegressBelowLengthBox.Value.ToString());
                float temp3 = float.Parse(linearRegressBelowRsqBox.Value.ToString());
                bool useR = linearRegressBelowRsqCBox.Checked;
                bool nomiss = linearRegressBelowMissCBox.Checked;
                ret = new LinearPredictionStrategyDetail(ret, temp2, true, temp1, (useR) ? temp3 : null, nomiss);
            }
            ret = new StrategyDetailComposite(ret, new List<String>(tickersBox.Text.Replace(" ", "").Replace("\n", ",").Split(",")));
            ret = new SharesDetail(ret, int.Parse(numericUpDown1.Value.ToString()));
            if (minCostRelativeCBox.Checked)
                ret = new MinRelativeValueDetail(ret, float.Parse(minCostBox.Value.ToString()) / 100f);
            else ret = new MinValueDetail(ret, float.Parse(minCostBox.Value.ToString()));
            if (maxCostRelativeCBox.Checked)
                ret = new MaxRelativeValueDetail(ret, float.Parse(maxCostBox.Value.ToString()) / 100f);
            else ret = new MaxValueDetail(ret, float.Parse(maxCostBox.Value.ToString()));
            if (pauseCBox.Checked || waitCBox.Checked)
                ret = new WaitDetail(ret, pauseCBox.Checked ? int.Parse(pauseBox.Value.ToString()) : 0, waitCBox.Checked ? int.Parse(waitBox.Value.ToString()) : 0);
            if (killCBox.Checked)
                ret = new KillDetail(ret);
            b.addStrategy(ret);
            m.refresh();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
