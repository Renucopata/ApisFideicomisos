using ApisFideicomisos.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Reflection;

namespace ApisFideicomisos.Handlers
{
    public class Procedures
    {

        //logica.cs file
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

        public bool CargaEditable(REQUEST_EDITABLES data) 
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

        public List<FullTFideicomisosResponse> ExaminaDatos(string fmin)
        {
            var ListaFiltrada = new List<FullTFideicomisosResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Examina", conexion);
                cmd.Parameters.AddWithValue("@desde", fmin);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FullTFideicomisosResponse()
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
                            Documentacion = dr["Documentacion"].ToString(),
                            Usuario = dr["Usuario"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            HoraRegistro = dr["HoraRegistro"]?.ToString()
                        });

                    }
                }
            }
            return ListaFiltrada;
        }

        public bool Eliminado(int pos)
        {
            bool resp;
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdTabla", pos);
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

        //Procedimientos Fimype file

        public List<FullTFimypeResponse> TablaFimype()
        {
            var ListaDatos = new List<FullTFimypeResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("LeeFimype", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaDatos.Add(new FullTFimypeResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            FechaProceso = Convert.ToDateTime(dr["FechaProceso"]),
                            NroOperacion = dr["NroOperacion"] != System.DBNull.Value ? Convert.ToInt32(dr["NroOperacion"]) : 0,
                            DocIdentidad = dr["DocIdentidad"] != System.DBNull.Value ? Convert.ToInt32(dr["DocIdentidad"]) : 0,
                            CodCliente = dr["CodCliente"] != System.DBNull.Value ? Convert.ToInt32(dr["CodCliente"]) : 0,
                            NombreTitular = dr["NombreTitular"].ToString(),
                            Moneda = dr["Moneda"].ToString(),
                            Estado = dr["Estado"].ToString(),
                            MontDesembolsdoBS = dr["MontDesembolsdoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoBS"]) : 0,
                            MontDesembolsdoUSD = dr["MontDesembolsdoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoUSD"]) : 0,
                            SaldoBS = dr["SaldoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoBS"]) : 0,
                            SaldoUSD = dr["SaldoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoUSD"]) : 0,
                            PrevisionBS = dr["PrevisionBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionBS"]) : 0,
                            PrevisionUSD = dr["PrevisionUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionUSD"]) : 0,
                            PrevisCiclicaBS = dr["PrevisCiclicaBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaBS"]) : 0,
                            PrevisCiclicaUSD = dr["PrevisCiclicaUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaUSD"]) : 0,
                            ProdDevengadosBS = dr["ProdDevengadosBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosBS"]) : 0,
                            ProdDevengadosUSD = dr["ProdDevengadosUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosUSD"]) : 0,
                            Plazo = dr["Plazo"].ToString(),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                            FechaProxPago = Convert.ToDateTime(dr["FechaProxPago"]),
                            MontPagadoCapital = dr["MontPagadoCapital"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoCapital"]) : 0,
                            MontPagadoIntereses = dr["MontPagadoIntereses"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoIntereses"]) : 0,
                            EstadoPago = dr["EstadoPago"].ToString(),
                            FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                            NumeroCuota = dr["NumeroCuota"] != System.DBNull.Value ? Convert.ToInt32(dr["NumeroCuota"]) : 0,
                            FechaCarga = Convert.ToDateTime(dr["fechaCargaXlsx"]),
                            Usuario = dr["Usuario"].ToString(),
                            HoraR = dr["HoraRegistro"].ToString()
                        });
                    }
                }
            }
            return ListaDatos;
        }

        public List<FimypefiltradoResponse> Filtrado(string fl)
        {
            var ListaFiltrada = new List<FimypefiltradoResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("FiltroFMP", conexion);
                if (int.TryParse(fl, out int num))
                    num = Int32.Parse(fl);
                else
                    num = 0;
                cmd.Parameters.AddWithValue("docid", num);
                cmd.Parameters.AddWithValue("codcliente", num);
                cmd.Parameters.AddWithValue("estadopago", fl);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FimypefiltradoResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            FechaProceso = Convert.ToDateTime(dr["FechaProceso"]),
                            NroOperacion = dr["NroOperacion"] != System.DBNull.Value ? Convert.ToInt32(dr["NroOperacion"]) : 0,
                            DocIdentidad = dr["DocIdentidad"] != System.DBNull.Value ? Convert.ToInt32(dr["DocIdentidad"]) : 0,
                            CodCliente = dr["CodCliente"] != System.DBNull.Value ? Convert.ToInt32(dr["CodCliente"]) : 0,
                            NombreTitular = dr["NombreTitular"].ToString(),
                            Moneda = dr["Moneda"].ToString(),
                            Estado = dr["Estado"].ToString(),
                            MontDesembolsdoBS = dr["MontDesembolsdoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoBS"]) : 0,
                            MontDesembolsdoUSD = dr["MontDesembolsdoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoUSD"]) : 0,
                            SaldoBS = dr["SaldoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoBS"]) : 0,
                            SaldoUSD = dr["SaldoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoUSD"]) : 0,
                            PrevisionBS = dr["PrevisionBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionBS"]) : 0,
                            PrevisionUSD = dr["PrevisionUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionUSD"]) : 0,
                            PrevisCiclicaBS = dr["PrevisCiclicaBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaBS"]) : 0,
                            PrevisCiclicaUSD = dr["PrevisCiclicaUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaUSD"]) : 0,
                            ProdDevengadosBS = dr["ProdDevengadosBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosBS"]) : 0,
                            ProdDevengadosUSD = dr["ProdDevengadosUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosUSD"]) : 0,
                            Plazo = dr["Plazo"].ToString(),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                            FechaProxPago = Convert.ToDateTime(dr["FechaProxPago"]),
                            MontPagadoCapital = dr["MontPagadoCapital"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoCapital"]) : 0,
                            MontPagadoIntereses = dr["MontPagadoIntereses"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoIntereses"]) : 0,
                            EstadoPago = dr["EstadoPago"].ToString(),
                            FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                            NumeroCuota = dr["NumeroCuota"] != System.DBNull.Value ? Convert.ToInt32(dr["NumeroCuota"]) : 0
                            
                        });

                    }
                }
            }
            return ListaFiltrada;
        }

        public JsonArray Descarga(string fi, string ff)
        {
            JsonArray jsonArray = new JsonArray();
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    using (var exp = new SqlDataAdapter())
                    {
                        exp.SelectCommand = new SqlCommand("ReporteFMP", conexion);
                        exp.SelectCommand.CommandType = CommandType.StoredProcedure;
                        exp.SelectCommand.Parameters.AddWithValue("@desde", fi);
                        exp.SelectCommand.Parameters.AddWithValue("@hasta", ff);
                        DataTable excel = new DataTable();
                        exp.Fill(excel);
                        foreach (DataRow row in excel.Rows)
                        {
                            JsonObject jsonObject = new JsonObject();
                            foreach (DataColumn column in excel.Columns)
                            {
                                jsonObject.Add(column.ColumnName, row[column].ToString());
                            }
                            jsonArray.Add(jsonObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return jsonArray;
        }

        public List<FechasFimypeResponse> FechasT(string fmin)
        {
            var ListaFiltrada = new List<FechasFimypeResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Historico", conexion);
                cmd.Parameters.AddWithValue("@desde", fmin);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FechasFimypeResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            FechaProceso = Convert.ToDateTime(dr["FechaProceso"]),
                            NroOperacion = dr["NroOperacion"] != System.DBNull.Value ? Convert.ToInt32(dr["NroOperacion"]) : 0,
                            DocIdentidad = dr["DocIdentidad"] != System.DBNull.Value ? Convert.ToInt32(dr["DocIdentidad"]) : 0,
                            CodCliente = dr["CodCliente"] != System.DBNull.Value ? Convert.ToInt32(dr["CodCliente"]) : 0,
                            NombreTitular = dr["NombreTitular"].ToString(),
                            Moneda = dr["Moneda"].ToString(),
                            Estado = dr["Estado"].ToString(),
                            MontDesembolsdoBS = dr["MontDesembolsdoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoBS"]) : 0,
                            MontDesembolsdoUSD = dr["MontDesembolsdoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontDesembolsdoUSD"]) : 0,
                            SaldoBS = dr["SaldoBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoBS"]) : 0,
                            SaldoUSD = dr["SaldoUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["SaldoUSD"]) : 0,
                            PrevisionBS = dr["PrevisionBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionBS"]) : 0,
                            PrevisionUSD = dr["PrevisionUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisionUSD"]) : 0,
                            PrevisCiclicaBS = dr["PrevisCiclicaBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaBS"]) : 0,
                            PrevisCiclicaUSD = dr["PrevisCiclicaUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["PrevisCiclicaUSD"]) : 0,
                            ProdDevengadosBS = dr["ProdDevengadosBS"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosBS"]) : 0,
                            ProdDevengadosUSD = dr["ProdDevengadosUSD"] != System.DBNull.Value ? Convert.ToDecimal(dr["ProdDevengadosUSD"]) : 0,
                            Plazo = dr["Plazo"].ToString(),
                            FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]),
                            FechaProxPago = Convert.ToDateTime(dr["FechaProxPago"]),
                            MontPagadoCapital = dr["MontPagadoCapital"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoCapital"]) : 0,
                            MontPagadoIntereses = dr["MontPagadoIntereses"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoIntereses"]) : 0,
                            EstadoPago = dr["EstadoPago"].ToString(),
                            FechaPago = Convert.ToDateTime(dr["FechaPago"]),
                            NumeroCuota = dr["NumeroCuota"] != System.DBNull.Value ? Convert.ToInt32(dr["NumeroCuota"]) : 0,
                            Usuario = dr["Usuario"].ToString(),
                            HoraR = dr["HoraRegistro"].ToString()
                        });
                    }
                }
            }
            return ListaFiltrada;
        }

        public TFimypeByIDResponse GetId(int Posicion)
        {
            var response = new TFimypeByIDResponse();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("IdFMP", conexion);
                cmd.Parameters.AddWithValue("pos", Posicion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        response.IdTabla = Convert.ToInt32(dr["IdTabla"]);
                        response.Regional = dr["Regional"].ToString();
                        response.Agencia = dr["Agencia"].ToString();
                        response.FechaProceso = Convert.ToDateTime(dr["FechaProceso"]);
                        response.NroOperacion = Convert.ToInt32(dr["NroOperacion"]);
                        response.DocIdentidad = Convert.ToInt32(dr["DocIdentidad"]);
                        response.CodCliente = Convert.ToInt32(dr["CodCliente"]);
                        response.NombreTitular = dr["NombreTitular"].ToString();
                        response.Moneda = dr["Moneda"].ToString();
                        response.Estado = dr["Estado"].ToString();
                        response.MontDesembolsdoBS = Convert.ToDecimal(dr["MontDesembolsdoBS"]);
                        response.MontDesembolsdoUSD = Convert.ToDecimal(dr["MontDesembolsdoUSD"]);
                        response.SaldoBS = Convert.ToDecimal(dr["SaldoBS"]);
                        response.SaldoUSD = Convert.ToDecimal(dr["SaldoUSD"]);
                        response.PrevisionBS = Convert.ToDecimal(dr["PrevisionBS"]);
                        response.PrevisionUSD = Convert.ToDecimal(dr["PrevisionUSD"]);
                        response.PrevisCiclicaBS = Convert.ToDecimal(dr["PrevisCiclicaBS"]);
                        response.PrevisCiclicaUSD = Convert.ToDecimal(dr["PrevisCiclicaUSD"]);
                        response.ProdDevengadosBS = Convert.ToDecimal(dr["ProdDevengadosBS"]);
                        response.ProdDevengadosUSD = Convert.ToDecimal(dr["ProdDevengadosUSD"]);
                        response.Plazo = dr["Plazo"].ToString(); ;
                        response.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                        response.FechaProxPago = Convert.ToDateTime(dr["FechaProxPago"]);
                        response.MontPagadoCapital = dr["MontPagadoCapital"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoCapital"]) : 0;
                        response.MontPagadoIntereses = dr["MontPagadoIntereses"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontPagadoIntereses"]) : 0;
                        response.EstadoPago = Convert.ToString(dr["EstadoPago"]);
                        response.FechaPago = Convert.ToDateTime(dr["FechaPago"]);
                        response.NumeroCuota = dr["NumeroCuota"] != System.DBNull.Value ? Convert.ToInt32(dr["NumeroCuota"]) : 0;
                        response.FechaCarga = Convert.ToDateTime(dr["fechaCargaXlsx"]);
                        response.Usuario = Convert.ToString(dr["Usuario"]);
                        response.HoraR = Convert.ToString(dr["HoraRegistro"]);
                    }
                }
            }
            return response;
        }

        public bool eliminarFMP(int pos)
        {
            bool resp;
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("EliminarFMP", conexion);
                    cmd.Parameters.AddWithValue("IdTabla", pos);
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


        //Fogacp


        public List<FullFogacpResponse> TablaFogacp()
        {
            var ListaDatos = new List<FullFogacpResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("LeeFogacp", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaDatos.Add(new FullFogacpResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]),
                            OfCredito = dr["OfCredito"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            NumeroPrestamo = dr["NumeroPrestamo"] != System.DBNull.Value ? Convert.ToInt64(dr["NumeroPrestamo"]) : 0,
                            IdSolicitud = dr["IdSolicitud"] != System.DBNull.Value ? Convert.ToInt64(dr["IdSolicitud"]) : 0,
                            Monto = dr["Monto"] != System.DBNull.Value ? Convert.ToDecimal(dr["Monto"]) : 0,
                            Plazo = dr["Plazo"] != System.DBNull.Value ? Convert.ToInt32(dr["Plazo"]) : 0,
                            Cobertura = dr["Cobertura"] is DBNull ? 0 : double.Parse(Convert.ToString(dr["Cobertura"])),
                            Garantias = dr["Garantias"].ToString(),
                            MontoGarant = dr["MontoGarant"].ToString(),
                            NA = dr["NA"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Actividad = dr["Actividad"].ToString(),
                            DestinoFondos = dr["DestinoFondos"].ToString(),
                            CoberturaSolicitada = dr["CoberturaSolicitada"] != System.DBNull.Value ? Convert.ToDecimal(dr["CoberturaSolicitada"]) : 0,
                            Nuevo = dr["Nuevo"].ToString(),
                            MontoMinimo = dr["MontoMinimo"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoMinimo"]) : 0,
                            AR = dr["AR"].ToString(),
                            FechaDesembolso = Convert.ToDateTime(dr["FechaDesembolso"]),
                            Estado = dr["Estado"].ToString(),
                            Notas = dr["Notas"].ToString(),
                            Mes = dr["Mes"] != System.DBNull.Value ? Convert.ToInt32(dr["Mes"]) : 0,
                            MaximoGarantias = dr["MaximoGarantias"].ToString(),
                            MontoDesembolsado = dr["MontoDesembolsado"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoDesembolsado"]) : 0,
                            EstadoPrestamo = dr["EstadoPrestamo"].ToString()
                        });
                    }
                }
            }
            return ListaDatos;
        }


        public bool editablesEstado(int pos, string est)
        {
            var cn = new ConnectionADFideicomisos();
            bool resp;
            try
            {
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditaEstado", conexion);
                    cmd.Parameters.AddWithValue("id", pos);
                    cmd.Parameters.AddWithValue("estado", est);
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

        public bool editablesNotas(int pos, string note)
        {
            var cn = new ConnectionADFideicomisos();
            bool resp;
            try
            {
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditaNotas", conexion);
                    cmd.Parameters.AddWithValue("id", pos);
                    cmd.Parameters.AddWithValue("notas", note);
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

        public bool editGarantias(int pos, string sn)
        {
            var cn = new ConnectionADFideicomisos();
            bool resp;
            try
            {
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EditaGarantias", conexion);
                    cmd.Parameters.AddWithValue("id", pos);
                    cmd.Parameters.AddWithValue("garantias", sn);
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

        public List<FullFogacpResponse> filtroFogacp(string fl)
        {
            var ListaFiltrada = new List<FullFogacpResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("FiltroFP", conexion);
                if (Int64.TryParse(fl, out long num))
                    num = Int64.Parse(fl);
                else
                    num = 0;
                cmd.Parameters.AddWithValue("sucursal", fl);
                cmd.Parameters.AddWithValue("agencia", fl);
                cmd.Parameters.AddWithValue("nombre", fl);
                cmd.Parameters.AddWithValue("id", num);
                cmd.Parameters.AddWithValue("estado", fl);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FullFogacpResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]),
                            OfCredito = dr["OfCredito"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            NumeroPrestamo = dr["NumeroPrestamo"] != System.DBNull.Value ? Convert.ToInt64(dr["NumeroPrestamo"]) : 0,
                            IdSolicitud = dr["IdSolicitud"] != System.DBNull.Value ? Convert.ToInt64(dr["IdSolicitud"]) : 0,
                            Monto = dr["Monto"] != System.DBNull.Value ? Convert.ToDecimal(dr["Monto"]) : 0,
                            Plazo = dr["Plazo"] != System.DBNull.Value ? Convert.ToInt32(dr["Plazo"]) : 0,
                            Cobertura = dr["Cobertura"] is DBNull ? 0 : double.Parse(Convert.ToString(dr["Cobertura"])),
                            Garantias = dr["Garantias"].ToString(),
                            MontoGarant = dr["MontoGarant"].ToString(),
                            NA = dr["NA"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Actividad = dr["Actividad"].ToString(),
                            DestinoFondos = dr["DestinoFondos"].ToString(),
                            CoberturaSolicitada = dr["CoberturaSolicitada"] != System.DBNull.Value ? Convert.ToDecimal(dr["CoberturaSolicitada"]) : 0,
                            Nuevo = dr["Nuevo"].ToString(),
                            MontoMinimo = dr["MontoMinimo"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoMinimo"]) : 0,
                            AR = dr["AR"].ToString(),
                            FechaDesembolso = Convert.ToDateTime(dr["FechaDesembolso"]),
                            Estado = dr["Estado"].ToString(),
                            Notas = dr["Notas"].ToString(),
                            Mes = dr["Mes"] != System.DBNull.Value ? Convert.ToInt32(dr["Mes"]) : 0,
                            MaximoGarantias = dr["MaximoGarantias"].ToString(),
                            MontoDesembolsado = dr["MontoDesembolsado"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoDesembolsado"]) : 0,
                            EstadoPrestamo = dr["EstadoPrestamo"].ToString()
                        });

                    }
                }
            }
            return ListaFiltrada;
        }

        public List<FullFogacpResponse> fechasFP(string fmin, string fmax)
        {
            var ListaFiltrada = new List<FullFogacpResponse>();
            var cn = new ConnectionADFideicomisos();
            using (var conexion = new SqlConnection(cn.get_cadConexion()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("FechasFogacp", conexion);
                cmd.Parameters.AddWithValue("@desde", fmin);
                cmd.Parameters.AddWithValue("@hasta", fmax);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListaFiltrada.Add(new FullFogacpResponse()
                        {
                            IdTabla = Convert.ToInt32(dr["IdTabla"]),
                            Sucursal = dr["Sucursal"].ToString(),
                            Agencia = dr["Agencia"].ToString(),
                            FechaSolicitud = Convert.ToDateTime(dr["FechaSolicitud"]),
                            OfCredito = dr["OfCredito"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            NumeroPrestamo = dr["NumeroPrestamo"] != System.DBNull.Value ? Convert.ToInt64(dr["NumeroPrestamo"]) : 0,
                            IdSolicitud = dr["IdSolicitud"] != System.DBNull.Value ? Convert.ToInt64(dr["IdSolicitud"]) : 0,
                            Monto = dr["Monto"] != System.DBNull.Value ? Convert.ToDecimal(dr["Monto"]) : 0,
                            Plazo = dr["Plazo"] != System.DBNull.Value ? Convert.ToInt32(dr["Plazo"]) : 0,
                            Cobertura = dr["Cobertura"] is DBNull ? 0 : double.Parse(Convert.ToString(dr["Cobertura"])),
                            Garantias = dr["Garantias"].ToString(),
                            MontoGarant = dr["MontoGarant"].ToString(),
                            NA = dr["NA"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Actividad = dr["Actividad"].ToString(),
                            DestinoFondos = dr["DestinoFondos"].ToString(),
                            CoberturaSolicitada = dr["CoberturaSolicitada"] != System.DBNull.Value ? Convert.ToDecimal(dr["CoberturaSolicitada"]) : 0,
                            Nuevo = dr["Nuevo"].ToString(),
                            MontoMinimo = dr["MontoMinimo"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoMinimo"]) : 0,
                            AR = dr["AR"].ToString(),
                            FechaDesembolso = Convert.ToDateTime(dr["FechaDesembolso"]),
                            Estado = dr["Estado"].ToString(),
                            Notas = dr["Notas"].ToString(),
                            Mes = dr["Mes"] != System.DBNull.Value ? Convert.ToInt32(dr["Mes"]) : 0,
                            MaximoGarantias = dr["MaximoGarantias"].ToString(),
                            MontoDesembolsado = dr["MontoDesembolsado"] != System.DBNull.Value ? Convert.ToDecimal(dr["MontoDesembolsado"]) : 0,
                            EstadoPrestamo = dr["EstadoPrestamo"].ToString()
                        });
                    }
                }
            }
            return ListaFiltrada;
        }

        public JsonArray ReporteFP(string fi, string ff)
        {
            JsonArray jsonArray = new JsonArray();
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    using (var exp = new SqlDataAdapter())
                    {
                        exp.SelectCommand = new SqlCommand("DescargaFP", conexion);
                        exp.SelectCommand.CommandType = CommandType.StoredProcedure;
                        exp.SelectCommand.Parameters.AddWithValue("@desde", fi);
                        exp.SelectCommand.Parameters.AddWithValue("@hasta", ff);
                        DataTable excel = new DataTable();
                        exp.Fill(excel);
                        foreach (DataRow row in excel.Rows)
                        {
                            JsonObject jsonObject = new JsonObject();
                            foreach (DataColumn column in excel.Columns)
                            {
                                jsonObject.Add(column.ColumnName, row[column].ToString());
                            }
                            jsonArray.Add(jsonObject);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return jsonArray;
        }

        public int cargaPlanilla(List<REQUEST_EXCEL_FIDEICO> BDD, string Saul)
        {
            var aux = new DataTable();
          
            foreach (var excelRow in BDD)
            {
                aux.Rows.Add(excelRow);
            }

            int resp;
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CargaTex", conexion);
                    cmd.Parameters.Add("TEx", SqlDbType.Structured).Value = aux;
                    cmd.Parameters.Add("flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("saul", Saul);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    resp = Convert.ToInt32(cmd.Parameters["flag"].Value);

                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
                resp = 0;
            }
            return resp;
        }

        public int cargaPlanillaFMP(List<REQUEST_EXCEL_FMP> BDD, string Saul)
        {
            var aux = new DataTable();

            foreach (var excelRow in BDD)
            {
                aux.Rows.Add(excelRow);
            }

            int resp;
            try
            {
                var cn = new ConnectionADFideicomisos();
                using (var conexion = new SqlConnection(cn.get_cadConexion()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("CargaTexFMP", conexion);
                    cmd.Parameters.Add("TEx", SqlDbType.Structured).Value = aux;
                    cmd.Parameters.Add("flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("saul", Saul);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    resp = Convert.ToInt32(cmd.Parameters["flag"].Value);

                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.ToString();
                resp = 0;
            }
            return resp;
        }
    }
}
