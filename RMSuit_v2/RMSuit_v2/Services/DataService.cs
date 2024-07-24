using PruebaConBlazor.Constants;

namespace PruebaConBlazor.Services
{
    public class DataService
    {
        public bool MostrarError { get; set; } = true;

        public List<string> TablasDiario => DatabaseTables.TablasDiario;

        public List<string> TablasHistorico => DatabaseTables.TablasHistorico;

        public const int CM_RESTORE = MessageIds.CM_RESTORE;

        public char[] SerieAlfaNumerica => Series.SerieAlfaNumerica;

        public char[] SerieFidelizacion => Series.SerieFidelizacion;

        public char[] SerieSecurity => Series.SerieSecurity;

        public char[] SerieBasico => Series.SerieBasico;

        public char[] SerieFastMaster => Series.SerieFastMaster;

        public int MaxTipoFormato => Constants.TipoFormato.MaxTipoFormato;

        public string[,] TipoFormato => Constants.TipoFormato.Formatos;
    }
}
