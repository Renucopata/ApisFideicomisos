namespace ApisFideicomisos.Models
{
    public class ResponseModel
    {
    }

    public class FullTFideicomisosResponse
    {
        public Int64 IdTabla { get; set; }
        public string Empresa { get; set; }
        public Int64 Nlista { get; set; }
        public string Productor { get; set; }
        public string CI { get; set; }
        public string Cultivo { get; set; }
        public string Variedad { get; set; }
        public float VSemilla { get; set; }
        public Decimal Precio { get; set; } //Decimal
        public Decimal STotal { get; set; } //Decimal
        public float RImpuestos5 { get; set; }
        public float RImpuestos3 { get; set; }
        public Decimal Total { get; set; } //Decimal
        public Decimal DgastosOperativos { get; set; } //Decimal
        public Decimal LPagable { get; set; } //Decimal
        public string Municipio { get; set; }
        public string Comunidad { get; set; }
        public string NFuncionario { get; set; }
        public string Sucursal { get; set; }
        public string Agencia { get; set; }
        public string EPago { get; set; }
        public DateTime FPago { get; set; }
        public Int64 Dias { get; set; }
        public DateTime FCobro { get; set; }
        public string ECobro { get; set; }
        public DateTime fCobro30 { get; set; }
        public DateTime fCobro60 { get; set; }
        public string Documentacion { get; set; }
        public Int64 Cuenta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Usuario { get; set; }
        public string HoraRegistro { get; set; }

    }

    public class FullTFimypeResponse
    {
        public Int32 IdTabla { get; set; }
        public DateTime FechaProceso { get; set; }
        public Int32 NroOperacion { get; set; }
        public Int32 DocIdentidad { get; set; }
        public Int32 CodCliente { get; set; }
        public string NombreTitular { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public Decimal MontDesembolsdoBS { get; set; } //Decimal
        public Decimal MontDesembolsdoUSD { get; set; } //Decimal
        public Decimal SaldoBS { get; set; }
        public Decimal SaldoUSD { get; set; }
        public Decimal PrevisionBS { get; set; } //Decimal
        public Decimal PrevisionUSD { get; set; } //Decimal
        public Decimal PrevisCiclicaBS { get; set; } //Decimal
        public Decimal PrevisCiclicaUSD { get; set; }
        public Decimal ProdDevengadosBS { get; set; }
        public Decimal ProdDevengadosUSD { get; set; }
        public string Plazo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaProxPago { get; set; }
        public Decimal MontPagadoCapital { get; set; }
        public Decimal MontPagadoIntereses { get; set; }
        public string EstadoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public Int32 NumeroCuota { get; set; }
        public DateTime FechaCarga { get; set; }
        public string Usuario { get; set; }
        public string HoraR { get; set; }
      

    }

    public class FimypefiltradoResponse
    {

        public Int32 IdTabla { get; set; }
        public DateTime FechaProceso { get; set; }
        public Int32 NroOperacion { get; set; }
        public Int32 DocIdentidad { get; set; }
        public Int32 CodCliente { get; set; }
        public string NombreTitular { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public Decimal MontDesembolsdoBS { get; set; } //Decimal
        public Decimal MontDesembolsdoUSD { get; set; } //Decimal
        public Decimal SaldoBS { get; set; }
        public Decimal SaldoUSD { get; set; }
        public Decimal PrevisionBS { get; set; } //Decimal
        public Decimal PrevisionUSD { get; set; } //Decimal
        public Decimal PrevisCiclicaBS { get; set; } //Decimal
        public Decimal PrevisCiclicaUSD { get; set; }
        public Decimal ProdDevengadosBS { get; set; }
        public Decimal ProdDevengadosUSD { get; set; }
        public string Plazo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaProxPago { get; set; }
        public Decimal MontPagadoCapital { get; set; }
        public Decimal MontPagadoIntereses { get; set; }
        public string EstadoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public Int32 NumeroCuota { get; set; }

    }

    public class FechasFimypeResponse
    {
        public int IdTabla { get; set; }
        public DateTime FechaProceso { get; set; }
        public int NroOperacion { get; set; }
        public int DocIdentidad { get; set; }
        public int CodCliente { get; set; }
        public string NombreTitular { get; set; }
        public string Moneda { get; set; }
        public string Estado { get; set; }
        public decimal MontDesembolsdoBS { get; set; }
        public decimal MontDesembolsdoUSD { get; set; }
        public decimal SaldoBS { get; set; }
        public decimal SaldoUSD { get; set; }
        public decimal PrevisionBS { get; set; }
        public decimal PrevisionUSD { get; set; }
        public decimal PrevisCiclicaBS { get; set; }
        public decimal PrevisCiclicaUSD { get; set; }
        public decimal ProdDevengadosBS { get; set; }
        public decimal ProdDevengadosUSD { get; set; }
        public string Plazo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime FechaProxPago { get; set; }
        public decimal MontPagadoCapital { get; set; }
        public decimal MontPagadoIntereses { get; set; }
        public string EstadoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public int NumeroCuota { get; set; }
        public string Usuario { get; set; }
        public string HoraR { get; set; }
    }
}
