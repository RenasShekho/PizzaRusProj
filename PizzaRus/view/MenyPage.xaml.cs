using PizzaRus.Model;
using PizzaRus.view;
using PizzaRus.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace PizzaRus
{

    public partial class MenyPage : Page
    {
        //readonly MainWindowViewModel MainViewModel = new();
        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);
        KøbVinduet købV;

        DAL dal;

        ToppingsWindow customTopping;

        public MenyPage(DAL dal)
        {

            this.dal = dal;

            InitializeComponent();



        }


        private void btnTilføj_Click(object sender, RoutedEventArgs e)
        {


            Button btn = (Button)sender; // sender is the button pressed
            if (btn != null) //if btn is not empty
            {
                if (btn.DataContext is Pizza PT)
                {
                    if (PT.Toppings.Count > 0)
                    {
                        var ViewModel = new ToppingViewModel();
                        //Orders order = new Orders();

                        int pID = 0;
                        int.TryParse(btn.Tag.ToString(), out pID);

                        customTopping = new ToppingsWindow(dal.Pizzas[pID - 1], mw.viewModel.FullPris, ViewModel/* order*/);
                        customTopping.ShowDialog();

                        mw.viewModel.FullPris += dal.Pizzas[pID - 1].BasePris;
                        for (int i = 0; i < customTopping.ToppingviewModel.ExtraTops.Count; i++) //Adds the price of items in Order, to FullPrice.
                        {
                            mw.viewModel.FullPris += customTopping.ToppingviewModel.ExtraTops[i].Toppings_Pris;
                        }
                        //mw.viewModel.UpdateOrder(ViewModel.selected);
                    }
                }
                for (int i = 0; i < lbMeny.Items.Count; i++) //Runs through every item in the listbox
                {
                    Pizza o = (Pizza)btn.DataContext;
                    if (o != null)
                    {

                        if (btn.Tag.ToString() == (i + 1).ToString())
                        { //checks if the btn tag is the same as i+1 making sure its the corrct item
                            var tmp = lbMeny.Items[i]; //places the correct item in tmp
                                                       //Gets a refrence to mainwindow
                            if (mw != null) //Checks if mainwindow isn't empty
                            {
                                Pizza p = (Pizza)tmp; //Makes tmp to a pizza object
                                                      //Creates the output string

                                string tempTop = ""; // string to put topping in temp
                                double newPris = 0;
                                foreach (var top in p.Toppings) // evrey var(variabel) in toppingsPizza go loop
                                {
                                    tempTop += top.Navn + ", "; // this(+=)mean add name from topping class to temp  
                                    if (customTopping.ToppingviewModel.ExtraTops.Contains(top))
                                    {
                                        newPris += top.Toppings_Pris;
                                    }
                                }

                                newPris += p.BasePris;
                                string item = $"{p.ID} {p.Navn} \n" + $"{tempTop}, \n" + $"{newPris} Kr.";

                                ////button
                                //Button btnk = new Button(); // create new button
                                //btnk.Content = item; // give a name to the button by the content 
                                //btnk.Click += new RoutedEventHandler(KurvItem_Click);// create click event for the button
                                mw.viewModel.AddToOrderPizza(o);//add Pizza to ViewModel on MainWindowViewModel

                                mw.lbkurv.Items.Add(item); //adds the string to kurv listbox                             

                                break;
                            }

                        }
                    }

                }
            }
        }


        private void btnSlet_Click_1(object sender, RoutedEventArgs e)
        {
            //    while (mw.lbkurv.SelectedItems.Count > 0)
            //    {
            //        mw.lbkurv.Items.RemoveAt(mw.lbkurv.SelectedIndex);
            //    }           
            Button btn = (Button)sender; // sender is the button pressed
            if (btn != null) //if btn is not empty
            {

                for (int i = 0; i < lbMeny.Items.Count; i++) //Runs through every item in the listbox
                {
                    if (btn.Tag.ToString() == (i + 1).ToString())
                    { //checks if the btn tag is the same as i+1 making sure its the corrct item
                        var tmp = lbMeny.Items[i]; //places the correct item in tmp
                                                   //Gets a refrence to mainwindow
                        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);

                        if (mw != null) //Checks if mainwindow isn't empty
                        {
                            Pizza p = (Pizza)tmp; //Makes tmp to a pizza object
                            string tempTop = ""; // string to put topping in temp
                            foreach (var top in p.Toppings) // evrey var(variabel) in toppingsPizza go loop
                            {
                                tempTop += top.Navn + ", "; // this(+=)mean add name from topping class to temp  
                            }

                            string item = $"{p.ID} {p.Navn} \n" + $"{tempTop}, \n" + $"{p.BasePris} Kr.";
                            mw.lbkurv.Items.Remove(item); //adds the remove from kurv listbox

                        }
                    }

                }                //Debug.WriteLine("HELLO WORLD!!!");




            }
        }
    }
}
//Orders o = (Orders)btn.DataContext;
//               if (o != null)
//               {
//                   viewModel.RemoveFromOrder(o);
//                   viewModel.FullPrice = 0;
//                   for (int i = 0; i < viewModel.VM_OrdersDataBase.Count; i++) //Looks at 
//                   {
//                       viewModel.FullPrice += viewModel.VM_OrdersDataBase[i].Pris;
//                   }
//               }