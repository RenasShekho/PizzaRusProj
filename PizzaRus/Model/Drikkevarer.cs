using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus.Model
{
    public class Drikkevarer
    {
        public int ID { get;  set; }
        public string Navn { get;  set; }
        public double drikkePris { get;  set; }

        public Drikkevarer(int ID,  string Navn, double drikkePris)
        {
           this. ID = ID;
           this.Navn = Navn;
            this.drikkePris = drikkePris;
        }

    }
}
