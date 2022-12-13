using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Event
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

        private DateTime _DateValue;
        public DateTime Date
        {
            get
            {
                return _DateValue;
            }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new PassedDateException("La data inserita è già passata.");       //Eccezione nel caso in cui la data inserita sia già passata
                }
                else
                {
                    _DateValue = value;
                }
            }

        }

        public int MaxCapacity { get; }

        public int BookedSeats { get; private set; }

        //------------ Costruttori ------------ //

        //Questo costruttore viene utilizzato per creare un evento generico
        public Event()
        {
            //Sanificazione dell'input dell'utente

            bool NameSanification = false;
            Console.Write("Inserisca il nome dell'evento: ");
            do
            {
                string? InputTitle = Console.ReadLine();

                if (InputTitle == "")
                {
                    Console.Write("Il titolo da lei inserito è vuoto, per favore inserisca un titolo valido: ");
                } else
                {
                    this.Title = InputTitle;
                    NameSanification = true;
                }
            } while (NameSanification == false);

            bool DateSanification = false;
            Console.Write("Inserisca la data dell'evento (gg/mm/yyyy): ");
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

            bool BookedSeatsSanification = false;
            int InputBookedSeats;
            Console.Write("Quanti posti desidera prenotare? ");

            do
            {
                string? StringBookedSeats = Console.ReadLine();

                if ((int.TryParse(StringBookedSeats, out InputBookedSeats) == false) || InputBookedSeats > this.MaxCapacity || InputBookedSeats < 0) 
                {
                    Console.Write("Il numero dei posti che lei desidera prenotare è invalido, per favore reinserisca il numero di post da prenotare: ");
                }
                else
                {
                    Console.WriteLine();
                    this.BookedSeats += InputBookedSeats;
                    BookedSeatsSanification = true;
                }
            } while (BookedSeatsSanification == false);
        }

        //Questo costruttore invece, viene utilizzato nella creazione di un nuovo programma di eventi, ergo il "i", che servirà a contare gli eventi
        public Event(int i)
        {
            //Sanificazione dell'input dell'utente

            bool NameSanification = false;
            Console.Write("Inserisca il nome del " + i + "º evento: ");
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
                    NameSanification = true;
                }
            } while (NameSanification == false);

            bool DateSanification = false;
            Console.Write("Inserisca la data dell'evento (gg/mm/yyyy): ");
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
            Console.WriteLine();
        }

        public Event(string Title, string Date, int MaxCapacity)
        {
            this.Title = Title;
            this.Date = DateTime.Parse(Date);

            if (MaxCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException("Capienza massima (deve essere un numero positivo)");  //Eccezione nel caso in cui il numero di posti non è un numero positivo
            }
            this.MaxCapacity = MaxCapacity;
            this.BookedSeats = 0;
        }

        //---------- Definizioni dei metodi ----------//

        //Metodo che permette di prenotare i posti per l'evento
        public void BookSeats(int SeatsToBook)
        {
            if (this.Date < DateTime.Now)
            {
                throw new PassedDateException("L'evento che lei desidera prenotare è già passato.");        //Eccezione nel caso in cui l'evento sia già passato
            }
            if (SeatsToBook > (this.MaxCapacity - this.BookedSeats))
            {
                throw new InsufficientSeatsException("L'evento non ha abbastanza posti disponibili per prenotare il numero di posti da lei desiderato.");  //Eccezione nel caso in cui i posti disponibili non sono abbastanza
            }
            else
            {
                this.BookedSeats += SeatsToBook;
            }
        }

        //Metodo che permette di disdire i posti prenotati per l'evento
        public void CancelSeats(int SeatsToCancel)
        {
            if (this.Date < DateTime.Now)
            {
                throw new PassedDateException("L'evento che lei desidera prenotare è già passato.");        //Eccezione nel caso in cui l'evento sia già passato
            }
            if (SeatsToCancel > this.BookedSeats)
            {
                throw new InsufficientSeatsException("L'evento non ha abbastanza posti prenotati per disdire il numero di posti da lei desiderato.");  //Eccezione nel caso in cui i posti disponibili non sono abbastanza
            }
            else
            {
                this.BookedSeats -= SeatsToCancel;
            }
        }

        //Metodo che restituisce una stringa con le informazioni dell'evento

        public override string ToString()
        {
            return (this.Date.ToString("d") + " - " + this.Title);
        }

        //Metodo che stampa a video il numero di posti prenotati e quelli disponibili

        public void SeatsPrint()
        {
            Console.WriteLine("Numero di posti prenotati: " + this.BookedSeats);
            Console.WriteLine("Numero di posti disponibili: " + (this.MaxCapacity - this.BookedSeats));
            Console.WriteLine();
        }

        //Metodo che, su richiesta dell'utente, disdice i posti

        public void AskCancelSeats()
        {
            bool UserContinue = true;
            do
            {
                Console.Write("Desidera disdire dei posti (sì/no)? ");

                //Sanificazione input dell'utente

                bool InputSanification = false;
                string StringInput;
                do
                {
                    StringInput = Console.ReadLine();
                    StringInput.ToLower();
                    StringInput.Replace("ì", "i");

                    if (StringInput != "si" && StringInput != "s" && StringInput != "no" && StringInput != "n")
                    {
                        Console.Write("Per favore, inserisca (si/no): ");
                    }
                    else
                    {
                        InputSanification = true;
                    }

                } while (InputSanification == false);

                if (StringInput == "no" || StringInput == "n")
                {
                    Console.WriteLine("I posti non verranno disdetti");
                    Console.WriteLine();
                    UserContinue = false;
                }
                if (StringInput == "si" || StringInput == "s")
                {
                    Console.Write("Quanti posti desidera disdire? ");

                    bool CancelSeatsSanification = false;
                    int InputCancelSeats;

                    do
                    {
                        string? StringCancelSeats = Console.ReadLine();

                        if ((int.TryParse(StringCancelSeats, out InputCancelSeats) == false) || InputCancelSeats > this.BookedSeats || InputCancelSeats < 0)
                        {
                            Console.Write("Il numero dei posti che lei desidera disdire è invalido, per favore reinserisca il numero di posti da disdire: ");
                        }
                        else
                        {
                            Console.WriteLine();
                            this.BookedSeats -= InputCancelSeats;
                            CancelSeatsSanification = true;
                        }
                    } while (CancelSeatsSanification == false);
                }

                Console.WriteLine("Numero di posti prenotati: " + this.BookedSeats);
                Console.WriteLine("Numero di posti disponibili: " + (this.MaxCapacity - this.BookedSeats));
                Console.WriteLine();

            } while (UserContinue == true);
        }

        //---------- Definizioni delle eccezioni ----------//

        //Eccezione personalizzata in caso di data passata

        internal class PassedDateException : Exception
        {
            public PassedDateException() { }

            public PassedDateException(string message) : base(message) { }
        }

        //Eccezione personalizzata in caso di titolo vuoto

        internal class EmptyTitleException : Exception
        {
            public EmptyTitleException() { }

            public EmptyTitleException(string message) : base(message) { }
        }

        //Eccezione personalizzata nel caso in cui i posti non bastino per la prenotazione/cancellazione dell'utente
        internal class InsufficientSeatsException : Exception
        {
            public InsufficientSeatsException() { }

            public InsufficientSeatsException(string message) : base(message) { }
        }
    }
}
