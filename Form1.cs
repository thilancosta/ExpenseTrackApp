using ExpenseTrackApp.Controllers;
using ExpenseTrackApp.Services.TransactionServices;
using ExpenseTrackApp.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Console.WriteLine(date);

            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = trcon.get_transactions_by_month_userid(user_id, date);
            adapt.Fill(dt);
            allTransactionsView.dataGridView1.DataSource = dt;

            allTransactionsView.Show();
            allTransactionsView.comboBox2.SelectedValue = DateTime.Now.Month.ToString();

        }
    }
}
