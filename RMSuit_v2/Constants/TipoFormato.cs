namespace PruebaConBlazor.Constants
{
    public static class TipoFormato
    {
        public const int MaxTipoFormato = 18;

        public static readonly string[,] Formatos = new string[,]
        {
            { "COMANDA", "COMANDA" },
            { "COMANDA REENVIAR", "COMANDA REENVIAR" },
            { "COMANDA SALIDA PLATOS", "COMANDA SALIDA PLATOS" },
            { "CONSUMO INTERNO", "CONSUMO INTERNO" },
            { "ENTRADA Y SALIDA DE CAJA", "ENTRADA Y SALIDA DE CAJA" },
            { "ABONO", "ABONO" },
            { "FACTURA", "FACTURA" },
            { "FACTURA RAPIDA", "FACTURA RAPIDA" },
            { "FACTURA COBRO", "FACTURA COBRO" },
            { "FACTURA COBRO RAPIDO", "FACTURA COBRO RAPIDO" },
            { "FACTURA CONCEPTO", "FACTURA CONCEPTO" },
            { "FACTURA CONCEPTO COBRO", "FACTURA CONCEPTO COBRO" },
            { "ARQUEO DE CAJA", "ARQUEO DE CAJA" },
            { "ANULACIONES DE LÍNEAS", "ANULACIONES DE LÍNEAS" },
            { "TARJETA PREPAGO VENTA", "TARJETA PREPAGO VENTA" },
            { "TARJETA PREPAGO COMPRA", "TARJETA PREPAGO COMPRA" },
            { "ROTURAS / MERMAS", "ROTURAS / MERMAS" },
            { "CUPÓN WIFI", "CUPÓN WIFI" }
        };
    }
}
