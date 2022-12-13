﻿//Consegna: Creare un gestore eventi per eventi come concerti, conferenze e spettacoli.
//Senza interfaccia grafica, il gestore si deve occupare di:
// - Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato
// - Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia
//   quindi dei posti prenotati e di quelli disponibili per un dato evento
// - Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi
//   che afferiscono ad serie di Conferenze)

using GestoreEventi;

try
{
    Event Sagra = new Event("Sagra della polpetta", "14/12/2022", 10);

    Console.WriteLine(Sagra.ToString());

    Sagra.BookSeats(2);
    Sagra.CancelSeats(3);










}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}