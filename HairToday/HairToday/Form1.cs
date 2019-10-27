/*
 * @author Sumit Aggarwal - 000793607
 * I certify that all work done in the assignment is my own work and that I have not copied it
 * from any other source. I also certify that I have not allowed anyone else to copy my code.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HairToday
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// calculates the total amount of the services according to which hairdresser you chose, what kind of services you want
        /// how many times have you visited the place and whether you are an adult, a child, a student or a senior
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                double price = 0;
                int visits = int.Parse(clientVisitsTextBox.Text);
                Boolean isChecked = cutCheckBox.Checked || colorCheckBox.Checked || highlightsCheckBox.Checked ||
                    extensionsCheckBox.Checked;

                if (janeSamleyRadioButton.Checked)
                    price += 30;
                else if (patJohnsonRadioButton.Checked)
                    price += 45;
                else if (ronChambersRadioButton.Checked)
                    price += 40;
                else if (suePallonRadioButton.Checked)
                    price += 50;
                else if (lauraRenkinsRadioButton.Checked)
                    price += 55;

                if (cutCheckBox.Checked)
                    price += 30;
                if (colorCheckBox.Checked)
                    price += 40;
                if (highlightsCheckBox.Checked)
                    price += 50;
                if (extensionsCheckBox.Checked)
                    price += 200;

                if (standardAdultRadioButton.Checked)
                    price -= 0;
                else if (childRadioButton.Checked)
                    price -= 0.1 * price;
                else if (studentRadioButton.Checked)
                    price -= 0.05 * price;
                else if (seniorRadioButton.Checked)
                    price -= 0.15 * price;

                if (visits > 0 && visits < 4)
                    price -= 0;
                else if (visits >= 4 && visits <= 8)
                    price -= 0.05 * price;
                else if (visits >= 9 && visits <= 13)
                    price -= 0.1 * price;
                else if (visits >= 14)
                    price -= 0.15 * price;

                if (visits < 0 || isChecked == false)
                    totalPriceLabel.Text = "No service selected! Select a service and then try again.";
                else
                    totalPriceLabel.Text = "$" + price;
            }
            catch(Exception ex)
            {
                totalPriceLabel.Text = "Invalid entry!" + ex.Message;
            }
            
        }
        /// <summary>
        /// closes the form when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// clears the form and sends the focus to the janeSamleyRadioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (cutCheckBox.Checked)
                cutCheckBox.Checked = false;
            if (colorCheckBox.Checked)
                colorCheckBox.Checked = false;
            if (highlightsCheckBox.Checked)
                highlightsCheckBox.Checked = false;
            if (extensionsCheckBox.Checked)
                extensionsCheckBox.Checked = false;

            janeSamleyRadioButton.Checked = true;
            standardAdultRadioButton.Checked = true;

            clientVisitsTextBox.Text = "";

            janeSamleyRadioButton.Focus();

            totalPriceLabel.Text = "";
        }
    }
}
