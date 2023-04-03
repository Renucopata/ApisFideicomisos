namespace ApisFideicomisos.Handlers
{
    public class ConnectionADFideicomisos
    {
        private String cadConexion = String.Empty;
        public ConnectionADFideicomisos()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadConexion = builder.GetSection("ConnectionStrings:ConexionFideicomisos").Value;
        }
        public String get_cadConexion()
        {
            return cadConexion;
        }
    }
}
