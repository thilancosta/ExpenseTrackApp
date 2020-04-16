using ExpenseTrackApp.Controllers;
using ExpenseTrackApp.Dto;
using ExpenseTrackApp.Models;
using ExpenseTrackApp.Services.TransactionServices;
using ExpenseTrackApp.Views;
using MySql.Data.MySqlClient;
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

namespace ExpenseTrackApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void transaction_button_Click(object sender, EventArgs e)
        {
            TransactionController trcon = new TransactionController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            //string year = DateTime.Now.Year("YY");
            string date = DateTime.Now.Year.ToString() + '-' +DateTime.Now.Month.ToString();

            //string date;
            //char[] chars = month.ToCharArray();
            //if (chars[0] == '0')
            //{
            //     date = year + "-" + chars[1];
            //}
            //else
            //{
            //    date = year + "-" + month;
            //}
            //trcon.get_transactions_by_month_userid(user_id, month);

            AllTransactionsView allTransactionsView = new AllTransactionsView();
            //Console.WriteLine(date);

            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = trcon.get_transactions_by_month_userid(user_id, date);
            adapt.Fill(dt);
            allTransactionsView.dataGridView1.DataSource = dt;
            allTransactionsView.dataGridView1.Columns[0].Visible = false;
            allTransactionsView.dataGridView1.Columns[5].Visible = false;
            allTransactionsView.dataGridView1.Columns[6].Visible = false;
            allTransactionsView.dataGridView1.Columns[2].HeaderText = "Amount ($)";
            allTransactionsView.dataGridView1.Columns[7].HeaderText = "Payer or Payee";

            allTransactionsView.Show();
            allTransactionsView.comboBox2.SelectedValue = DateTime.Now.Month.ToString();

        }

        private void category_button_Click(object sender, EventArgs e)
        {
            CategoryController catcon = new CategoryController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            

            AllCategoriesView allCategoriesView = new AllCategoriesView();
            //Console.WriteLine(date);

            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = catcon.get_categories_by_userid(user_id);
            adapt.Fill(dt);
            allCategoriesView.dataGridView1.DataSource = dt;
            allCategoriesView.dataGridView1.Columns[0].Visible = false;


            allCategoriesView.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryController catcon = new CategoryController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            string date = DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString();

            CategorySummaryDto exp = new CategorySummaryDto();
            CategorySummaryDto inc = new CategorySummaryDto();

            exp = catcon.get_category_expense_summary(user_id, date);
            inc = catcon.get_category_income_summary(user_id, date);

            //int? value = categoryResponseDtoExp?.?.PropertyB?.PropertyC;.HasValue
            //CultureInfo usCulture = new CultureInfo("en-US");
            double expense;
            double income;
            double balance;
            expense = exp.totalExpenes;
            income = inc.totalExpenes;
            balance = income - expense;
            SummaryView sumview = new SummaryView();
            sumview.label6.Text = expense.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            sumview.label5.Text = income.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            if (balance > 0)
            {
                sumview.label7.Text = balance.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
            }
            else
            {
                sumview.label7.Text = "-" + balance.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));
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
                if (mo.id == DateTime.Now.Month.ToString())
                {
                    sumview.label4.Text = mo.name;
                }
            }
            sumview.Show();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            PredictionView predictionView = new PredictionView();
            predictionView.Show();
        }
    }
}
