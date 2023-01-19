using PizzaRus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus.ViewModel
{
    public class ToppingViewModel : INotifyPropertyChanged
    {
        readonly DAL dal = new DAL();
        public ObservableCollection<Pizza> pizzas { get; set; } = new();
        public ObservableCollection<Toppings> Topping { get; set; } = new();
        public ObservableCollection<Toppings> OriTops { get; set; } = new();
        public ObservableCollection<Toppings> ExtraTops { get; set; } = new();


        //List<string> Navn = new List<string>();

        public Orders fortryd;

        private Orders Selected;
        public Orders selected //Shows the selected pizzas' topping
        {
            get
            {
                return Selected;
            }
            set
            {
                Selected = value;
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
        public ToppingViewModel()
        {
            Topping = dal.GetToppings();
        }

        public void RemovePresetToppings()
        {

            var toppingToRemove = new HashSet<Toppings>();

            foreach (var topping in Topping)
            {
                if (OriTops.Any(t => t.ID.Equals(topping.ID)))
                    toppingToRemove.Add(topping);
            }

            foreach (var topping in toppingToRemove)
            {
                Topping.Remove(topping);
            }
        }

        public void AddTopping(Toppings SelectedTopping) //Removes Toppings from left side(Not on pizza) to right side (On pizza)
        {

            Topping.Remove(SelectedTopping);
            OriTops.Add(SelectedTopping);
            ExtraTops.Add(SelectedTopping);
            //selected.Pris += SelectedTopping.Toppings_Pris;
        }
        public void RemoveTopping(Toppings SelectedTopping) //Adds Topping selected from right side (On pizza), to left side (Not on pizza)
        {

            if(OriTops.Count > 1)
            {
               OriTops.Remove(SelectedTopping);
               ExtraTops.Remove(SelectedTopping);
                Topping.Add(SelectedTopping);
                //selected.Pris -= SelectedTopping.Toppings_Pris;
            }

        }
        public void Fortryd()
        {
            selected = fortryd;
        }
    }
}

