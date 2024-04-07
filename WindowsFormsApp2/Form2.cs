using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Model;


namespace WindowsFormsApp2
{
    public partial class FormInformation : Form
    {
        public FormInformation(Product product)
        {
            InitializeComponent();
            _product = product;
            LoadData();
        }
        private void LoadData()
        {
            textBoxArticle.Text = _product.ArticleNumber.ToString();
            textBoxName.Text = _product.Title;
            textBoxType.Text = _product.ProductType.Title;
            textBoxCost.Text = _product.MinCostForAgent.ToString();
            textBoxDescription.Text = _product.Description;

            try
            {
                pictureBox1.Image = Image.FromFile(@"products" + _product.Image);
            }
            catch
            {
                pictureBox1.Image = WindowsFormsApp2.Properties.Resources.picture;
            }
        }
        private Product _product;

        private void buttonexit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
