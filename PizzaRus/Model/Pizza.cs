using AW.WPF.Essentials.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media;

namespace PizzaRus
{
    public class Pizza
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string Navn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Navn));
            }
        }
       
        public int ID { get; set; }
        public string Navn { get; set; }
        public ObservableCollection<Toppings> Toppings { get; private set; }

        public double BasePris { get; set; }
     

        public Pizza(int ID,  string Navn, double BasePris, ObservableCollection<Toppings> Toppings)
        {
            this.ID = ID;
            this.Navn = Navn;
            this.BasePris = BasePris;
            this.Toppings=Toppings;


        }
        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Navn)); //Linq
            }
        }



    }  
}

