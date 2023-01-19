using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PizzaRus.Model;
using PizzaRus.Repositories;

namespace PizzaRus.ViewModel
{
    public class MainWindowViewModel : ViewModels, INotifyPropertyChanged
    {
        

        readonly DAL dal;
        private int OrderID;
        public ObservableCollection<Pizza> VM_PizzaDataBase { get; set; }
        public ObservableCollection<Drikkevarer> VM_DrinksDataBase { get; set; }
        public ObservableCollection<Tilbehør> VM_TilbehørDataBase { get; set; }
        public ObservableCollection<Orders> VM_OrdersDataBase { get; set; }
        public ListBox lb { get; set; }
        //------------------------------------------------

        //Full property for full full price
        private double _FullPris;

        public double FullPris
        {
            get
            {
                return _FullPris;
            }
            set
            {
                _FullPris = value;
                OnPropertyChanged("FullPris");
            }
        }
        //------------------------------------------------

        public void Slet()
        {
            lb.Items.Clear();
            VM_OrdersDataBase.Clear();
            FullPris = 0;
            
        }
        //------------------------------------------------

        public MainWindowViewModel()
        {
            dal = new DAL();
            VM_PizzaDataBase = dal.GetPizza();
            VM_DrinksDataBase = dal.GetDrikkevarer();
            VM_TilbehørDataBase = dal.GetTilbehøre();
            VM_OrdersDataBase = new ObservableCollection<Orders>();
        }
        //------------------------------------------------

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
        //------------------------------------------------

        public void UpdateOrder(Orders order)
        {
            var oldOrder = VM_OrdersDataBase.FirstOrDefault(o => o.OrderID.Equals(order.OrderID));
            if (oldOrder != null)
                VM_OrdersDataBase[VM_OrdersDataBase.IndexOf(oldOrder)] = order;
        }

        //------------------------------------------------
        public void AddToOrderPizza(Pizza pizza)
        {
            VM_OrdersDataBase.Add(new Orders(pizza.ID, pizza.Navn, pizza.BasePris,  new ObservableCollection<Toppings>(pizza.Toppings), OrderID++));
            //FullPris += pizza.BasePris;
        }
       

        public void AddToOrderTilbehør(Tilbehør tilbehør)
        {
            VM_OrdersDataBase.Add(new Orders(tilbehør.ID,  tilbehør.Navn, tilbehør.BasePris, new ObservableCollection<Toppings>(), OrderID++));
            FullPris += tilbehør.BasePris;
        }
        public void AddToOrderDrinks(Drikkevarer drikkevarer)
        {
            VM_OrdersDataBase.Add(new Orders(drikkevarer.ID, drikkevarer.Navn, drikkevarer.drikkePris, new ObservableCollection<Toppings>(), OrderID++));
            FullPris += drikkevarer.drikkePris;
        }
       

        public void RemoveFromOrder(Orders orders)
        {
            VM_OrdersDataBase.Remove(orders);
            FullPris -= orders.OrderPris;
        }
    }

    //Fields


    //public MainWindowViewModel()
    //{
    //    userRepository = new UserRepository();
    //    CurrentUserAccount = new UserAccountModel();
    //    LoadCurrentUserData();
    //}

    //private void LoadCurrentUserData()
    //{
    //    var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

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

