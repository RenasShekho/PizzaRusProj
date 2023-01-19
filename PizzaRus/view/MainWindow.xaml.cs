using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using System.Diagnostics;
using PizzaRus.ViewModel;
using PizzaRus.view;
using System.Threading;
using PizzaRus.Model;
using PizzaRus.Repositories;
using HandyControl.Controls;
using Window = System.Windows.Window;

namespace PizzaRus
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
     

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindowViewModel viewModel = new();

        KøbVinduet køV;
        MenyPage MP;
        DrikkevarerPage DP;
        TilbehørPage Tb;
            
       readonly DAL dal = new DAL();
        
        public MainWindow()
        {
            

            InitializeComponent();

            //this.Text = this.Text + "--" + LoginTable.UserName;
         
            Tb = new TilbehørPage(dal);
            MP = new MenyPage(dal);
            DP = new DrikkevarerPage(dal);
            viewModel.lb = lbkurv;
            this.DataContext = viewModel;
            Main.Navigate(dal);
        }

       
        private void windowLoaded(object sende, RoutedEventArgs eva)
        {
            this.Hide();
            LoginWindow lw = new LoginWindow();
            lw.ShowDialog();
            if (Thread.CurrentPrincipal?.Identity?.IsAuthenticated == true)
            {
                this.Show();
            }
            else
            {
                this.Close();
            }


        }

        private void btTilbehør_Click(object sender, RoutedEventArgs e)
        {
            Tb.DataContext = dal;
            Main.Content = Tb;
        }

        private void btMeny_Click(object sender, RoutedEventArgs e)
        {
                           
                MP.DataContext = dal;
                Main.Content = MP;            
                  
        }

        private void btnKurv_Click(object sender, RoutedEventArgs e)
        {
            //Button btn = new Button();
            if (viewModel.VM_OrdersDataBase.Count != 0)
            {
                KøbVinduet køv = new KøbVinduet(viewModel.VM_OrdersDataBase, viewModel.FullPris);

                if (køv.ShowDialog() == true)
                {
                    viewModel.Slet();
                }
            }
            //KøbVinduet køv = new KøbVinduet(dal);
            //køv.ShowDialog();
            //køv.DataContext = dal;
        
        
        }
        private void btDrikkevarer_Click(object sender, RoutedEventArgs e)
        {
            DP.DataContext = dal;
            Main.Content = DP;
        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {
            //for (int v = 0; v < lbkurv.SelectedItems.Count; v++)
            //{
            //    lbkurv.Items.Remove(lbkurv.SelectedItems[v]);
           //}
            lbkurv.Items.Clear();           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
                
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

      
        
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            //if (sender is Button b)
            //{
            //    if (b.DataContext is Orders order)
            //        if (order.Toppings.Count > 0)
            //        {
            //            {
            //                var customViewModel = new ViewModels();
            //                ToppingsWindow custom = new ToppingsWindow(viewModel.VM_PizzaDataBase, viewModel.FullPrice, customViewModel, order);
            //                custom.ShowDialog();


            //                viewModel.FullPrice = 0;
            //                for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Adds the price of items in Order, to FullPrice.
            //                {
            //                    viewModel.FullPrice += customViewModel.selected.Pris;
            //                }
            //                viewModel.UpdateOrder(customViewModel.selected);
            //            }
            //        }
            //}

        }





        //Fields






        //private void LoadCurrentUserData()
        //{
        //    var user = UserRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
        //    if (user != null)
        //    {
        //        CurrentUserAccount.Username = user.Username;
        //        CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
        //        CurrentUserAccount.ProfilePicture = null;
        //    }
        //    else
        //    {
        //        CurrentUserAccount.DisplayName = "Invalid user, not logged in";
        //        //Hide child views.
        //    }
        //}


    }
}
   