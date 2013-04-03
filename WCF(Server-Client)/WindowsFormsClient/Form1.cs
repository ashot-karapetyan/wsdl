using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WindowsFormsClient;
using System.Collections;
using WindowsFormsClient.RateGate;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.selectedISO.Items.AddRange(Program.getAvailableCurrencies());
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            this.ratesTable.Rows.Clear();
            this.renderTable();
            /*
            Thread thread = new Thread(new ThreadStart(this.renderTable));
            thread.Start();*/
            
        }

        private  void renderTable()
        {
            //Form1 this_ = (Form1)form;
            this.selectedISO.Enabled = false;
            this.fromDateTimePicker.Enabled = false;
            this.toDateTimePicker.Enabled = false;
            this.submitButton.Enabled = false;
            DateTime from = this.fromDateTimePicker.Value;
            DateTime to = this.toDateTimePicker.Value;
            String selectedISO = (String)this.selectedISO.SelectedItem;
            IEnumerator  enumerator = Program.getRates(selectedISO, from, to);
            int rowIndex = 0;
            while (enumerator.MoveNext())
            {
                ExchangeRatesByRangeDataTableRow current = (ExchangeRatesByRangeDataTableRow)enumerator.Current;
                int ammount = current.Ammount;
                String iso = current.ISO;
                decimal diff = current.Diff;
                decimal rate = current.Rate;
                String date = current.RateDate.ToString("yy/MM/dd");
                this.ratesTable.Rows.Add(new String[] { date, rate.ToString(), diff.ToString() });
                Color backColor = diff > 0 ? Color.Green : Color.Red;
                this.ratesTable.Rows[rowIndex].Cells[2].Style.BackColor = backColor;
                if(rowIndex %2 == 1){
                    this.ratesTable.Rows[rowIndex].Cells[0].Style.BackColor = Color.Gray;
                    this.ratesTable.Rows[rowIndex].Cells[1].Style.BackColor = Color.Gray;
                }
                rowIndex++;
            }

            this.selectedISO.Enabled = true;
            this.fromDateTimePicker.Enabled = true;
            this.toDateTimePicker.Enabled = true;
            this.submitButton.Enabled = true;
        }

      
    }
}
