using ExpenseTrackApp.Controllers;
using ExpenseTrackApp.Dto;
using ExpenseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackApp.Views
{
    public partial class SummaryView : Form
    {
        //public string _initialmonth;
        public SummaryView()
        {
            InitializeComponent();
            this.dataBind();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void dataBind()
        {
            //var months = new Dictionary<string, string>[12];
            //months[0] = new Dictionary<string, string> { { "id", "1" }, { "name", "January" } };
            //months[1] = new Dictionary<string, string> { { "id", "2" }, { "name", "February" } };
            //months[2] = new Dictionary<string, string> { { "id", "3" }, { "name", "March" } };

            var months = new Month[12];
            months[0] = new Month("1", "January");
            months[1] = new Month("2", "February");
            months[2] = new Month("3", "March");
            months[3] = new Month("4", "April");
            months[4] = new Month("5", "May");
            months[5] = new Month("6", "June");
            months[6] = new Month("7", "July");
            months[7] = new Month("8", "August");
            months[8] = new Month("9", "September");
            months[9] = new Month("10", "October");
            months[10] = new Month("11", "November");
            months[11] = new Month("12", "December");

            

            //comboBox2.Items.AddRange(months);
            comboBox1.DataSource = months;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryController catcon = new CategoryController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            string date = DateTime.Now.Year.ToString() + '-' + comboBox1.SelectedValue.ToString();

            CategorySummaryDto exp = new CategorySummaryDto();
            CategorySummaryDto inc = new CategorySummaryDto();

            exp = catcon.get_category_expense_summary(user_id, date);
            inc = catcon.get_category_income_summary(user_id, date);

            //int? value = categoryResponseDtoExp?.?.PropertyB?.PropertyC;.HasValue
            double expense;
            double income;
            double balance;
            expense = exp.totalExpenes;
            income = inc.totalExpenes;
            balance = income - expense;
            label6.Text = expense.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            label5.Text = income.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            if (balance > 0)
            {
                label7.Text = balance.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                label7.Text = "-" + balance.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            }
            //sumview._initialmonth = DateTime.Now.Month.ToString();

            var months = new Month[12];
            months[0] = new Month("1", "January");
            months[1] = new Month("2", "February");
            months[2] = new Month("3", "March");
            months[3] = new Month("4", "April");
            months[4] = new Month("5", "May");
            months[5] = new Month("6", "June");
            months[6] = new Month("7", "July");
            months[7] = new Month("8", "August");
            months[8] = new Month("9", "September");
            months[9] = new Month("10", "October");
            months[10] = new Month("11", "November");
            months[11] = new Month("12", "December");

            foreach (var mo in months)
            {
                if (mo.id == comboBox1.SelectedValue.ToString())
                {
                    label4.Text = mo.name;
                }
            }
        }
    }
}
