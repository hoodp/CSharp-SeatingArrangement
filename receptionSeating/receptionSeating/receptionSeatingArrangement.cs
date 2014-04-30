using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*
 * Paul Hood
 * Lesson 3 Homework
 * 2 / 26 / 2013
 * Application Puts names into seating arrangment for a reception
 */

namespace receptionSeating
{
    public partial class receptionSeatingArrangement : Form
    {
        List<string> receptionList; // list of names
        List<Label> labelOutput; //list for labels to change seating arrangment


        public receptionSeatingArrangement()
        {
            InitializeComponent();
        }

        // Instantiates new string when form loads
        private void receptionSeatingArrangement_Load(object sender, EventArgs e)
        {
            receptionList = new List<string>();
            labelOutput = new List<Label>();

            // adds labels to list
            labelOutput.Add(lblSeat1Name);
            labelOutput.Add(lblSeat2Name);
            labelOutput.Add(lblSeat3Name);
            labelOutput.Add(lblSeat4Name);
            labelOutput.Add(lblSeat5Name);
        }

        //name entry method
        public void nameEntry(String name)
        {

            if (name != "") // checks if textbox is not blank
            {
                if (receptionList.Count < 25) // 25 max people at the reception
                {
                    receptionList.Add(name);
                    // if statements update the first table as user adds names
                    if (receptionList.Count == 1)
                    {
                        lblSeat1Name.Text = receptionList[0];    
                    }
                    if (receptionList.Count == 2)
                    {
                        lblSeat2Name.Text = receptionList[1];
                    }
                    if (receptionList.Count == 3)
                    {
                        lblSeat3Name.Text = receptionList[2];
                    }
                    if (receptionList.Count == 4)
                    {
                        lblSeat4Name.Text = receptionList[3];
                    }
                    if (receptionList.Count == 5)
                    {
                        lblSeat5Name.Text = receptionList[4];
                    }
                }
                else // more than 25 names
                {
                    lstOverflow.Items.Add(name);
                }
            }
        }

        // tests length of textbox
        public bool textBoxValidate(TextBox textbox)
        {
            if (textbox.TextLength == 0 || textbox.TextLength > 20)
            {
                if (textbox.TextLength == 0)
                {
                    MessageBox.Show("Please enter a name.", "Alert");
                }
                if (textbox.TextLength > 20)
                {
                    MessageBox.Show("Name must be less than 20 characters.", "Alert");
                }
                return false;
            }
            else
            {
                return true;
            }          
        }

       // submits entry
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxValidate(txtName))
            {
                nameEntry(txtName.Text);
                txtName.Clear(); // clears textbox
                txtName.Focus(); // sets focus
                lblTotal.Text = "Total: " + Convert.ToString(receptionList.Count);   
            }          
        }

        // display table 1 1 - 5
        private void rdoTable1_Click(object sender, EventArgs e)
        {
            tableDisplay(rdoTable1);
        }

        // display table 6 - 10
        private void rdoTable2_Click(object sender, EventArgs e)
        {
            tableDisplay(rdoTable2);
        }

        // display table 11 - 15
        private void rdoTable3_Click(object sender, EventArgs e)
        {
            tableDisplay(rdoTable3);
        }

        // display table 16 - 20
        private void rdoTable4_Click(object sender, EventArgs e)
        {
            tableDisplay(rdoTable4);
        }

        // display table 20 - 25 
        private void rdoTable5_Click(object sender, EventArgs e)
        {
            tableDisplay(rdoTable5);
        }
        
        // display method for radiobuttons (table selection)
        private void tableDisplay(RadioButton table)
        {
            int indexLabel = 0;
            String listString = "";
            // checks to see which radio button is clicked
            if (rdoTable1.Checked)
            {
                lblTabelDisplay.Text = "Table 1";
                for (int s = 0; s < 5; s++) // checks for range inside list
                {
                    // checks to see if person is entered into available spot
                    if (s > receptionList.Count - 1)
                    {
                        listString = "Available";

                    }
                        // prints out name if entered
                    else
                    {
                        listString = receptionList[s];
                    }
                    labelOutput[indexLabel].Text = listString;
                    indexLabel++;
                }      
            }
            else if (rdoTable2.Checked)
            {
                indexLabel = 0;
                listString = "";
                lblTabelDisplay.Text = "Table 2";
                for (int s = 5; s < 10; s++)
                {
                    if (s > receptionList.Count - 1)
                    {
                        listString = "Available";

                    }
                    else
                    {
                        listString = receptionList[s];
                    }
                    labelOutput[indexLabel].Text = listString;
                    indexLabel++;
                }   
            }
            else if (rdoTable3.Checked)
            {
                indexLabel = 0;
                listString = "";
                lblTabelDisplay.Text = "Table 3";
                for (int s = 10; s < 15; s++)
                {
                    if (s > receptionList.Count - 1)
                    {
                        listString = "Available";

                    }
                    else
                    {
                        listString = receptionList[s];
                    }
                    labelOutput[indexLabel].Text = listString;
                    indexLabel++;
                }
            }
            else if (rdoTable4.Checked)
            {
                indexLabel = 0;
                listString = "";
                lblTabelDisplay.Text = "Table 4";
                for (int s = 15; s < 20; s++)
                {
                    if (s > receptionList.Count - 1)
                    {
                        listString = "Available";

                    }
                    else
                    {
                        listString = receptionList[s];
                    }
                    labelOutput[indexLabel].Text = listString;
                    indexLabel++;
                }
            }
            else if (rdoTable5.Checked)
            {
                indexLabel = 0;
                listString = "";
                lblTabelDisplay.Text = "Table 5";
                for (int s = 20; s < 25; s++)
                {
                    if (s > receptionList.Count - 1)
                    {
                        listString = "Available";

                    }
                    else
                    {
                        listString = receptionList[s];
                    }
                    labelOutput[indexLabel].Text = listString;
                    indexLabel++;
                }
            }
        }

        // clears last entered entry
        private void btnClearLast_Click(object sender, EventArgs e)
        {
            // checks for overflow
            if (lstOverflow.Items.Count > 0)
            {
                lstOverflow.Items.RemoveAt(lstOverflow.Items.Count - 1);    
            }
            // removes last in reception
            else if (receptionList.Count > 0 && receptionList.Count <= 25)
            {
                receptionList.RemoveAt(receptionList.Count - 1);   
            }
      
            lblTotal.Text = "Total: " + Convert.ToString(receptionList.Count()); // updates total

            // updates correct table display
            if (rdoTable1.Checked)
            {
                tableDisplay(rdoTable1);
            }
            else if (rdoTable2.Checked)
            {
                tableDisplay(rdoTable2);
            }
            else if (rdoTable3.Checked)
            {
                tableDisplay(rdoTable3);
            }
            else if (rdoTable4.Checked)
            {
                tableDisplay(rdoTable4);
            }
            else if (rdoTable5.Checked)
            {
                tableDisplay(rdoTable5);
            }

            // clears entry box
            txtName.Clear();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart(); // restarts application, found this to be the best option for restart
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exits application
        }     
    }        
}
