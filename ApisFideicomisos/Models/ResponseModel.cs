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
}
