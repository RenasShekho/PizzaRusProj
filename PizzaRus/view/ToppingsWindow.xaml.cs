using PizzaRus.Model;
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

namespace PizzaRus.view
{

    public partial class ToppingsWindow : Window
    {
        public ToppingViewModel ToppingviewModel;
        private bool _closedManually;


        public ToppingsWindow(Pizza Pizza, double Pris, ToppingViewModel toppingViewModel /*Orders order*/)
        {
            
            
            ToppingviewModel = toppingViewModel;
            ToppingviewModel.pizzas.Add( Pizza );
            ToppingviewModel.OriTops = Pizza.Toppings;
            //ToppingviewModel.selected = order;
                //Changed Pizza
                //
                DataContext = ToppingviewModel;
            //ToppingviewModel.fortryd = order.Copy();   //Original Pizza
            InitializeComponent();
        }

       

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            ToppingviewModel.RemovePresetToppings();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!_closedManually)
            {
                ToppingviewModel.Fortryd();
            }
            base.OnClosed(e);
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            
            _closedManually = true;
            DialogResult = true;
        }

        private void btn_OffPizza_Click(object sender, RoutedEventArgs e) //Button for left side, aka adding to the pizza
        {
            if (sender is Button b)
            {
                if (b != null)
                {
                    Toppings SelectedTopping = (Toppings)b.DataContext;
                    if (SelectedTopping != null)
                    {
                        ToppingviewModel.AddTopping(SelectedTopping);
                    }
                }
            }
        }

        private void btn_OnPizza_Click(object sender, RoutedEventArgs e) //Button for right side, aka taking off of on pizza
        {
            if (sender is Button b)
            {
                if (b != null)
                {
                    Toppings SelectedTopping = (Toppings)b.DataContext;
                    if (SelectedTopping != null)
                    {
                        ToppingviewModel.RemoveTopping(SelectedTopping);
                    }
                }
            }
        }

        private void btn_Fortryd_Click(object sender, RoutedEventArgs e)
        {
            ToppingviewModel.Fortryd();
            this.Close();
        }
    }
}