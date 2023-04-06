using Newtonsoft.Json;

namespace ApisFideicomisos.Models
{
    public class DnacResponse
    {
        [JsonProperty("PETICION")]
        public Int64 Peticion { get; set; }

        [JsonProperty("CREDITO")]
        public Int64 Credito { get; set; }

        [JsonProperty("TICKET")]
        public Int64 Ticket { get; set; }

        [JsonProperty("CI")]
        public string Ci { get; set; }

        [JsonProperty("COMPLEMENTO")]
        public string Complemento { get; set; }

        [JsonProperty("CIJPG")]
        public string Cijpg { get; set; }

        [JsonProperty("SCI-BD")]
        public string SciBd { get; set; }

        [JsonProperty("BD_FECHA_A_M")]
        public string BdFechaAM { get; set; }

        [JsonProperty("GEO")]
        public GeoLocation GeoLocations { get; set; }

        [JsonProperty("SEGIP_B64")]
        public string SegipB64 { get; set; }
    }
    public class GeoLocation
    {
        [JsonProperty("CI")]
        public string Ci { get; set; }

        [JsonProperty("FECHA")]
        public string Fecha { get; set; }

        [JsonProperty("NOMBRE")]
        public string Nombre { get; set; }
    }

   
}
