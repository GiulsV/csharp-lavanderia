﻿// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/*  3/11/22
 Lavanderia con 
    - 5 lavatrici
    - 5 ascigatrici
    - Costo gettoni: 0.5 cent * gettone
    - Capacità lavatrice: max 1 l detersivo
                          max 500 ml ammorbidente

    Programmi lavatrice:
        1) RINFRESCANTE: 
                costo: 2 gettoni
                tempo: 20 min
                consumo: 20 ml detersivo, 5 ml ammorbidente
        2) RINNOVANTE:
                costo: 3 gettoni
                tempo: 40 min
                consumo: 40 ml detersivo, 10 ml ammorbidente
        3) SGRASSANTE:
                costo: 4 gettoni
                tempo: 60 min
                cosumo: 60 ml detersivo, 15 ml ammorbidente
    Programmi asciugatrice:
        1)RAPIDO: 
            costo: 2 gettoni
            tempo: 30 min
        2)INTENSO: 
            costo: 4 gettoni
            tempo: 60 min                   
 */

/*  
 Sistema di controllo:
    1) Stato di utilizzo: elenco macchine che sono in funzione e ferme
    2) Dettaglio macchine: info nome, stato,tipo di lavaggio, qnt detersivo, durata lavaggio, tempo alla fine
    3) Incasso
 */

/*  08/11/22
 Oggi abbiamo introdotto due nuovi livelli di astrazione; Classi astratte ed Interfacce.
Riprendiamo quindi il vecchio progetto della lavanderia ed effettuiamo refactoring del codice cercando di applicare (dove possibile) i concetti visti:
Cosa può diventare astratto come classe?
Delle classi astratte identificate, potrebbero esserci metodi astratti?
Possiamo applicare qualche interfaccia? */



public class Lavatrice : Macchina
{
    public Lavatrice(string nome)
    {
        Stato = true;
        Gettoni = 0;
        Detersivo = 1000;
        Ammorbidente = 500;
        Nome = nome;
        ProgrammiLavaggio = new ProgrammaLavaggio[3];
        ProgrammiLavaggio[0] = new ProgrammaLavaggio("Lavaggio Rinfrescante", 20, 2, 20, 5);
        ProgrammiLavaggio[1] = new ProgrammaLavaggio("Lavaggio Rinnovante", 40, 3, 40, 10);
        ProgrammiLavaggio[2] = new ProgrammaLavaggio("Lavaggio Sgrassante", 60, 4, 60, 15);
        lavaggioCorrente = new ProgrammaLavaggio("nessuna", 0, 0, 0, 0);
    }

    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Gettoni { get; set; }
    public bool Stato { get; private set; }
    public string Nome { get; set; }

    private ProgrammaLavaggio[] ProgrammiLavaggio;
    public ProgrammaLavaggio lavaggioCorrente;
    public void NuovoLavaggio()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("[1] per Lavaggio Rinfrescante");
        Console.WriteLine("[2] per Lavaggio Rinnovante");
        Console.WriteLine("[3] per Lavaggio Sgrassante");
        int scelta = Convert.ToInt32(Console.ReadLine());
        if (scelta == 1 || scelta == 2 || scelta == 3)
        {
            if (Detersivo - ProgrammiLavaggio[scelta - 1].ConsumoDetersivo > 0 && Ammorbidente - ProgrammiLavaggio[scelta - 1].ConsumoAmmorbidente > 0)
            {
                lavaggioCorrente.Nome = ProgrammiLavaggio[scelta - 1].Nome;
                lavaggioCorrente.Tempo = ProgrammiLavaggio[scelta - 1].Tempo;
                lavaggioCorrente.TempoRimanente = ProgrammiLavaggio[scelta - 1].Tempo;
                lavaggioCorrente.Costo = ProgrammiLavaggio[scelta - 1].Costo;
                lavaggioCorrente.ConsumoDetersivo = ProgrammiLavaggio[scelta - 1].ConsumoDetersivo;
                lavaggioCorrente.ConsumoAmmorbidente = ProgrammiLavaggio[scelta - 1].ConsumoAmmorbidente;
                Gettoni += lavaggioCorrente.Costo;
                Detersivo -= lavaggioCorrente.ConsumoDetersivo;
                Ammorbidente -= lavaggioCorrente.ConsumoAmmorbidente;
                Stato = false;

                Console.WriteLine(lavaggioCorrente.Nome + ", durata " + lavaggioCorrente.Tempo + ", minuti rimasti " + lavaggioCorrente.TempoRimanente + ", costo " + lavaggioCorrente.Costo);
            }
        }
        else
            Console.WriteLine("Digitato numero errato");
    }
    //override ControlloStato

    public bool ControlloStato()
    {
        if (!Stato)
        {
            Random random = new Random();
            int finito = random.Next(1, 4);
            if (finito == 1 || lavaggioCorrente.TempoRimanente == 0)
            {
                lavaggioCorrente.TempoRimanente = 0;
                Stato = true;
            }
            else
            {
                lavaggioCorrente.TempoRimanente = random.Next(0, lavaggioCorrente.TempoRimanente);
            }
        }
        return Stato;
    }
    public void DettagliMacchina()
    {
        string stato;
        if (ControlloStato())
            stato = "Vuota";
        else
            stato = "In esecuzione";
        Console.WriteLine("Nome: " + Nome);
        Console.WriteLine("Stato: " + stato);
        Console.WriteLine("Detersivo rimanente: " + Detersivo + "ml");
        Console.WriteLine("Ammorbidente rimanente: " + Ammorbidente + "ml");
        Console.WriteLine("Tempo alla fine del lavaggio: " + lavaggioCorrente.TempoRimanente);
    }
    public override double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}
