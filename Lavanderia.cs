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

    public void StatoMacchine()
    {
        Console.WriteLine("Stato:");
        for (int i = 0; i < lavatrici.Length; i++)
        {
            string statoLavatrice;
            if (lavatrici[i].ControlloStato())
                statoLavatrice = "Vuota";
            else
                statoLavatrice = "In esecuzione";
            string statoAsciugatrice;
            if (asciugatrici[i].ControlloStato())
                statoAsciugatrice = "Vuota";
            else
                statoAsciugatrice = "In esecuzione";
            Console.WriteLine(lavatrici[i].Nome + ": " + statoLavatrice);
            Console.WriteLine(asciugatrici[i].Nome + ": " + statoAsciugatrice);
        }
    }
    public void DettagliMacchina(string macchina, int numero)
    {
        
        Console.WriteLine("Dettagli:");
        if (macchina == "lavatrice")
            lavatrici[numero - 1].DettagliMacchina();
        else
            asciugatrici[numero - 1].DettagliMacchina();
    }
    public  void Incasso()
    {
        
        Console.WriteLine("Incassi:");
        double incassoTotale = 0;
        for (int i = 0; i < lavatrici.Length; i++)
        {
            Console.WriteLine(lavatrici[i].Nome + ": " + lavatrici[i].Incasso() + "$");
            Console.WriteLine(asciugatrici[i].Nome + ": " + asciugatrici[i].Incasso() + "$");
            incassoTotale = incassoTotale + lavatrici[i].Incasso() + asciugatrici[i].Incasso();
        }
        Console.WriteLine("Totale: " + incassoTotale + "$");
    }
    public void ProgrammaLavatrici()
    {
        for (int i = 0; i < lavatrici.Length; i++)
        {
            if (lavatrici[i].ControlloStato())
            {
                lavatrici[i].NuovoLavaggio();
                break;
            }
        }
    }
    public void ProgrammaAsciugatrici()
    {
        for (int i = 0; i < asciugatrici.Length; i++)
        {
            if (asciugatrici[i].ControlloStato())
            {
                asciugatrici[i].NuovaAsciugatura();
                break;
            }
        }
    }
}
