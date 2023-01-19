using AW.WPF.Essentials.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRus
{
    public class Tilbehør 
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
        public string Beskrivelse { get; set; }
        public double BasePris { get; set; }    

        public Tilbehør(int ID, string Navn, string Beskrivelse, double BasePris)
        {
            this.ID = ID;
            this.Navn = Navn;
            this.Beskrivelse = Beskrivelse;
            this.BasePris = BasePris;
           
          
        }

    }
}
