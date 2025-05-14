using BlogClientWinForms.BlogServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlogClientWinForms
{
    public partial class PostForm : Form
    {
        private BlogServiceClient _client;
        public PostForm()
        {
            InitializeComponent();
        }
        public PostForm(BlogServiceClient client)
        {
            InitializeComponent();
            _client = client;
        }

        private async void btnAddPost_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string content = txtContent.Text;

            try
            {
                var post = await _client.AddPostAsync(title, content);
                MessageBox.Show($"تمت إضافة التدوينة بنجاح (ID: {post.Id})");
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل إضافة التدوينة: " + ex.Message);
            }
        }
    }
}
