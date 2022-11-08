public abstract class Macchina
{
    public int Detersivo { get; set; }
    public int Ammorbidente { get; set; }
    public int Gettoni { get; set; }
    public bool Stato { get; set; }
    public string Nome { get; set; }

    public abstract bool ControlloStato();
    public abstract double Incasso();

}