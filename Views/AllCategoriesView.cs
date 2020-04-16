using ExpenseTrackApp.Controllers;
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
    public partial class AllCategoriesView : Form
    {
        string _categoryId = null;
        public AllCategoriesView()
        {
            InitializeComponent();
            this.dataBind();
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_RowHeaderMouseClick);
            button2.Visible = false;
        }

        public void dataBind()
        {
            //var months = new Dictionary<string, string>[12];
            //months[0] = new Dictionary<string, string> { { "id", "1" }, { "name", "January" } };
            //months[1] = new Dictionary<string, string> { { "id", "2" }, { "name", "February" } };
            //months[2] = new Dictionary<string, string> { { "id", "3" }, { "name", "March" } };

            var months = new Month[2];
            months[0] = new Month("expense", "Expense");
            months[1] = new Month("income", "Income");

            //comboBox2.Items.AddRange(months);
            comboBox1.DataSource = months;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }

        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _categoryId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            button2.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CategoryController categoryController = new CategoryController();

            int result;
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            ICategory category = new Category();
            if (textBox1.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex != -1)
            {
                category.categoryId = Guid.NewGuid().ToString();
                category.userId = user_id;
                category.category = textBox1.Text;
                category.type = comboBox1.SelectedValue.ToString();
                category.exp_limit = Convert.ToDouble(textBox3.Text);


                result = categoryController.save_category(category);

                if (result > 0)
                {
                    MessageBox.Show("Record Inserted Succecfully", "Success", MessageBoxButtons.OK);
                    this.refresh_datagrid();
                    this.clear_data();
                }
                else
                {
                    MessageBox.Show("Record Not Inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the details", "Required", MessageBoxButtons.OK);
            }
            
        }

        private void clear_data()
        {
            _categoryId = null;
            textBox1.Text = null;
            textBox3.Text = null;
        }

        private void refresh_datagrid()
        {
            CategoryController catcon = new CategoryController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";


            //Console.WriteLine(date);

            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = catcon.get_categories_by_userid(user_id);
            adapt.Fill(dt);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CategoryController categoryController = new CategoryController();

            int result;
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            ICategory category = new Category();
            if (textBox1.Text != "" && textBox3.Text != "" && comboBox1.SelectedIndex != -1)
            {
                if (_categoryId != null)
                {
                    category.categoryId = _categoryId;
                    category.userId = user_id;
                    category.category = textBox1.Text;
                    category.type = comboBox1.SelectedValue.ToString();
                    category.exp_limit = Convert.ToDouble(textBox3.Text);


                    result = categoryController.update_cat(category);

                    if (result > 0)
                    {
                        MessageBox.Show("Record Updated Successfully", "Success", MessageBoxButtons.OK);
                        this.refresh_datagrid();
                        this.clear_data();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You have to select a row to update", "Required", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please fill all the details", "Required", MessageBoxButtons.OK);
            }

        }
    }
}
