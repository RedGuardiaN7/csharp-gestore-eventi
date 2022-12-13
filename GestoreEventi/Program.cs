//Consegna: Creare un gestore eventi per eventi come concerti, conferenze e spettacoli.
//Senza interfaccia grafica, il gestore si deve occupare di:
// - Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato
// - Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia
//   quindi dei posti prenotati e di quelli disponibili per un dato evento
// - Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi
//   che afferiscono ad serie di Conferenze)

using GestoreEventi;

try
{
    Event Event_1 = new Event();

    Console.WriteLine(Event_1.ToString());

    Event_1.BookSeats(2);








}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}