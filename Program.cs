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
 TempoRimanente = new Random().Next(0, ProgrammaInEsecuzione.Durata + 1);
public void SimulaAvanzamento()
    {
        TempoRimanente = new Random().Next(0, TempoRimanente);
    }
public void SimulaAvanzamento()
    {
        TempoRimanente = new Random().Next(0, TempoRimanente);
    }

 */

Console.WriteLine("Lavanderia");

Lavanderia lavanderia = new Lavanderia();
bool fine = false;
do
{
    Console.WriteLine("Digita l'azione da eseguire");
    Console.WriteLine("[1] Stato Macchine");
    Console.WriteLine("[2] Dettagli Macchina");
    Console.WriteLine("[3] Programma Lavatrici");
    Console.WriteLine("[4] Programma Asciugatrici");
    Console.WriteLine("[5] Incasso");
    Console.WriteLine("[6] Esci");
    int scelta = Convert.ToInt32(Console.ReadLine());
    switch (scelta)
    {
        case 1:
            lavanderia.StatoMacchine();
            break;
        case 2:
            Console.WriteLine("Digita [L] per lavatrice o [A] per asciugatrice");
            string macchina = Console.ReadLine();
            Console.WriteLine("Digita il numero della macchina da [1] a [5]");
            int numero = Convert.ToInt32(Console.ReadLine());
            lavanderia.DettagliMacchina(macchina, numero);
            break;
        case 3:
            lavanderia.ProgrammaLavatrici();
            break;
        case 4:
            lavanderia.ProgrammaAsciugatrici();
            break;
        case 5:
            lavanderia.Incasso();
            break;
        default:
            fine = true;
            break;
    }
} while (!fine);


