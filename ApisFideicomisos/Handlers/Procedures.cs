using ApisFideicomisos.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ApisFideicomisos.Handlers
{
    public class Procedures
    {

        public List<FullTFideicomisosResponse> GetFullTFideicomisos()
        {
            var responseList = new List<FullTFideicomisosResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Interfaz", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        responseList.Add(new FullTFideicomisosResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            Empresa = dr["Empresa"].ToString(),
                            Nlista = Convert.ToInt32(dr["Nlista"]),
                            Productor = dr["Productor"].ToString(),
                            CI = dr["CI"].ToString(),
                            Cultivo = dr["Cultivo"].ToString(),
                            Variedad = dr["Variedad"].ToString(),
                            VSemilla = Convert.ToSingle(dr["VSemilla"]),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            STotal = Convert.ToDecimal(dr["STotal"]),
                            RImpuestos5 = Convert.ToSingle(dr["RImpuestos5"]),
                            RImpuestos3 = Convert.ToSingle(dr["RImpuestos3"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            DgastosOperativos = Convert.ToDecimal(dr["DgastosOperativos"]),
                            LPagable = Convert.ToDecimal(dr["LPagable"]),
                            Municipio = dr["Municipio"].ToString(),
                            Comunidad = dr["Comunidad"].ToString(),
                            NFuncionario = dr["NFuncionario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            EPago = dr["EPago"].ToString(),
                            FPago = Convert.ToDateTime(dr["FPago"]),
                            Dias = dr["Dias"] != System.DBNull.Value ? Convert.ToInt32(dr["Dias"]) : 0,
                            FCobro = Convert.ToDateTime(dr["FCobro"]),
                            ECobro = dr["ECobro"].ToString(),
                            fCobro30 = Convert.ToDateTime(dr["fCobro30"]),
                            fCobro60 = Convert.ToDateTime(dr["fCobro60"]),
                            Documentacion = dr["Documentacion"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            HoraRegistro = dr["HoraRegistro"].ToString()
                        });

                    }
                }
            }
            return responseList;
        }


        public List<FullTFideicomisosResponse> GetFideicomisosById(REQUEST_ID data)
        {
            var responseList = new List<FullTFideicomisosResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Posicion", conexion);
                cmd.Parameters.AddWithValue("pos", data.id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        responseList.Add(new FullTFideicomisosResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            Empresa = dr["Empresa"].ToString(),
                            Nlista = Convert.ToInt32(dr["Nlista"]),
                            Productor = dr["Productor"].ToString(),
                            CI = dr["CI"].ToString(),
                            Cultivo = dr["Cultivo"].ToString(),
                            Variedad = dr["Variedad"].ToString(),
                            VSemilla = Convert.ToSingle(dr["VSemilla"]),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            STotal = Convert.ToDecimal(dr["STotal"]),
                            RImpuestos5 = Convert.ToSingle(dr["RImpuestos5"]),
                            RImpuestos3 = Convert.ToSingle(dr["RImpuestos3"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            DgastosOperativos = Convert.ToDecimal(dr["DgastosOperativos"]),
                            LPagable = Convert.ToDecimal(dr["LPagable"]),
                            Municipio = dr["Municipio"].ToString(),
                            Comunidad = dr["Comunidad"].ToString(),
                            NFuncionario = dr["NFuncionario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            EPago = dr["EPago"].ToString(),
                            FPago = Convert.ToDateTime(dr["FPago"]),
                            Dias = dr["Dias"] != System.DBNull.Value ? Convert.ToInt32(dr["Dias"]) : 0,
                            FCobro = Convert.ToDateTime(dr["FCobro"]),
                            ECobro = dr["ECobro"].ToString(),
                            fCobro30 = Convert.ToDateTime(dr["fCobro30"]),
                            fCobro60 = Convert.ToDateTime(dr["fCobro60"]),
                            Documentacion = dr["Documentacion"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            HoraRegistro = dr["HoraRegistro"].ToString()
                        });

                    }
                }
            }
            return responseList;
        }

        public bool CargaEditable(REQUEST_EDITABLES data) //Revisar
        {
            bool resp;
            DateTime nfc = default(DateTime);
            DateTime f30 = default(DateTime);
            DateTime f60 = default(DateTime);
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Editables", conexion);
                    cmd.Parameters.AddWithValue("idtabla", data.idtabla);
                    cmd.Parameters.AddWithValue("productor", data.productor);
                    cmd.Parameters.AddWithValue("ci", data.ci);
                    cmd.Parameters.AddWithValue("dias", data.dias);
                    nfc = data.FPago.AddDays(data.dias);
                    f30 = nfc.AddDays(-30);
                    f60 = nfc.AddDays(-60);
                    cmd.Parameters.AddWithValue("fcobro", nfc);
                    cmd.Parameters.AddWithValue("ecobro", data.ecobro);
                    cmd.Parameters.AddWithValue("flag30", f30);
                    cmd.Parameters.AddWithValue("flag60", f60);
                    cmd.Parameters.AddWithValue("documentacion", data.documentacion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                resp = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                resp = false;
            }
            return resp;
        }

        public string DescargaFechas(REQUEST_FECHAS data)
        {
            DataTable excel = new DataTable();
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    using (var exp = new SqlDataAdapter())
                    {
                        exp.SelectCommand = new SqlCommand("Reporte", conexion);
                        exp.SelectCommand.CommandType = CommandType.StoredProcedure;
                        exp.SelectCommand.Parameters.AddWithValue("@desde", data.fechaIni);
                        exp.SelectCommand.Parameters.AddWithValue("@hasta", data.fechaFin);
                        exp.Fill(excel);
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return JsonConvert.SerializeObject(excel);
        }

        public List<FullTFideicomisosResponse> FiltraDatos(string fl)
        {
            var ListaFiltrada = new List<FullTFideicomisosResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Filtro", conexion);
                cmd.Parameters.AddWithValue("productor", fl);
                cmd.Parameters.AddWithValue("ci", fl);
                cmd.Parameters.AddWithValue("pago", fl);
                cmd.Parameters.AddWithValue("estado", fl);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FullTFideicomisosResponse()
                        {
                            Empresa = dr["Empresa"].ToString(),
                            Nlista = Convert.ToInt32(dr["Nlista"]),
                            Productor = dr["Productor"].ToString(),
                            CI = dr["CI"].ToString(),
                            Cultivo = dr["Cultivo"].ToString(),
                            Variedad = dr["Variedad"].ToString(),
                            VSemilla = Convert.ToSingle(dr["VSemilla"]),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            STotal = Convert.ToDecimal(dr["STotal"]),
                            RImpuestos5 = Convert.ToSingle(dr["RImpuestos5"]),
                            RImpuestos3 = Convert.ToSingle(dr["RImpuestos3"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            DgastosOperativos = Convert.ToDecimal(dr["DgastosOperativos"]),
                            LPagable = Convert.ToDecimal(dr["LPagable"]),
                            Municipio = dr["Municipio"].ToString(),
                            Comunidad = dr["Comunidad"].ToString(),
                            NFuncionario = dr["NFuncionario"].ToString(),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            EPago = dr["EPago"].ToString(),
                            FPago = Convert.ToDateTime(dr["FPago"]),
                            Dias = dr["Dias"] != System.DBNull.Value ? Convert.ToInt32(dr["Dias"]) : 0,
                            FCobro = Convert.ToDateTime(dr["FCobro"]),
                            ECobro = dr["ECobro"].ToString(),
                            Documentacion = dr["Documentacion"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            HoraRegistro = dr["HoraRegistro"].ToString()
                        });

                    }
                }
            }
            return ListaFiltrada;
        }
    }
}
