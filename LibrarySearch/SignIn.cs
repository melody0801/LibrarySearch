using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LibrarySearch
{
    public partial class Form1 : Form
    {
        string User, Pwd;
        bool judge = false;

        public Form1()
        {
            InitializeComponent();
        }


        private void btn_signin_Click(object sender, EventArgs e)
        {
            SqlConnection con = Util.SqlConnection();
            con.Open();
            string cmd = "select username,userpasword from UserTable where username=@uid";
            SqlCommand com = new SqlCommand(cmd, con);
            byte[] result = Encoding.Default.GetBytes(this.tB_password.Text.Trim());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string pwd = BitConverter.ToString(output).Replace("-", "");
            com.Parameters.Add(new SqlParameter("uid", tB_username.Text.Trim()));
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if(pwd==reader["userpasword"].ToString())
            {
                judge = true;
            }
            reader.Close();
            con.Close();
            if (judge == true)
            {
                MessageBox.Show("欢迎！");
            }
            else
            {
                MessageBox.Show("用户名不存在或密码错误！");
                tB_username.Text = "";
                tB_password.Text = "";
                tB_username.Focus();
            }
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            
            SignUp form = new SignUp();
            form.Show();
            this.Hide();
        }
    }
}
