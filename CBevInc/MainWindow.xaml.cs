using CBevInc.Pages;
using System.Windows;
namespace CBevInc
{
    public partial class MainWindow : Window
    {
        private IngrPage ingr;
        private FinPage fin;
        private AnaPage ana;
        private HelpPage help;
        private RepoPage reports;
        public MainWindow()
        {
            InitializeComponent();
            ingr = new IngrPage();
            fin = new FinPage();
            ana = new AnaPage();
            help = new HelpPage();
            reports = new RepoPage();
        }

        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home());
        }
        public void navIngr()
        {
            ingr.loadData();
            MainFrame.Navigate(ingr);
        }
        public void navFin()
        {
            MainFrame.Navigate(fin);
        }
        public void navAna()
        {
            MainFrame.Navigate(ana);
        }
        public void navHelp()
        {
            MainFrame.Navigate(help);
        }
        public void navRepo()
        {
            MainFrame.Navigate(reports);
        }
        public void navHome()
        {
            MainFrame.Navigate(new Home());
        }
    }
}
