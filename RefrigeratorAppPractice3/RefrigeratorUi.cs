using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefrigeratorAppPractice3
{
    public partial class RefrigeratorUi : Form
    {
        string showTotal = "";
        int i = 1;

        Refrigerator refrigerator;
        public RefrigeratorUi()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {

            if (refrigerator.Set(Convert.ToDouble(itemTextBox.Text), Convert.ToDouble(weightTextBox.Text)))
            {
                MessageBox.Show("Your given amount can't be entered because it will be overflown.");
                itemTextBox.Clear();
                weightTextBox.Clear();
                return;
            }

            itemTextBox.Clear();
            weightTextBox.Clear();

            currentWeightTextBox.Text = refrigerator.GetCurrentWeight().ToString();
            remainingWeightTextBox.Text = refrigerator.RemainingWeight().ToString();

            //MessageBox.Show(refrigerator.GetItems().ToString()+", "+ refrigerator.GetUnit().ToString()+", "+ refrigerator.GetWeight().ToString()+"/[Max Weight]");
            if (i == 1)
            {
                i++;
                showTotal = showTotal + "No Of Item \t" + "Weight/Unit \t" + "Total Weight\n";
            }

            showTotal = showTotal + refrigerator.GetItems().ToString() + "\t\t" + refrigerator.GetUnit().ToString() + "\t\t" + refrigerator.GetWeight().ToString() + "/[Max Weight]" + "\n";
            showRichTextBox.Text = showTotal;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            refrigerator = new Refrigerator(Convert.ToDouble(maxWeightTakeTextBox.Text));
            maxWeightTakeTextBox.Clear();
        }
    }
}
