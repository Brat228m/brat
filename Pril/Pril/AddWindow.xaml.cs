using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pril
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public static AbEntities db = new AbEntities();
        public Product CurrentProduct { get; set; }
        public IEnumerable<ProductType> productType { get; set; }


        public AddWindow(Product product)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = product;
            productType = Core.db.ProductType.ToArray();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentProduct.ProductType == null)
                    throw new Exception("Не выбран тип");

                if (CurrentProduct.ID == 0)
                    Core.db.Product.Add(CurrentProduct);

                Core.db.SaveChanges();

                DialogResult = true;

            }
            catch
            {
                MessageBox.Show($"Сохранено");

                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
