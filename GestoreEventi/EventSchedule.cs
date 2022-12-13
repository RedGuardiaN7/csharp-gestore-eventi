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

        public string Title { get; set; }

        public List<Event> Events { get; set; }

        //------------ Costruttore ------------ //

        public EventSchedule(string title)
        {
            this.Title = title;
            this.Events = new List<Event>();
        }

        //---------- Definizioni dei metodi ----------//

        //Metodo che aggiunge alla lista del programma eventi un evento
        public void Add(Event GenericEvent)
        {
            this.Events.Add(GenericEvent);
        }

        //Metodo che restituisce a video una lista di eventi di una certa data
        public void DateCheck(string StringDate)
        {
            //Nel caso in cui non viene trovato nemmeno un evento, verrà stampato un messaggio unico che comunica l'assenza di eventi in quel determinato giorno
            bool found = false;

            DateTime DateCheck = DateTime.Parse(StringDate);
            Console.WriteLine("Gli eventi che si terranno il " + DateCheck.ToString("d") + " sono:");

            foreach (Event Event in this.Events)
            {
                if (Event.Date == DateCheck)
                {
                    found = true;                            //Se invece almeno un evento viene trovato, il messaggio dell'assenza di eventi non verrà scritto
                    Console.WriteLine(Event.Title);
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

        public int EventsCount()
        {
            int count = 0;
            foreach (Event Event in this.Events)
            {
                count++;
            }
            return count;
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
    }
}
