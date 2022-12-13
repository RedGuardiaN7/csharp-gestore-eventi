//Consegna: Creare un gestore eventi per eventi come concerti, conferenze e spettacoli.
//Senza interfaccia grafica, il gestore si deve occupare di:
// - Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato
// - Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia
//   quindi dei posti prenotati e di quelli disponibili per un dato evento
// - Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi
//   che afferiscono ad serie di Conferenze)

using GestoreEventi;
using static GestoreEventi.EventSchedule;

try
{
    EventSchedule WinterFestival = new EventSchedule ("Winter Festival 2022");
    Event Event_1 = new Event("SnowFight", "14/12/2022", 200);
    Event Event_2 = new Event("Vin Brulè Party", "14/12/2022", 200);
    Event Event_3 = new Event("Secret Santa", "20/12/2022", 200);

    WinterFestival.Add (Event_1);
    WinterFestival.Add (Event_2);
    WinterFestival.Add(Event_3);

    WinterFestival.DateCheck("14/12/2022");

    WinterFestival.Print();





}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}