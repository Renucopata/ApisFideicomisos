namespace ApisFideicomisos.Models
{
    public class DataRequestModel
    {
    }
    public class REQUEST_ID
    {
        public int id { get; set; }
    }
    public class REQUEST_EDITABLES
    {
        public int idtabla { get; set; }
        public string productor { get; set; }
        public string ci { get; set; }
        public int dias { get; set; }
        public DateTime fcobro { get; set; }
        public string ecobro { get; set; }
        public DateTime flag30 { get; set; }
        public DateTime flag60 { get; set; }
        public string documentacion { get; set; }
        public DateTime FPago { get; set; }

    }

    public class REQUEST_FECHAS
    {
        public string fechaIni { get; set; }
        public string fechaFin { get; set; }
    }

    public class REQUEST_FILTRO
    {
        public string filtro { get; set; }
  
    }
}
