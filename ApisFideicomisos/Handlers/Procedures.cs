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

        public string Descarga(string fi, string ff)
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
                        exp.SelectCommand = new SqlCommand("ReporteFMP", conexion);
                        exp.SelectCommand.CommandType = CommandType.StoredProcedure;
                        exp.SelectCommand.Parameters.AddWithValue("@desde", fi);
                        exp.SelectCommand.Parameters.AddWithValue("@hasta", ff);
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

        public FullTFimypeResponse GetId(int Posicion)
        {
            var BDD = new FullTFideicomisosResponse();
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
                        BDD.IdTabla = Convert.ToInt32(dr["IdTabla"]);
                        BDD.Regional = dr["Regional"].ToString();
                        BDD.Agencia = dr["Agencia"].ToString();
                        BDD.FechaProceso = Convert.ToDateTime(dr["FechaProceso"]);
                        BDD.NroOperacion = Convert.ToInt32(dr["NroOperacion"]);
                        BDD.DocIdentidad = Convert.ToInt32(dr["DocIdentidad"]);
                        BDD.CodCliente = Convert.ToInt32(dr["CodCliente"]);
                        BDD.NombreTitular = dr["NombreTitular"].ToString();
                        BDD.Moneda = dr["Moneda"].ToString();
                        BDD.Estado = dr["Estado"].ToString();
                        BDD.MontDesembolsdoBS = Convert.ToDecimal(dr["MontDesembolsdoBS"]);
                        BDD.MontDesembolsdoUSD = Convert.ToDecimal(dr["MontDesembolsdoUSD"]);
                        BDD.SaldoBS = Convert.ToDecimal(dr["SaldoBS"]);
                        BDD.SaldoUSD = Convert.ToDecimal(dr["SaldoUSD"]);
                        BDD.PrevisionBS = Convert.ToDecimal(dr["PrevisionBS"]);
                        BDD.PrevisionUSD = Convert.ToDecimal(dr["PrevisionUSD"]);
                        BDD.PrevisCiclicaBS = Convert.ToDecimal(dr["PrevisCiclicaBS"]);
                        BDD.PrevisCiclicaUSD = Convert.ToDecimal(dr["PrevisCiclicaUSD"]);
                        BDD.ProdDevengadosBS = Convert.ToDecimal(dr["ProdDevengadosBS"]);
                        BDD.ProdDevengadosUSD = Convert.ToDecimal(dr["ProdDevengadosUSD"]);
                        BDD.Plazo = dr["Plazo"].ToString(); ;
                        BDD.FechaVencimiento = Convert.ToDateTime(dr["FechaVencimiento"]);
                        BDD.FechaProxPago = Convert.ToDateTime(dr["FechaProxPago"]);
                    }
                }
            }
            return BDD;
        }

        public bool Eliminado(int pos)
        {
            bool resp;
            try
            {
                var cn = new Connection();
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
    }
}
