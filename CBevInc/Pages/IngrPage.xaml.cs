using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for IngrPage.xaml
    /// </summary>
    public partial class IngrPage : Page
    {
        private int curPos = 0;
        private bool isNew = false;
        public IngrPage()
        {
            InitializeComponent();
        }

        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).navHome();
        }

        public void loadData(int pos = 0)
        {
            WebDBEntities db = new WebDBEntities();
            var data = db.Raw_Materials.ToArray();
            if (pos >= data.Length) pos = 0;
            if (pos <= -1) pos = data.Length - 1;
            var cur = data.ElementAt(pos);
            idBox.Text = cur.RMID.ToString();
            costBox.Text = cur.Cost.Value.ToString("C");
            descBox.Text = cur.Description;
            curPos = pos;
        }

        private void rgtBtn_Click(object sender, RoutedEventArgs e)
        {
            isNew = false;
            loadData(curPos + 1);
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            isNew = false;
            loadData(curPos - 1);
        }

        private void newBtn_Click(object sender, RoutedEventArgs e)
        {
            idBox.Text = "0000";
            costBox.Text = 0.00.ToString("C");
            descBox.Text = "";
            errBox.Content = "";
            isNew = true;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            int newRMID;
            decimal newCost;
            WebDBEntities db = new WebDBEntities();
            Raw_Materials rm = new Raw_Materials();

            if (costBox.Text == 0.00.ToString("C") || !decimal.TryParse(costBox.Text.Trim('$'), out newCost) || newCost <= 0)
            {
                errBox.Content = "Error: Please input a cost that is greater than 0 and is numeric.";
                return;
            }
            if (descBox.Text == "")
            {
                errBox.Content = "Error: Please input a description.";
                return;
            }
            if (!int.TryParse(idBox.Text, out newRMID) || newRMID < 0)
            {
                errBox.Content = "Error: Please input an RMID that is numerical and greater than 0.";
                return;
            }
            rm.Cost = newCost;
            rm.RMID = newRMID;
            rm.Description = descBox.Text;
            if (db.Raw_Materials.Find(newRMID) != null)
            {
                if (isNew)
                {
                    errBox.Content = "Error: There is already a material with that ID.";
                    return;
                } else
                {
                    // Delete current element based on its previous RMID
                    db.Raw_Materials.Remove(db.Raw_Materials.Find(db.Raw_Materials.ToArray().ElementAt(curPos).RMID));
                    db.SaveChanges();
                }
            }
            db.Raw_Materials.Add(rm);
            db.SaveChanges();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            WebDBEntities db = new WebDBEntities();
            Raw_Materials rm = new Raw_Materials();
            if (isNew)
            {
                idBox.Text = 0000.ToString();
                descBox.Text = "";
                costBox.Text = "$0.00";
                return;
            }
            else
            {
                db.Raw_Materials.Remove(db.Raw_Materials.Find(db.Raw_Materials.ToArray().ElementAt(curPos).RMID));
                db.SaveChanges();
                loadData(curPos);
            }
        }
    }
}
