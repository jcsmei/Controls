using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;

            if (address.Equals("about:blank")) return;

            if (!address.StartsWith("http://")) address = "http://" + address;

            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {

            try
            {
                this.webBrowser1.Navigate(new Uri("http://www.google.com"));
                webBrowser1.Url = new Uri("http://www.google.com");
                Navigate(txtUrl.Text); 
            }
            catch (Exception ex)
            {
                // error meesage for an invalid web address.
                MessageBox.Show(ex.Message);
            }
            //Navigate(txtUrl.Text);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int w = hScrollBar1.Value;
            btnSize.Width = w;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int h = vScrollBar1.Value;
            btnSize.Height = h;
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            //Navigate(txtUrl.Text);
        }

        private void hScrollBar2_Font_Scroll(object sender, ScrollEventArgs e)
        {
            int fontsize = hScrollBar2_Font.Value;
            lblFontSize.Font = new Font("Arial", fontsize);
            lblFontSize.Text = fontsize.ToString();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        { 
            Navigate(txtUrl.Text);
        }
    }

}