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

    public class REQUEST_ID_EDITABLES
    {
        public int id { get; set; }
        public string edit { get; set; }

    }

    public class REQUEST_EXCEL_FIDEICO
    {
        public string Empresa { get; set; }
        public string NroLista { get; set; }
        public string NombreProductor { get; set; }
        public string NroCi { get; set; }
        public string Cultivo { get; set; }
        public string Variedad { get; set; }
        public string VolumenSemilla { get; set; }
        public string PrecioUnitario { get; set; }
        public string SUB_TOTAL { get; set; }
        public string RetencionImpuestos { get; set; }
        public string TOTAL { get; set; }
        public string DeduccionGastosOp { get; set; }
        public string LiquidoPagable { get; set; }
        public string Municipio { get; set; }
        public string Comunidad { get; set; }

    }

    public class REQUEST_EXCEL_FMP
    {
        public string Regional { get; set; }
        public string Agencia { get; set; }
        public string FechaProceso { get; set; }
        public string NoOperacion { get; set; }
        public string DocumentoIdentidad { get; set; }
        public string CodigoCliente { get; set; }
        public string NombreTitular { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public string MontoDesembolsadoBs { get; set; }
        public string MontoDesembolsadoUsd { get; set; }
        public string SaldoBs { get; set; }
        public string SaldoUsd { get; set; }
        public string PrevisonBs { get; set; }
        public string PrevisonUsd { get; set; }
        public string PrevisonCiclicaBs { get; set; }
        public string PrevisonCiclicaUsd { get; set; }
        public string ProductosDevengadosBs { get; set; }
        public string ProductosDevengadosUsd { get; set; }
        public string Plazo { get; set; }
        public string FechaVencimiento { get; set; }
        public string FechaProxPago { get; set; }

    }
}
