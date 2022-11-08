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

/*
Console.WriteLine("Lavanderia");
//Inizializzazione lavanderia
Lavanderia lavanderia = new Lavanderia();
ProgrammaLavaggio lavaggio = new ProgrammaLavaggio();
ProgrammaAssciugatrice asciugatrice = new ProgrammaAssciugatrice();
Console.WriteLine("---- PROVA STAMPA MENU------");
//Stampo scelte possibili
Console.WriteLine("Scegli l'operazione digitando il numero corrispondente");
Console.WriteLine("[1] Stato di utilizzo");
Console.WriteLine("[2] Dettagli macchina");
Console.WriteLine("[3] Incasso");
int sceltaAzione = Convert.ToInt32(Console.ReadLine());

//scelta azione
if (sceltaAzione == 1)
{
    Console.WriteLine("stato");
}
else if (sceltaAzione == 2)
{
    Console.WriteLine("dettagli");
}
else if(sceltaAzione == 3)
{
    lavanderia.Incasso();
}
else
{
    Console.WriteLine("Scelta non riconosciuta. Riprovare");
}

//stampa opzioni
Console.WriteLine("---- PROVA STAMPA LAVAGGI------");
lavaggio.SceltaLavaggio();
asciugatrice.NuovaAsciugatura();

public class Lavanderia
{
    public Lavanderia()
    {
        lavatrici = new Lavatrice[5];
        asciugatrici = new Asciugatrice[5];
        for (int i = 0; i < 5; i++)
        {
            lavatrici[i] = new Lavatrice("Lavatrice" + (i + 1));
            asciugatrici[i] = new Asciugatrice("Asciugatrice" + (i + 1));
        }
    }
    private Lavatrice[] lavatrici;
    private Asciugatrice[] asciugatrici;
    public void Incasso()
    {
        Console.WriteLine("Incassi:");
        double incassoTotale = 0;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].IncassoLavatrice() + " euro");
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].IncassoAsciugatrice() + " euro");
            incassoTotale = incassoTotale + lavatrici[i].IncassoLavatrice() + asciugatrici[i].IncassoAsciugatrice();
        }
        Console.WriteLine("Totale: " + incassoTotale + " euro");
    }
}
public class Lavatrice {
    public Lavatrice(string nome)
    {
        Stato = "Vuota";
        Gettoni = 0;
        Detersivo = 1000;
        Ammorbidente = 500;
        Nome = nome;
    }
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome { get; set; }
    
    public double IncassoLavatrice()
    {
        return (double)Gettoni * 0.50;
    }
}
public class ProgrammaLavaggio 
{
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome
    {
        get; set;
    }


    //Modalità lavaggio
    private void Rinfrescante()
    {
        if (Detersivo - 20 > 0 && Ammorbidente - 5 > 0)
        {
            Detersivo -= 20;
            Ammorbidente -= 5;
            Stato = "Lavaggio Rinfrescante";
            Tempo = 20;
            Gettoni += 2;
        }
    }
    private void Rinnovante()
    {
        if (Detersivo - 40 > 0 && Ammorbidente - 10 > 0)
        {
            Detersivo -= 40;
            Ammorbidente -= 10;
            Stato = "Lavaggio Rinnovante";
            Tempo = 40;
            Gettoni += 3;
        }
    }
    private void Sgrassante()
    {
        if (Detersivo - 60 > 0 && Ammorbidente - 15 > 0)
        {
            Detersivo -= 60;
            Ammorbidente -= 16;
            Stato = "Lavaggio Sgrassante";
            Tempo = 60;
            Gettoni += 4;
        }
    }

    //Scelta lavaggio
    public void SceltaLavaggio()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 - Lavaggio Rinfrescante");
        Console.WriteLine("2 - Lavaggio Rinnovante");
        Console.WriteLine("3 - Lavaggio Sgrassante");
        int sceltaLavaggio = Convert.ToInt32(Console.ReadLine());

        if (sceltaLavaggio == 1)
        {
            Rinfrescante();
        }
        else if (sceltaLavaggio == 2)
        {
            Rinnovante();
        }
        else if (sceltaLavaggio == 3)
        {
            Sgrassante();
        }
        else
        {
            Console.WriteLine("Scelta non riconosciuta. Riprovare");
        }

    }


}


public class Asciugatrice {
    public Asciugatrice(string nome)
    {
        Stato = "Vuota";
        Gettoni = 0;
        Nome = nome;
    }
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome { get; set; }
    
    public double IncassoAsciugatrice()
    {
        return (double)Gettoni * 0.50;
    }
}
//Programma Asciugatrice
public class ProgrammaAssciugatrice 
{
    public int Gettoni { get; set; }
    public string Stato { get; private set; }
    public int Tempo { get; private set; }
    public string Nome { get; set; }
    private void Rapido()
    {
        Stato = "Asciugatura rapida";
        Tempo = 30;
        Gettoni += 2;
    }
    private void Intenso()
    {
        Stato = "Asciugatura intensa";
        Tempo = 60;
        Gettoni += 4;
    }

    public void NuovaAsciugatura()
    {
        Console.WriteLine("Digita:");
        Console.WriteLine("1 - Asciugatura rapida");
        Console.WriteLine("2 - Asciugatura intensa");
        int sceltaAsciugatura = Convert.ToInt32(Console.ReadLine());

        if (sceltaAsciugatura == 1)
        {
            Rapido();
        }
        else if (sceltaAsciugatura == 2)
        {
            Intenso();
        }
        else
        {
            Console.WriteLine("Scelta non riconosciuta. Riprovare");
        }

    }
    //incasso asciugatrici


}
*/

public interface IProgrammaLavaggio
{
    int ConsumoAmmorbidente { get; set; }
    int ConsumoDetersivo { get; set; }
    int Costo { get; set; }
    string Nome { get; set; }
    int Tempo { get; set; }
    int TempoRimanente { get; set; }
}

public class ProgrammaLavaggio : IProgrammaLavaggio
{
    public ProgrammaLavaggio(string nome, int tempo, int costo, int consumoDetersivo, int consumoAmmorbidente)
    {
        Tempo = tempo;
        TempoRimanente = 0;
        Nome = nome;
        Costo = costo;
        ConsumoDetersivo = consumoDetersivo;
        ConsumoAmmorbidente = consumoAmmorbidente;
    }
    public int Tempo { get; set; }
    public int TempoRimanente { get; set; }
    public string Nome { get; set; }
    public int Costo { get; set; }
    public int ConsumoDetersivo { get; set; }
    public int ConsumoAmmorbidente { get; set; }
}
