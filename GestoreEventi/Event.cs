using System;
using System.Collections.Generic;
using System.Linq;
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

        //------------ Costruttore ------------ //

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
