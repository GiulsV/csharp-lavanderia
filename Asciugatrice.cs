// See https://aka.ms/new-console-template for more information
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




public class Asciugatrice : Macchina
{
    public Asciugatrice(string nome)
    {
        Stato = true;
        Gettoni = 0;
        Nome = nome;
        programmiAsciugatura = new ProgrammaAsciugatura[2];
        programmiAsciugatura[0] = new ProgrammaAsciugatura("Asciugatura rapida", 30, 2);
        programmiAsciugatura[1] = new ProgrammaAsciugatura("Asciugatura intensa", 60, 4);
        asciugaturaCorrente = new ProgrammaAsciugatura("nessuna", 0, 0);
    }

    public int Gettoni { get; set; }
    public bool Stato { get; private set; }
    public string Nome { get; set; }

    private ProgrammaAsciugatura[] programmiAsciugatura;
    public ProgrammaAsciugatura asciugaturaCorrente;
    public void NuovaAsciugatura()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("[1] per Asciugatura rapida");
        Console.WriteLine("[2] per Asciugatura intensa");
        int scelta = Convert.ToInt32(Console.ReadLine());
        if (scelta == 1 || scelta == 2)
        {
            asciugaturaCorrente.Nome = programmiAsciugatura[scelta - 1].Nome;
            asciugaturaCorrente.Tempo = programmiAsciugatura[scelta - 1].Tempo;
            asciugaturaCorrente.TempoRimanente = programmiAsciugatura[scelta - 1].Tempo;
            asciugaturaCorrente.Costo = programmiAsciugatura[scelta - 1].Costo;
            Gettoni += asciugaturaCorrente.Costo;
            Stato = false;
            Console.WriteLine(asciugaturaCorrente.Nome + ", durata " + asciugaturaCorrente.Tempo + ", minuti rimasti " + asciugaturaCorrente.TempoRimanente + ", costo " + asciugaturaCorrente.Costo);
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
            if (finito == 1 || asciugaturaCorrente.TempoRimanente == 0)
            {
                asciugaturaCorrente.TempoRimanente = 0;
                Stato = true;
            }
            else
            {
                asciugaturaCorrente.TempoRimanente = random.Next(0, asciugaturaCorrente.TempoRimanente);
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
        Console.WriteLine("Tempo alla fine dell'asciugatura: " + asciugaturaCorrente.TempoRimanente);
    }
    public override double Incasso()
    {
        return (double)Gettoni * 0.50;
    }
}
