using ApisFideicomisos.Models;
using System.Data;
using System.Data.SqlClient;

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
    }
}
