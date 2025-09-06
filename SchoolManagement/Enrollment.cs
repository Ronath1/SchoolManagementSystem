using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolManagement
{
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker2.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=RONATH\sqlexpress;Initial Catalog=schooldb;Integrated Security=True");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into teachertab values(@teacherid,@teachername,@gender,@phone)", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", textBox2.Text);
            cnn.Parameters.AddWithValue("@Gender", textBox3.Text);
            cnn.Parameters.AddWithValue("@Phone", textBox4.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
