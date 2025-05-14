using BlogClientWinForms.BlogServiceReference;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogClientWinForms
{
    public partial class LoginForm : Form
    {
        public BlogServiceClient Client { get; private set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Text;

            var client = new BlogServiceClient();
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;

            try
            {
                // اختبر صلاحية الدخول بمحاولة بسيطة (مثلاً استدعاء GetPosts)
                //await client.GetPostsAsync();
                var posts = client.GetPosts();


                // إن نجحت، خزّن العميل وافتح النموذج الآخر
                Client = client;
                PostForm postForm = new PostForm(Client);
                postForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل تسجيل الدخول: " + ex.Message);
            }
        
    }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
