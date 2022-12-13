using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Conference : Event
    {
        //Attributi

        public string Speaker { get; set; }

        public double Price { get; set; }

        //------------ Costruttori ------------ //

        public Conference(string Title, string Date, int MaxCapacity, string Speaker, double Price) : base (Title, Date, MaxCapacity)
        {
            this.Title = Title;
            this.Date = DateTime.Parse(Date);

            if (MaxCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capienza massima (deve essere un numero positivo)");  //Eccezione nel caso in cui il numero di posti non è un numero positivo
            }
            this.MaxCapacity = MaxCapacity;
            this.Speaker = Speaker;
            this.Price = Price;
        }

        public Conference() : base()
        {
            //Sanificazione dell'input dell'utente

            bool TitleSanification = false;
            Console.Write("Inserisca il nome della conferenza: ");
            do
            {
                string? InputTitle = Console.ReadLine();

                if (InputTitle == "")
                {
                    Console.Write("Il titolo da lei inserito è vuoto, per favore inserisca un titolo valido: ");
                }
                else
                {
                    this.Title = InputTitle;
                    TitleSanification = true;
                }
            } while (TitleSanification == false);

            bool DateSanification = false;
            Console.Write("Inserisca la data della conferenza (gg/mm/yyyy): ");
            do
            {
                string? InputDate = Console.ReadLine();
                if (DateTime.TryParse(InputDate, out DateTime result) == false)
                {
                    Console.Write("La data da lei inserita è invalida, inserisca la data nel formato (gg/dd/yyyy): ");
                }
                else
                {
                    this.Date = DateTime.Parse(InputDate);
                    DateSanification = true;
                }
            } while (DateSanification == false);

            bool MaxCapacitySanification = false;
            int InputMaxCapacity;
            Console.Write("Inserisca il numero di posti totali: ");

            do
            {
                string? StringMaxCapacity = Console.ReadLine();

                if ((int.TryParse(StringMaxCapacity, out InputMaxCapacity) == false) || InputMaxCapacity <= 0)
                {
                    Console.Write("Il numero da lei inserito non è valido, per favore reinserisca il numero massimo di posti: ");
                }
                else
                {
                    this.MaxCapacity = InputMaxCapacity;
                    MaxCapacitySanification = true;
                }

            } while (MaxCapacitySanification == false);

            bool SpeakerSanification = false;
            Console.Write("Inserisca il nome del relatore della conferenza: ");
            do
            {
                string? InputSpeaker = Console.ReadLine();

                if (InputSpeaker == "")
                {
                    Console.Write("Il nome del relatore da lei inserito è vuoto, per favore inserisca un nome valido: ");
                }
                else
                {
                    this.Speaker = InputSpeaker;
                    SpeakerSanification = true;
                }
            } while (SpeakerSanification == false);

            bool PriceSanification = false;
            double InputPrice;
            Console.Write("Inserisca il prezzo del biglietto della conferenza: ");

            do
            {
                string? StringPrice = Console.ReadLine();
                StringPrice = StringPrice.Replace(".", ",");

                if ((double.TryParse(StringPrice, out InputPrice) == false) || InputPrice < 0)
                {
                    Console.Write("Il numero da lei inserito non è valido, per favore reinserisca un prezzo valido: ");
                }
                else
                {   
                    InputPrice = double.Parse(StringPrice);
                    InputPrice = Math.Round(InputPrice, 2);
                    this.Price = InputPrice;
                    PriceSanification = true;
                }

            } while (PriceSanification == false);
        }

        //---------- Definizioni dei metodi ----------//

        //Metodo che ritorna il prezzo formattato correttamente

        public static string FormattedPrice(double price)
        {
            string Formatted_Price = price.ToString("0.00");
            return Formatted_Price;
        }

        //Ovverride del metodo ToString, in modo che vegna restituita una stringa con le informazioni della conferenza

        public override string ToString()
        {
            return (this.Date.ToString("d") + " - " + this.Title + " - " + this.Speaker+ " - " + FormattedPrice(this.Price) + " euro");
        }
    }
}
