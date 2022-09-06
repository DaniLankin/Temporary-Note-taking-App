using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temporary_Note_taking_App
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Message", typeof(String));

            dgv.DataSource = table;

            dgv.Columns["Message"].Visible = false;
            dgv.Columns["Title"].Width = 183;
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!(tb_title.Text == "" || tb_message.Text == ""))//if not empty
            {
                table.Rows.Add(tb_title.Text, tb_message.Text);
                tb_title.Clear();
                tb_message.Clear();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            tb_title.Clear();
            tb_message.Clear();
        }

        private void View_Click(object sender, EventArgs e)
        {
            int index = dgv.CurrentCell.RowIndex;

            if (index > -1)
            {
                tb_title.Text = table.Rows[index][0].ToString();
                tb_message.Text = table.Rows[index][1].ToString();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            int index = dgv.CurrentCell.RowIndex;

            table.Rows[index].Delete();
        }
    }
}
