namespace PruebaConBlazor.Constants
{
    public static class DatabaseTables
    {
        public static readonly List<string> TablasDiario = new List<string>
        {
            "CIERRES", "CIERRES_DESGLOSE", "ARQUEO_VENTA", "ARQUEO_VENTA_CAJA",
            "E_S_CAJA", "CONSUMO_PERSONAL", "E_S_CAJA", "FACTURA", "FACTURAS_COBROS",
            "FACTURA_IVA", "FACTURA_LINEA", "FACTURA_PREPAGO", "FACTURA_LINEA_ANULADA",
            "FACTURA_LINEA_MODIFICADOR", "MESAS_CABECERA", "MESAS_CABECERA_ANULADA",
            "MESAS_ESTADO", "MESAS_LINEAS", "MESAS_LINEAS_ANULADAS",
            "MESAS_LINEAS_MODIFICADORES", "MERMAS", "REPOSICIONES"
        };

        public static readonly List<string> TablasHistorico = new List<string>
        {
            "CIERRES", "CIERRES_DESGLOSE", "CONSUMO_PERSONAL", "E_S_CAJA",
            "FACTURA", "FACTURAS_COBROS", "FACTURA_IVA", "FACTURA_LINEA",
            "FACTURA_PREPAGO", "FACTURA_LINEA_ANULADA", "FACTURA_LINEA_MODIFICADOR",
            "MESAS_CABECERA_ANULADA", "MESAS_LINEAS_ANULADAS", "PERMISOS",
            "VENTA_COSTO", "MERMAS", "MERMAS_COSTO", "CONSUMO_COSTO", "REPOSICIONES"
        };
    }
}
