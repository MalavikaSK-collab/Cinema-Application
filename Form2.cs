using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1CinemaApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CashierSummaryGroupBox.Visible = false;
            CompanySumGroupbox.Visible = false;


        }

        double AdultTicketCost = 7.99;
        double StudentTicketCost = 4.99;
        double ChildTicketCost = 2.99;


        private bool CalculateButtonWasClicked = false;
        private bool SummaryButtonWasClicked = false;
        private int CashierCounter = 0;
        private int a = 0, i = 0;
        private int input1;
        private int input2;
        private int input3;
        private int TotalTickets;
        private int SumTotalTickets = 0;
        private double TotalReceipts = 0;
       
    

        void inputs()
        {
            try
            {
                input1 = int.Parse(AdultTextbox.Text);

                /*input1 = Convert.ToInt32(AdultTextbox.Text);
                input2 = Convert.ToInt32(StudentTextbox.Text);
                input3 = Convert.ToInt32(ChildTextbox.Text);*/
                try
                {
                    input2 = int.Parse(StudentTextbox.Text);
             
                    try
                    {
                        input3 = int.Parse(ChildTextbox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Please enter numerical data for Children", "Data entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CashierSummaryGroupBox.Visible = false;
                        CompanySumGroupbox.Visible = false;
                    }

                }
                catch
                {
                    MessageBox.Show("Please enter numerical data for Students", "Data entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CashierSummaryGroupBox.Visible = false;
                    CompanySumGroupbox.Visible = false;
                }
            }    
            catch
            {
                MessageBox.Show("Please enter numerical data for Adults", "Data entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CashierSummaryGroupBox.Visible = false;
                CompanySumGroupbox.Visible = false;
            }
            
        }

   

        
        


        private void CalculateButton_Click(object sender, EventArgs e)
        {
            //CalculateButton.ForeColor = System.Drawing.Color.Black;

            
                //SummaryButtonWasClicked = false;
                CalculateButtonWasClicked = true;
                CashierCounter++;
               
                    
                Form2_Load(sender, e);
                inputs();


                CompanySumGroupbox.Visible = false;
                CashierSummaryGroupBox.Visible = true;

                TotalTickets = input1 + input2 + input3;

                while (i < CashierCounter)
                {
                    SumTotalTickets += TotalTickets;
                    i++;
                }
                
                    
                TotalTicketsTextbox.Text = Convert.ToString(TotalTickets);

                double TotalAdultsTicket = AdultTicketCost * input1;
                double TotalStudentsTicket = StudentTicketCost * input2;
                double TotalChildrenTicket = ChildTicketCost * input3;

                double TotalCost = TotalAdultsTicket + TotalStudentsTicket + TotalChildrenTicket;
                    
                TotalReceiptsTextbox.Text = "€" + TotalCost;

                while (a < CashierCounter)
                {
                    TotalReceipts += TotalCost;
                    a++;
                }

                CashierNameTextbox.Text = CashierTextbox.Text;


                
            
            
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new WelcomeForm().Show();
            CashierCounter = 0;
            SumTotalTickets = 0;
            TotalReceipts = 0;


        }

             
        private void SummaryButton_Click(object sender, EventArgs e)
        {
           
            try
            {
                double AvgTransValue;
                CalculateButtonWasClicked = false;
                SummaryButtonWasClicked = true;

                inputs();
                Form2_Load(sender, e);

                TicketsGroupBox.Visible = false;
                CashierSummaryGroupBox.Visible = false;
                CompanySumGroupbox.Visible = true;

                TotalCashierTextbox.Text = Convert.ToString(CashierCounter);
             
                TotalTicketsSumTextbox.Text = Convert.ToString(SumTotalTickets);

                TotalReceiptsSumTexbox.Text = "€" + TotalReceipts;

               

                AvgTransValue = TotalReceipts / SumTotalTickets;

                AvgTransTextbox.Text = Convert.ToString(AvgTransValue);



            }
            catch(Exception exp)
            {

            }


        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Mouse Hover and Mouse Leave Options

        private void CalculateButton_MouseHover(object sender, EventArgs e)
        {
            CalculateButton.ForeColor = System.Drawing.Color.Black;
        }

        private void CalculateButton_MouseLeave(object sender, EventArgs e)
        {
            CalculateButton.ForeColor = System.Drawing.Color.White;
        }

        private void ClearButton_MouseHover(object sender, EventArgs e)
        {
            ClearButton.ForeColor = System.Drawing.Color.Black;
        }

        private void ClearButton_MouseLeave(object sender, EventArgs e)
        {
            ClearButton.ForeColor = System.Drawing.Color.White;
        }

        private void SummaryButton_MouseHover(object sender, EventArgs e)
        {
            SummaryButton.ForeColor = System.Drawing.Color.Black;
        }

        private void SummaryButton_MouseLeave(object sender, EventArgs e)
        {
            SummaryButton.ForeColor = System.Drawing.Color.White;
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.ForeColor = System.Drawing.Color.Black;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.ForeColor = System.Drawing.Color.White;
        }


        //Form Load Options
        private void Form2_Load(object sender, EventArgs e)
        {
            if (CalculateButtonWasClicked == true)
            {
                this.Text = "Transaction Summary";

            }
            else if (SummaryButtonWasClicked == true)
            {
                this.Text = "All Transactions Summary";

            }
           
        }

       
    }
}
