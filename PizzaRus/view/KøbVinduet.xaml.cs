using PizzaRus.Model;
using PizzaRus.UserControls;
using PizzaRus.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PizzaRus
{
    
 
    public partial class KøbVinduet : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        MainWindow mw;
        DAL dal;

        readonly KøbVinduetViewModel viewModel = new();
        public KøbVinduet(ObservableCollection<Orders> orders, double FullPrice)
        {
            
     
            MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);
           
            InitializeComponent();
            viewModel.Orders = orders;
            viewModel.fullprice = FullPrice;
            this.DataContext = viewModel;


            lbkøbVinduet.ItemsSource = (mw.lbkurv.Items);
        }

        

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnBuy_Click(object sender, RoutedEventArgs e)
        {
            viewModel.OrdersJson();
            this.DialogResult = true;
        }
    }
}
