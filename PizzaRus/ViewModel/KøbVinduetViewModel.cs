using Newtonsoft.Json;
using PizzaRus.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PizzaRus.ViewModel
{
    public class KøbVinduetViewModel : INotifyPropertyChanged
    {
          public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Orders> Orders { get; set; } = new();
        public double fullprice { get; set; }

        public void OrdersJson()
        {
            var PizzaJson = JsonConvert.SerializeObject(Orders, Formatting.Indented);
            File.WriteAllText("Orders.json", PizzaJson);
        }
    }
}
