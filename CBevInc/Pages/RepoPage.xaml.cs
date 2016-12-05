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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CBevInc.Pages
{
    /// <summary>
    /// Interaction logic for RepoPage.xaml
    /// </summary>
    public partial class RepoPage : Page
    {
        private int curPos;

        public RepoPage()
        {
            InitializeComponent();
        }
        public void loadData(int pos = 0)
        {
            WebDBEntities db = new WebDBEntities();
            var data = db.Finished_Goods.ToArray();
            if (pos >= data.Length) pos = 0;
            if (pos <= -1) pos = data.Length - 1;
            var cur = data.ElementAt(pos);
            fgidBox.Text = cur.FGID.ToString();
            costBox.Text = cur.Price.Value.ToString("C");
            matGrid.ItemsSource = cur.Recipes;
            curPos = pos;
        }
        private void leaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).navHome();
        }

        private void leftBtn_Click(object sender, RoutedEventArgs e)
        {
            loadData(curPos - 1);
        }

        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            pd.CurrentPageEnabled = true;
            pd.ShowDialog();
        }

        private void rgtBtn_Click(object sender, RoutedEventArgs e)
        {
            loadData(curPos + 1);
        }
    }
}
