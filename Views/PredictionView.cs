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
    public partial class PredictionView : Form
    {
        public PredictionView()
        {
            InitializeComponent();
            this.dataBind();
            label2.Visible = false;
            label3.Visible = false;
        }

        private void PredictionView_Load(object sender, EventArgs e)
        {

        }

        public void dataBind()
        {
            //var months = new Dictionary<string, string>[12];
            //months[0] = new Dictionary<string, string> { { "id", "1" }, { "name", "January" } };
            //months[1] = new Dictionary<string, string> { { "id", "2" }, { "name", "February" } };
            //months[2] = new Dictionary<string, string> { { "id", "3" }, { "name", "March" } };

            var months = new Month[3];
            months[0] = new Month("365", "Daily");
            months[1] = new Month("52", "Weekly");
            months[2] = new Month("12", "Monthly");



            //comboBox2.Items.AddRange(months);
            comboBox1.DataSource = months;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var type = comboBox1.SelectedValue.ToString();
            var year = DateTime.Now.Year;
            var pre_year = year - 1;
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            CategoryController categoryController = new CategoryController();
            CategorySummaryDto all_year_exp = new CategorySummaryDto();
            all_year_exp = categoryController.get_category_expense_summary_for_year(user_id, pre_year);
            double prediction_value;
            if (type == "365")
            {
                prediction_value = all_year_exp.totalExpenes / 365;
                label2.Text = prediction_value.ToString("C", CultureInfo.CreateSpecificCulture("en-LK"));
                label3.Text = "Daily Expense Prediction";
                label2.Visible = true;
                label3.Visible = true;
            }
            else if (type == "52")
            {
                prediction_value = all_year_exp.totalExpenes / 52;
                label2.Text = prediction_value.ToString("C", CultureInfo.CreateSpecificCulture("en-LK"));
                label3.Text = "Weekly Expense Prediction";
                label2.Visible = true;
                label3.Visible = true;
            }
            else if (type == "12")
            {
                prediction_value = all_year_exp.totalExpenes / 12;
                label2.Text = prediction_value.ToString("C", CultureInfo.CreateSpecificCulture("en-LK"));
                label3.Text = "Monthly Expense Prediction";
                label2.Visible = true;
                label3.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong type Retry please!");
            }
        }
    }
}
