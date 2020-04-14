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
        public AllCategoriesView()
        {
            InitializeComponent();
            dataGridView1.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(dataGridView1_RowHeaderMouseClick);
        }

        //dataGridView1 RowHeaderMouseClick Event  
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string categoryId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }
    }
}
