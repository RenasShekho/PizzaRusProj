using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Xml.Linq;

namespace PizzaRus.Model
{
    public class Orders : INotifyPropertyChanged
    {

        public int ID { get; private set; }
        public string Navn { get; private set; }

        private double _orderpris2;

        public double OrderPris
        {
            get
            {
                return _orderpris2;
            }
            set
            {
                _orderpris2 = value;
                OnPropertyChanged("Pris");
                OnPropertyChanged("ToppingsValues");
            }
        }
        private ObservableCollection<Toppings> toppings;
        public ObservableCollection<Toppings> Toppings
        {
            get
            {
                return toppings;
            }
            set
            {
                toppings = value;
                OnPropertyChanged("Toppings");
            }
        }
        public int OrderID { get; set; }


        public string ToppingsValues
        {
            get
            {
                return string.Join(", ", Toppings.Select(t => t.Navn)); //Linq
            }
        }

        public Orders(int ID, string Navn, double _OrderPris,  ObservableCollection<Toppings> Toppings, int OrderID)
        {
            this.ID = ID;
            this.Navn = Navn;
            this.OrderPris = _OrderPris;
            this.Toppings = Toppings;
            this.OrderID = OrderID;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }

        public Orders Copy()
        {
            return new Orders(ID, Navn, OrderPris,  new ObservableCollection<Toppings>(Toppings), OrderID);
        }
    }
}
