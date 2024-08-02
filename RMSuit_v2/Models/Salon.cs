namespace RMSuit_v2.Models
{
    public class Salon
    {
        public int salon { get; set; }
        public string nombre { get; set; } = string.Empty;
        public int recargo { get; set; }
        public int tarifa { get; set; }
        public string? imagen { get; set; }
        public int colorFondo { get; set; }
        public string reparto { get; set; } = string.Empty;
        public string? propina { get; set; }
        public decimal? porcentajePropina { get; set; }
        public string? reposicion { get; set; }
        public string? articulosApertura { get; set; }
    }

    public class SalonDetail
    {
        public int salon { get; set; }
        public int mesa { get; set; }
        public int relacion { get; set; }
        public int dibujos { get; set; }
        public int recargo { get; set; }
        public int tarifa { get; set; }
        public string articulosApertura { get; set; } = string.Empty;
        public string transparente { get; set; } = string.Empty;
        public int colorLetra { get; set; }
        public string fuenteLetra { get; set; } = string.Empty;
        public string estiloLetra { get; set; } = string.Empty;
        public int tamanoLetra { get; set; }
        public string alinearHorizontal { get; set; } = string.Empty;
        public string alinearVertical { get; set; } = string.Empty;
        public int posicionX { get; set; }
        public int posicionY { get; set; }
        public string propina { get; set; } = string.Empty;
        public int porcentajePropina { get; set; }
    }

    public class Dibujo
    {
        public int dibujos { get; set; }
        public string estado { get; set; } = string.Empty;
        public string grafico { get; set; } = string.Empty;
        public string? imagenDataUrl { get; set; }
        public string? activo { get; set; }
        public string? transparente { get; set; }
        public int salonDetailId { get; set; }
    }

    public class SalonResponse
    {
        public Salon salon { get; set; } = new Salon();
        public List<SalonDetail> mesas { get; set; } = new List<SalonDetail>();
        public List<Dibujo> dibujos { get; set; } = new List<Dibujo>();
    }
}
