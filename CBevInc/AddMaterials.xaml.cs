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

namespace CBevInc
{
    /// <summary>
    /// Interaction logic for AddMaterials.xaml
    /// </summary>
    public partial class AddMaterials : Window
    {
        WebDBEntities db = new WebDBEntities();
        public int fgID;
        public AddMaterials(int FGID)
        {
            fgID = FGID;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in db.Raw_Materials)
            {
                comboBox.Items.Add(item.Description);
            }
            comboBox.SelectedIndex = 1;
            quanBox.Text = "0";
        }

        private void subButton_Click(object sender, RoutedEventArgs e)
        {
            int temp;
            if (comboBox.SelectedIndex == -1)
            {
                errBox.Content = "Error: Please select an item.";
                return;
            }
            if (!int.TryParse(quanBox.Text, out temp) || temp <= 0)
            {
                errBox.Content = "Error: Please input a valid quantity.";
                return;
            }
            Recipe re = new Recipe();
            var raw = db.Raw_Materials.ToArray();
            re.FGID = fgID;
            re.Quantity = temp;
            re.RMID = raw[comboBox.SelectedIndex].RMID;
            db.Recipes.Add(re);
            db.SaveChanges();
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
