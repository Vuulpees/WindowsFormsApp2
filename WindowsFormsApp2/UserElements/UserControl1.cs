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
using WindowsFormsApp2.UserElements;

namespace WindowsFormsApp2.UserElements
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1(Product product)
        {
            InitializeComponent();
            Fill(product);

        }
        private Product _product;
        private Model1 model = new Model1();
        public void Fill(Product product)
        {
            _product = product;
            labelType.Text = _product.ProductType.Title;
            labelName.Text = _product.Title;
            labelArticle.Text = _product.ArticleNumber;
            labelCost.Text = $"{_product.MinCostForAgent} руб.";
            labelMaterial.Text = $"Материалы: {_product.ProductMaterial}";
            try
            {
                pictureBox1.Image = Image.FromFile(@"products" + _product.Image);
            }
            catch
            {
                pictureBox1.Image = WindowsFormsApp2.Properties.Resources.picture;
            }

        }
        private void Delete()
        {
            DialogResult result = MessageBox.Show(
                $"Вы действительно хотите удалить продукцию с ID {_product.ID}",
                "Сообщение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    model.Product.Remove(
                        model.Product.First(x => x.ID == _product.ID));
                    model.SaveChanges();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void Clicking(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormInformation info = new FormInformation(_product);
                info.ShowDialog();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Delete();
            }
        }

        private void Controls_Click(object sender, MouseEventArgs e)
        {
            Clicking(e);
        }
    }
}
