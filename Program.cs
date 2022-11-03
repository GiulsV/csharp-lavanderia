// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

/* Lavanderia con 
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

//Inizializzazione lavanderia
Lavanderia lavanderia = new Lavanderia();

//PROGRAMMA PRINCIPALE

Console.WriteLine("Lavanderia");

lavanderia.StampaMacchine();

public class Macchina
{
    public bool Acceso { get; set; }
    public string Marca { get; set; }
    public string Tipo { get; set; }
    public string Programma { get; set; }
    public int DurataProgramma { get; set; }
    public int DurataRimanente { get; set; }
    public int QtyDetersivo { get; set; }
    public int QtyAmmorbidente { get; set; }

    //Asciugatrici
    public Macchina(bool acceso, string marca, string tipo)
    {
        this.Acceso = acceso;
        this.Marca = marca;
        this.Tipo = tipo;
    }
    //Lavatrici
    public Macchina(bool acceso, string marca, string tipo, int qtyDetersivo, int qtyAmmorbidente)
    {
        this.Acceso = false;
        this.Marca = marca;
        this.Tipo = tipo;
        this.QtyDetersivo = qtyDetersivo;
        this.QtyAmmorbidente = qtyAmmorbidente;
    }
}

public class Lavanderia
{
    private Macchina[] lavatrici;
    private Macchina[] asciugatrice;
    public Lavanderia()
    {
        //lavatrici
        lavatrici = new Macchina[5];
        lavatrici[0] = new Macchina(false, "Bosch" , "lavatrice", 1000, 500);
        lavatrici[1] = new Macchina(false, "Beko" , "lavatrice", 1000, 500);
        lavatrici[2] = new Macchina(false, "Lg" , "lavatrice", 1000, 500);
        lavatrici[3] = new Macchina(false, "Bosch", "lavatrice", 1000, 500);
        lavatrici[4] = new Macchina(false, "Candy" , "lavatrice", 1000, 500);

        //asciugatrici
        asciugatrice = new Macchina[5];
        asciugatrice[0] = new Macchina(false, "Candy", "asciugatrice");
        asciugatrice[1] = new Macchina(false, "Bosch", "asciugatrice");
        asciugatrice[2] = new Macchina(false, "Aqualtis", "asciugatrice");
        asciugatrice[3] = new Macchina(false, "Beko", "asciugatrice");
        asciugatrice[4] = new Macchina(false, "Electrolux", "asciugatrice");
    }

    public void StampaMacchine()
    {
        Console.WriteLine("----- Lavatrici -------");

        for (int i = 0; i < lavatrici.Length; i++)
        {
            Console.WriteLine("{0} - {1}, {2}, {3}, {4}, {5}", (i + 1), "Acceso: " + lavatrici[i].Acceso,"Marca: " + lavatrici[i].Marca, "Tipo: " + lavatrici[i].Tipo, 
                "Capacità max in ml: " + lavatrici[i].QtyDetersivo , lavatrici[i].QtyAmmorbidente);
        }

        Console.WriteLine("----- Asciugatrici -------");

        for (int i = 0; i < asciugatrice.Length; i++)
        {
            Console.WriteLine("{0} - {1}, {2}, {3}", (i + 1), "Acceso: " + asciugatrice[i].Acceso, "Marca: " + asciugatrice[i].Marca, "Tipo: " + asciugatrice[i].Tipo);
        }
    }
}