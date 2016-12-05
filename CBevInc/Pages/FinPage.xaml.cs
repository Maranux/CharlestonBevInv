using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CBevInc.Pages
{
    /// <summary>
    /// Interaction logic for FinPage.xaml
    /// </summary>
    public partial class FinPage : Page
    {
        private int curPos;
        bool isNew = false;
        public FinPage()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData(int pos = 0)
        {
            WebDBEntities db = new WebDBEntities();
            var data = db.Finished_Goods.ToArray();
            if (pos >= data.Length) pos = 0;
            if (pos <= -1) pos = data.Length - 1;
            var cur = data.ElementAt(pos);
            fgidBox.Text = cur.FGID.ToString();
            priceBox.Text = cur.Price.Value.ToString("C");
            descBox.Text = cur.Description;
            matGrid.ItemsSource = cur.Recipes;
            packBox.Text = cur.Packaging;
            curPos = pos;
            isNew = false;
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            loadData(curPos + 1);
        }

        private void rgtBtn_Click(object sender, RoutedEventArgs e)
        {
            loadData(curPos - 1);
        }
        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).navHome();
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            fgidBox.Text = "0000";
            priceBox.Text = 0.00.ToString("C");
            descBox.Text = "";
            errBox.Content = "";
            isNew = true;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            int newFGID;
            decimal newPrice;
            WebDBEntities db = new WebDBEntities();
            Finished_Goods fg = new Finished_Goods();

            if (priceBox.Text == 0.00.ToString("C") || !decimal.TryParse(priceBox.Text.Trim('$'), out newPrice) || newPrice <= 0)
            {
                errBox.Content = "Error: Please input a price that is greater than 0 and is numeric.";
                return;
            }
            if (descBox.Text == "")
            {
                errBox.Content = "Error: Please input a description.";
                return;
            }
            if (packBox.Text == "")
            {
                errBox.Content = "Error: Please input a package type.";
                return;
            }
            if (!int.TryParse(fgidBox.Text, out newFGID) || newFGID < 0)
            {
                errBox.Content = "Error: Please input an FGID that is numerical and greater than 0.";
                return;
            }
            fg.Price = (double)newPrice;
            fg.FGID = newFGID;
            fg.Description = descBox.Text;
            fg.Packaging = packBox.Text;
            if (db.Finished_Goods.Find(newFGID) != null)
            {
                if (isNew)
                {
                    errBox.Content = "Error: There is already a product with that ID.";
                    return;
                }
                else
                {
                    // Delete current element based on its previous FGID
                    db.Finished_Goods.Remove(db.Finished_Goods.Find(db.Finished_Goods.ToArray().ElementAt(curPos).FGID));
                    db.SaveChanges();
                }
            }
            db.Finished_Goods.Add(fg);
            try 
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

                errBox.Content = "Error: There is already a product with that ID.";
                return;
            }
            errBox.Content = "Item saved.";
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            WebDBEntities db = new WebDBEntities();
            Finished_Goods fg = new Finished_Goods();
            if (isNew)
            {
                fgidBox.Text = 0000.ToString();
                descBox.Text = "";
                priceBox.Text = "$0.00";
                packBox.Text = "";
                errBox.Content = "";
                return;
            }
            else
            {
                db.Finished_Goods.Remove(db.Finished_Goods.Find(db.Finished_Goods.ToArray().ElementAt(curPos).FGID));
                db.SaveChanges();
                loadData(curPos);
                errBox.Content = "";
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            WebDBEntities db = new WebDBEntities();
            int newFGID;
            decimal newPrice;
            if (priceBox.Text == 0.00.ToString("C") || !decimal.TryParse(priceBox.Text.Trim('$'), out newPrice) || newPrice <= 0)
            {
                errBox.Content = "Error: Please create a finished good before adding materials.";
                return;
            }
            if (descBox.Text == "")
            {
                errBox.Content = "Error: Please create a finished good before adding materials.";
                return;
            }
            if (packBox.Text == "")
            {
                errBox.Content = "Error: Please create a finished good before adding materials.";
                return;
            }
            if (!int.TryParse(fgidBox.Text, out newFGID) || newFGID < 0)
            {
                errBox.Content = "Error: Please create a finished good before adding materials.";
                return;
            }
            try
            {
                Finished_Goods fg = db.Finished_Goods.Find(newFGID);
            }
            catch (Exception)
            {

                errBox.Content = "Error: Please save the finished good before adding materials.";
            }

            AddMaterials am = new AddMaterials(newFGID);
            am.ShowDialog();
        }
    }
}
