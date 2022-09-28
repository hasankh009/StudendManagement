using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem
{
    public partial class frmAddStudent : Form
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=SDB;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SID", SqlDbType.NVarChar, 50).Value = txtID.Text;
                cmd.Parameters.Add("@StudentName", SqlDbType.NVarChar, 50).Value = txtSName.Text;
                cmd.Parameters.Add("@FatherName", SqlDbType.NVarChar, 50).Value = txtFName.Text;
                cmd.Parameters.Add("@FatherCNIC", SqlDbType.NVarChar, 50).Value = txtFCNIC.Text;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 50).Value = txtAddress.Text;
                cmd.Parameters.Add("@Cell", SqlDbType.NVarChar, 50).Value = txtCell.Text;
                cmd.Parameters.Add("@Class", SqlDbType.NVarChar, 50).Value = cboClass.Text;
                cmd.Parameters.Add("@Section", SqlDbType.NVarChar, 50).Value = txtSection.Text;
                cmd.Parameters.Add("@AdmDate", SqlDbType.NVarChar, 50).Value = txtAdmDate.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
           catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }

        }
    }
}
