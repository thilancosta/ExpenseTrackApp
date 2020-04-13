﻿using ExpenseTrackApp.Controllers;
using ExpenseTrackApp.Models;
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

namespace ExpenseTrackApp.Views
{
    public partial class AllTransactionsView : Form
    {
        public AllTransactionsView()
        {
            InitializeComponent();
            this.dataBind();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            months[1] = new Month( "2" , "February" );
            months[2] = new Month( "3" , "March" );
            months[3] = new Month( "4" , "April" );
            months[4] = new Month( "5" , "May" );
            months[5] = new Month( "6" , "June" );
            months[6] = new Month( "7" , "July" );
            months[7] = new Month( "8" , "August" );
            months[8] = new Month( "9" , "September" );
            months[9] = new Month( "10" , "October" );
            months[10] = new Month( "11" , "November" );
            months[11] = new Month( "12" , "December" );

            //comboBox2.Items.AddRange(months);
            comboBox2.DataSource = months;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "name";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string var = comboBox2.SelectedValue.ToString();
            Console.WriteLine(var);

            TransactionController trcon = new TransactionController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            string date = DateTime.Now.Year.ToString() + '-' + var;



            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = trcon.get_transactions_by_month_userid(user_id, date); 
            adapt.Fill(dt);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = dt;
        }
    }
}
