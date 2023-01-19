﻿using PizzaRus.Model;
using PizzaRus.ViewModel;
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

namespace PizzaRus.view
{
    /// <summary>
    /// Interaction logic for DrikkevarerPage.xaml
    /// </summary>
    public partial class DrikkevarerPage : Page
    {
        readonly MainWindowViewModel viewModel = new();

        DAL dal;
        public DrikkevarerPage(DAL dal)
        {
            InitializeComponent();
            this.dal = dal; 
        }

        private void btnSlet_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender; // sender is the button pressed
            if (btn != null) //if btn is not empty
            {
                for (int i = 0; i < lbDrikkevarer.Items.Count; i++) //Runs through every item in the listbox
                {
                    if (btn.Tag.ToString() == (i + 1).ToString())
                    { //checks if the btn tag is the same as i+1 making sure its the corrct item
                        var tmp = lbDrikkevarer.Items[i]; //places the correct item in tmp
                                                       //Gets a refrence to mainwindow
                        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);

                        if (mw != null) //Checks if mainwindow isn't empty
                        {
                            Drikkevarer D = (Drikkevarer)tmp; //Makes tmp to a pizza object
                                                        //Creates the output string
                            string item = $"{D.ID} {D.Navn} \n" /*+ $"{t.Beskrivelse}, \n"*/ + $"{D.drikkePris}";
                            mw.lbkurv.Items.Remove(item); //adds the remove from kurv listbox
                        }
                    }
                }
            }
        }

        private void btnTilføj1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender; // sender is the button pressed
            if (btn != null) //if btn is not empty
            {
                Drikkevarer o = (Drikkevarer)btn.DataContext;
                if (o != null)
                {
                    viewModel.AddToOrderDrinks(o);
                }
                for (int i = 0; i < lbDrikkevarer.Items.Count; i++) //Runs through every item in the listbox
                {
                    if (btn.Tag.ToString() == (i + 1).ToString())
                    { //checks if the btn tag is the same as i+1 making sure its the corrct item
                        var tmp = lbDrikkevarer.Items[i]; //places the correct item in tmp
                        //Gets a refrence to mainwindow
                        MainWindow mw = (MainWindow)Window.GetWindow(App.Current.MainWindow);
                        if (mw != null) //Checks if mainwindow isn't empty
                        {
                            Drikkevarer D = (Drikkevarer)tmp; //Makes tmp to a tilbehør object
                            //Creates the output string
                            string item = $"{D.ID} {D.Navn} \n" +
                                          $"{D.drikkePris}";
                            //button
                            Button btnk = new Button(); // create new button
                            btnk.Content = item; // give a name to the button by the content 

                            mw.lbkurv.Items.Add(item); //adds the string to kurv listbox                             
                        }
                    }
                }
            }
            Button b = (Button)sender;
            if (b != null)
            {
                Drikkevarer D = (Drikkevarer)b.DataContext;
                if (D != null)
                {
                    //dal._kurv2.Add(t);

                }


            }
        }
    }
}
