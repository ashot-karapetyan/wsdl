using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CBA_Client_ExchangeRatesByDateByISO
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
            IEnumerator<CBA.ExchangeRatesDS.ExchangeRatesByRangeRow> enumerator = Program.getRates(selectedISO, from, to);
            int rowIndex = 0;
            while (enumerator.MoveNext())
            {
                CBA.ExchangeRatesDS.ExchangeRatesByRangeRow current = enumerator.Current;
                int ammount = current.Amount;
                String iso = current.ISO;
                decimal diff = current.Diff;
                decimal rate = current.Rate;
                String date = current.RateDate.ToString("dd/MM/yy");
                this.ratesTable.Rows.Add(new String[] { date, rate.ToString(), diff.ToString() });
                Color backColor = diff > 0 ? Color.Green : Color.Red;
                this.ratesTable.Rows[rowIndex++].Cells[2].Style.BackColor = backColor;
            }

            this.selectedISO.Enabled = true;
            this.fromDateTimePicker.Enabled = true;
            this.toDateTimePicker.Enabled = true;
            this.submitButton.Enabled = true;
        }

      
    }
}
