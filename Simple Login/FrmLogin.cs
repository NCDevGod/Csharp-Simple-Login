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

namespace Simple_Login
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        public SqlConnection con = new SqlConnection("Data source = YOUR SQL SERVER; Initial catalog = YOUR DATABASE; Integrated security = TRUE;");
        public SqlDataAdapter da = new SqlDataAdapter();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtEmail.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Information empty", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string check = "SELECT email, password FROM account WHERE email = '" + txtEmail.Text + "' AND password = '" + txtPassword.Text + "'";
            da = new SqlDataAdapter(check, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Login fail", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Login success", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmLoginSuccess fm = new FrmLoginSuccess();
                fm.Show();
                this.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit application?","MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
