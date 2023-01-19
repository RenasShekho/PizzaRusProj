using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus
{
    public class Toppings
    {

        public int ID { get; set; }

        public string Navn { get; set; }

        public double Toppings_Pris { get; set; }
  
        public Toppings(int ID, string Navn, double Toppings_Pris)
        {
            this.ID = ID;
            this.Navn = Navn;
            this.Toppings_Pris = Toppings_Pris;
        }
    } 
}
