using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class EventSchedule
    {
        //Attributi

        private string? _TitleValue;
        public string Title
        {
            get
            {
                return _TitleValue;
            }
            set
            {
                if (value == "")
                {
                    throw new EmptyTitleException("Il titolo è vuoto.");                    //Eccezione in caso di titolo vuoto
                }
                else
                {
                    _TitleValue = value;
                }
            }

        }

        public List<Event> Events { get; set; }

        //------------ Costruttori ------------ //

        public EventSchedule(string title)
        {
            this.Title = title;
            this.Events = new List<Event>();
        }

        public EventSchedule()
        {
            //Sanificazione dell'input dell'utente

            bool TitleSanification = false;
            Console.Write("Inserisca il nome del vostro programma eventi: ");
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

            int count = 0;
            bool CountSanification = false;
            Console.Write("Inserisca il numero di eventi da inserire: ");
            do
            {
                string? StringCount = Console.ReadLine();

                if ((int.TryParse(StringCount, out count) == false) || count <= 0)
                {
                    Console.Write("Il numero di eventi deve essere maggiore di 0, inserisca un numero di eventi valido: ");
                }
                else
                {
                    CountSanification = true;
                }
            Console.WriteLine();

            } while (CountSanification == false);

            this.Events = new List<Event>();
            for (int i = 1; i <= count; i++)
            {
                Event Event = new Event(i);
                this.Events.Add(Event);
            }
        }



        //---------- Definizioni dei metodi ----------//

        //Metodo che aggiunge alla lista del programma eventi un evento
        public void Add(Event GenericEvent)
        {
            this.Events.Add(GenericEvent);
        }

        //Metodo che restituisce a video una lista di eventi di una certa data
        public void DateCheck()
        {
            //Nel caso in cui non viene trovato nemmeno un evento, verrà stampato un messaggio unico che comunica l'assenza di eventi in quel determinato giorno
            bool found = false;
            string? StringDate;
            bool DateSanification = false;
            Console.Write("Inserisca una data per scoprire quali eventi si terrano quel giorno (gg/mm/yyyy): ");
            do
            {
                StringDate = Console.ReadLine();
                if (DateTime.TryParse(StringDate, out DateTime result) == false)
                {
                    Console.Write("La data da lei inserita è invalida, inserisca la data nel formato (gg/dd/yyyy): ");
                }
                else
                {
                    DateSanification = true;
                }
            } while (DateSanification == false);

            DateTime DateCheck = DateTime.Parse(StringDate);
            Console.WriteLine("Gli eventi che si terranno il " + DateCheck.ToString("d") + " sono:");

            foreach (Event Event in this.Events)
            {
                if (Event.Date == DateCheck)
                {
                    found = true;                               //Se invece almeno un evento viene trovato, il messaggio dell'assenza di eventi non verrà scritto
                    Console.WriteLine("\t" + Event.ToString());
                }
            }

            if (!found)
            {
                Console.WriteLine("Ci dispiace, in questo giorno non sarà tenuto alcun evento");
            }
            Console.WriteLine();
        }

        //Metodo statico che si occupa di stampare a video una lista eventi

        public static void PrintEvents(List<Event> Events)
        {
            Console.WriteLine("Gli eventi in questa lista sono i seguenti:");
            foreach (Event Event in Events)
            {
                Console.WriteLine(Event.Title);
            }
            Console.WriteLine();
        }

        //Metodo che restituisce il numero di eventi presenti nel programma attualmente

        public void EventsCount()
        {
            int count = 0;
            foreach (Event Event in this.Events)
            {
                count++;
            }
            Console.WriteLine("Il numero degli eventi è: " + count);
            Console.WriteLine();
        }

        //Metodo che svuota la lista degli eventi

        public void CancelList()
        {
            this.Events.Clear();
        }

        //Metodo che restituisce una stringa che mostra il titolo del programma e tutti gli eventi aggiunti alla lista

        public void Print()
        {
            Console.WriteLine("-------- " + this.Title + " --------");
            Console.WriteLine();

            foreach (Event Event in this.Events)
            {
                Console.WriteLine("\t" + Event.ToString());
            }
            Console.WriteLine();
        }

        //---------- Definizioni delle eccezioni ----------//

        //Eccezione personalizzata in caso di titolo vuoto

        internal class EmptyTitleException : Exception
        {
            public EmptyTitleException() { }

            public EmptyTitleException(string message) : base(message) { }
        }
    }
}
