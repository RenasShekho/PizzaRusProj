using PizzaRus;
using PizzaRus.Model;
using PizzaRus.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace PizzaRus
{

    public class DAL
    {

        private ObservableCollection<Pizza> PizzaDataBase;
        private ObservableCollection<Pizza> _PizzapublicListe;
        //-----------------------------------------------------------------

        private ObservableCollection<Drikkevarer> DrikkevarerDataBase;
        private ObservableCollection<Drikkevarer> _DrikkevarerpublicListe;
        //-----------------------------------------------------------------

        private ObservableCollection<Toppings> ToppingDataBase;
        private ObservableCollection<Toppings> _ToppingpublicListe;

        //-----------------------------------------------------------------

        private ObservableCollection<Tilbehør> DataBaseTilbehør;
        private ObservableCollection<Tilbehør> _publicListeTilbehør;
        //-----------------------------------------------------------------

        public ObservableCollection<Pizza> Pizzas { get; set; } = new ObservableCollection<Pizza>();
        //-----------------------------------------------------------------
        public ObservableCollection<Drikkevarer> Drikkevarers { get; set; } = new ObservableCollection<Drikkevarer>();
        //-----------------------------------------------------------------
        public ObservableCollection<Tilbehør> Tilbehøre { get; set; } = new ObservableCollection<Tilbehør>();
        //-----------------------------------------------------------------
        public ObservableCollection<Toppings> Topping { get; set; } = new ObservableCollection<Toppings>();
        //-----------------------------------------------------------------
     

        public DAL()
        {


            PizzaDataBase = new ObservableCollection<Pizza>();
            _PizzapublicListe = new ObservableCollection<Pizza>(PizzaDataBase);
            //-----------------------------------------------------------------

            //-----------------------------------------------------------------

            DrikkevarerDataBase = new ObservableCollection<Drikkevarer>();
            _DrikkevarerpublicListe = new ObservableCollection<Drikkevarer>(DrikkevarerDataBase);
            //-----------------------------------------------------------------
            
            ToppingDataBase = new ObservableCollection<Toppings>();
            _ToppingpublicListe = new ObservableCollection<Toppings>(ToppingDataBase);
            //-----------------------------------------------------------------
            DataBaseTilbehør = new ObservableCollection<Tilbehør>();
            _publicListeTilbehør = new ObservableCollection<Tilbehør>(DataBaseTilbehør);
            //-----------------------------------------------------------------

            // I need to uncomment the "jsonfil()" when i edit somthing from observabelcollection Pizza Tilbehøre og toppings.
            //JsonFile();
            string PizzaJson = File.ReadAllText("Pizza.json");
            var piz = JsonConvert.DeserializeObject<ObservableCollection<Pizza>> (PizzaJson);
            Pizzas = new ObservableCollection<Pizza>(piz);
            //-----------------------------------------------------------------

            string TilbehøreJson = File.ReadAllText("Tilbehøre.json");
            var til = JsonConvert.DeserializeObject<ObservableCollection<Tilbehør>>(TilbehøreJson);
            Tilbehøre = new ObservableCollection<Tilbehør>(til);
            //-----------------------------------------------------------------

            string ToppingsJson = File.ReadAllText("Topping.json");
            var Top = JsonConvert.DeserializeObject<ObservableCollection<Toppings>> (ToppingsJson);
            Topping = new ObservableCollection<Toppings>(Top);
            //-----------------------------------------------------------------

        }

        public void JsonFile()
        {


            Tilbehøre.Add(new Tilbehør(1, " Doritos Chips","170 g.", 25));
            Tilbehøre.Add(new Tilbehør(2, " Snickers","50 g.", 15));
            Tilbehøre.Add(new Tilbehør(3, " Snickers","5 stk.", 60));
            Tilbehøre.Add(new Tilbehør(4, " Oreo","154 g.", 25));
            Tilbehøre.Add(new Tilbehør(5, " Marabou Mælkechokolade", "200 g.", 45));

            var TilbehøreJson = JsonConvert.SerializeObject(Tilbehøre, Formatting.Indented);
            File.WriteAllText("Tilbehøre.json", TilbehøreJson);
            //-----------------------------------------------------------------

            Drikkevarers.Add(new Drikkevarer(1, " CocaCola", 30));
            Drikkevarers.Add(new Drikkevarer(2, " Fanta", 30));
            Drikkevarers.Add(new Drikkevarer(3, " Pepsi", 30));
            Drikkevarers.Add(new Drikkevarer(4, " Pepsi Max", 30));
            Drikkevarers.Add(new Drikkevarer(5, " CocaCola Zero", 30));

            var DrikkevarerJson = JsonConvert.SerializeObject(Drikkevarers, Formatting.Indented);
            File.WriteAllText("Drikkevarer.json", DrikkevarerJson);
            //-----------------------------------------------------------------

            Topping.Add(new Toppings(0, "Tomatsauce", 0));
            Topping.Add(new Toppings(1, "Ost", 9));
            Topping.Add(new Toppings(2, "Oregano", 0));
            Topping.Add(new Toppings(3, "Kebab", 9));
            Topping.Add(new Toppings(4, "Pepperoni", 9));
            Topping.Add(new Toppings(5, "Løg", 4.50));
            Topping.Add(new Toppings(6, "Champignon", 4.50));
            Topping.Add(new Toppings(7, "Jalapenos", 4.50));
            Topping.Add(new Toppings(8, "Dressing", 4.50));
            Topping.Add(new Toppings(9, "Skinke", 9));
            Topping.Add(new Toppings(10, "Oksekød", 9));
            Topping.Add(new Toppings(11, "Kylling", 9));
            Topping.Add(new Toppings(12, "Pølser", 9));
            Topping.Add(new Toppings(13, "Bacon", 9));
            Topping.Add(new Toppings(14, "Peberfrugt", 4.50));
            Topping.Add(new Toppings(15, "Oliven", 4.50));
            Topping.Add(new Toppings(16, "Pommes Frites", 4.50));
            Topping.Add(new Toppings(17, "Bearnaisesauce", 4.50));
            Topping.Add(new Toppings(18, "Italiensk Salami", 4.50));
            Topping.Add(new Toppings(19, "Ananas", 4.50));
            Topping.Add(new Toppings(20, "Karrydressing", 4.50));

            var ToppingJson = JsonConvert.SerializeObject(Topping, Formatting.Indented);
            File.WriteAllText("Topping.json", ToppingJson);
            //-----------------------------------------------------------------
            Pizzas.Add(new Pizza(1, "Margherita", 60, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[2] }));
            Pizzas.Add(new Pizza(2, "Pizza La Pappas",77, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[3], Topping[4], Topping[5], Topping[6], Topping[2] }));
            Pizzas.Add(new Pizza(3, "Viking",77, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[3], Topping[5] }));
            Pizzas.Add(new Pizza(4, "Meat Lovers",93, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[9], Topping[10], Topping[11], Topping[4], Topping[12], Topping[13] }));
            Pizzas.Add(new Pizza(5, "Pepperoni",70, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[4], Topping[2] }));
            Pizzas.Add(new Pizza(6, "Aalborg",77, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[3], Topping[10], Topping[5], Topping[14], Topping[2] }));
            Pizzas.Add(new Pizza(7, "Hawaii",75, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[19], Topping[2] }));
            Pizzas.Add(new Pizza(8, "Vesterbro",79, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[9], Topping[10], Topping[12], Topping[2], Topping[6] }));
            Pizzas.Add(new Pizza(9, "Brønderslev",79, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[10], Topping[12], Topping[15], Topping[2], Topping[13] }));
            Pizzas.Add(new Pizza(10, "Sicilia",79, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[9], Topping[10], Topping[12], Topping[2], Topping[15], Topping[13] }));
            Pizzas.Add(new Pizza(11, "Sondos Pizza",75, new ObservableCollection<Toppings> { Topping[0], Topping[1], Topping[4], Topping[9], Topping[8], Topping[2] }));

            var PizzaJson = JsonConvert.SerializeObject(Pizzas, Formatting.Indented);
            File.WriteAllText("Pizza.json", PizzaJson);
            //-----------------------------------------------------------------

        }




        public ObservableCollection<Pizza> GetPizza()
        {
            _PizzapublicListe.Clear();
            foreach (Pizza p in PizzaDataBase)
            {
                _PizzapublicListe.Add(p);
            }
            return _PizzapublicListe;
        }
        //public void Commit()
        //{
        //    PizzaDataBase = new ObservableCollection<Pizza>(_PizzapublicListe);
        //}
        //-----------------------------------------------------------------
        public ObservableCollection<Toppings> GetToppings()
        {
            _ToppingpublicListe.Clear();
            foreach (Toppings to in Topping)
            {
                _ToppingpublicListe.Add(to);
            }
            return _ToppingpublicListe;
        }
        public void CommitTopping()
        {
            ToppingDataBase = new ObservableCollection<Toppings>(_ToppingpublicListe);
        }
        //-----------------------------------------------------------------
        public ObservableCollection<Drikkevarer> GetDrikkevarer()
        {
            _DrikkevarerpublicListe.Clear();
            foreach (Drikkevarer d in DrikkevarerDataBase)
            {
                _DrikkevarerpublicListe.Add(d);
            }
            return _DrikkevarerpublicListe;
        }
        public void CommitDrikkevarer()
        {
            DrikkevarerDataBase = new ObservableCollection<Drikkevarer>(_DrikkevarerpublicListe);
        }
        //-----------------------------------------------------------------


        public ObservableCollection<Tilbehør> GetTilbehøre()
        {
            _publicListeTilbehør.Clear();
            foreach (Tilbehør t in DataBaseTilbehør)
            {
                _publicListeTilbehør.Add(t);
            }
            return _publicListeTilbehør;
        }
        public void CommitTilbehøre()
        {
            DataBaseTilbehør = new ObservableCollection<Tilbehør>(_publicListeTilbehør);
        }
        //-----------------------------------------------------------------

      
    }
}

    

