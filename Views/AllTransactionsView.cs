using ExpenseTrackApp.Controllers;
using ExpenseTrackApp.Dto;
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
        string _transId = null;
        Month1[] cats_fortest = { };
        //public event System.Windows.Forms.DataGridViewCellMouseEventHandler RowHeaderMouseClick;
        public AllTransactionsView()
        {
            InitializeComponent();
            this.dataBind();
            this.dataBindCat();
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_RowHeaderMouseClick);
            button1.Visible = false;
            button2.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dataBindCat()
        {
            CategoryController categoryController = new CategoryController();

            List<CategoryDto> list = new List<CategoryDto>();
            Month1[] cats = { };
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";

            
            list = categoryController.get_cats_by_userid(user_id);
            if (list.Count() > 0)
            {
                cats = new Month1[list.Count()];
                cats_fortest = new Month1[list.Count()];
                int i = 0;
                foreach (var cat in list)
                {
                    cats[i] = new Month1(cat.categoryId, cat.category, cat.type);
                    cats_fortest[i] = new Month1(cat.categoryId, cat.category, cat.type);
                    i++;
                }
            }

            comboBox1.DataSource = cats;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

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
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Amount (Rs)";
            dataGridView1.Columns[7].HeaderText = "Payer or Payee";
            this.clear_data();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void clear_data()
        {
            _transId = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _transId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value != null ? dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() : null;
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            button1.Visible = true;
            button2.Visible = true;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void refresh_datagrid()
        {
            TransactionController transactionController = new TransactionController();
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            string date = DateTime.Now.Year.ToString() + '-' + DateTime.Now.Month.ToString();

            //Console.WriteLine(date);

            DataTable dt = new DataTable();
            MySqlDataAdapter adapt = transactionController.get_transactions_by_month_userid(user_id,date);
            adapt.Fill(dt);
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Amount (Rs)";
            dataGridView1.Columns[7].HeaderText = "Payer or Payee";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransactionController transactionController = new TransactionController();

            int result;
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            ITransaction transaction  = new Transaction();
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1)
            {
                transaction.transactionId = Guid.NewGuid().ToString();
                transaction.user_id = user_id;
                transaction.remarks = textBox1.Text;
                transaction.category_id = comboBox1.SelectedValue.ToString();
                transaction.amount = Convert.ToDouble(textBox2.Text);
                transaction.timestamp = DateTime.Now;
                transaction.payer_payee = textBox3.Text != "" ? textBox3.Text : null;


                result = transactionController.save_transaction(transaction);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var cat in cats_fortest)
            {
                if ((cat.id == comboBox1.SelectedValue.ToString()) && cat.type == "expense")
                {
                    label6.Text = "Payee";
                }
                else if ((cat.id == comboBox1.SelectedValue.ToString()) && cat.type == "income")
                {
                    label6.Text = "Payer";
                }
            }
            
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransactionController transactionController = new TransactionController();

            int result;
            string user_id = "7fa65ff0-4a3e-4cc5-b975-fae5c16b385e";
            ITransaction transaction = new Transaction();
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.SelectedIndex != -1)
            {
                if (_transId != null)
                {
                    transaction.transactionId = _transId;
                    transaction.user_id = user_id;
                    transaction.remarks = textBox1.Text;
                    transaction.category_id = comboBox1.SelectedValue.ToString();
                    transaction.amount = Convert.ToDouble(textBox2.Text);
                    //transaction.timestamp = DateTime.Now;
                    transaction.payer_payee = textBox3.Text != "" ? textBox3.Text : null;


                    result = transactionController.update_transaction(transaction);

                    if (result > 0)
                    {
                        MessageBox.Show("Record Updated Succecfully", "Success", MessageBoxButtons.OK);
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

        private void button2_Click(object sender, EventArgs e)
        {
            TransactionController transactionController = new TransactionController();

            int result;
            if (_transId != null)
                {
                                        
                    result = transactionController.delete_transaction(_transId);

                    if (result > 0)
                    {
                        MessageBox.Show("Record Deleted Succecfully", "Success", MessageBoxButtons.OK);
                        this.refresh_datagrid();
                        this.clear_data();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You have to select a row to delete", "Required", MessageBoxButtons.OK);
                }

        }
    }
}
