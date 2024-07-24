namespace RMSuit_v2.Models
{
    public enum TableState
    {
        Neutral,
        Ocupado,
        Reservado
    }

    public class Table
    {
        public string Number { get; set; } = string.Empty; // Valor predeterminado
        public TableState State { get; set; } = TableState.Neutral;
    }
}
