using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADOEstado
{
    class ConeccionADO_Estado
    {
        private string _conneccion;

        public ConeccionADO_Estado()
        {
            this._conneccion = ConfigurationManager.ConnectionStrings["InstitutoConnection"].ConnectionString;
        }

        public void Eliminar(int id)
        {
            string query = $"DELETE FROM Estados WHERE id={id}";
            try
            {
                using (SqlConnection con = new SqlConnection(this._conneccion))
                {
                    SqlCommand command = new SqlCommand(query, con);
                    command.CommandType = CommandType.Text;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ea)
            {
                Console.WriteLine($"Error durante la Eliminacion: {ea}");
            }
        }

        public void Actualizar(int id, string Nombre)
        { 
            try
            {
                using (SqlConnection coneccion = new SqlConnection(this._conneccion))
                {
                    SqlCommand comando = new SqlCommand($"UPDATE Estados SET Nombre='{Nombre}' WHERE id={id}", coneccion);
                    comando.CommandType = CommandType.Text;
                    coneccion.Open();
                    comando.ExecuteScalar();
                    coneccion.Close();
                }
            }
            catch (Exception ea)
            {
                throw new Exception("Error al Actualizar el Estado", ea);
            }
        }

        public int AgregarEstado(string nombre)
        {
            int x;
            try
            {
                using (SqlConnection coneccion = new SqlConnection(this._conneccion))
                {
                    SqlCommand comando = new SqlCommand($"spAgregarEstado", coneccion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@nombreEstado", nombre));
                    coneccion.Open();
                    x = (Int32)comando.ExecuteNonQuery();
                    coneccion.Close();
                    return x;
                }
            }
            catch (Exception ea)
            {
                throw new Exception("Error al Agregar", ea);
                /*-spAgregarEstado
                   CREATE PROCEDURE spAgregarEstado
                   (	
	                    @nombreEstado varchar(60)
                   )
                   AS 
                   BEGIN
	               INSERT INTO dbo.Estados(Nombre) VALUES(@nombreEstado)
                   END
                 */
            }
        }

        public Estado Consultar(int id)
        {
            Estado edo = new Estado();
            try
            {
                using (SqlConnection con = new SqlConnection(this._conneccion))
                {
                    SqlCommand comando = new SqlCommand($"SELECT id, nombre FROM Estados WHERE id={id}", con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        edo = new Estado(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Nombre"]));
                    }
                    con.Close();
                    return edo;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Consultar", ex);
            }
        }

        public List<Estado> ConsultarLst()
        {
            List<Estado> ListaEstados = new List<Estado>();
            try
            {
                using (SqlConnection con = new SqlConnection(this._conneccion))
                {
                    SqlCommand comando = new SqlCommand("SELECT id, nombre FROM Estados WHERE 1=1", con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        ListaEstados.Add(new Estado(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Nombre"])));
                    }
                    con.Close();
                    return ListaEstados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Consultar", ex);
            }
        }

        public DataTable Consultar()
        {
            DataTable dtEstados = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_conneccion))
                {
                    SqlCommand comando = new SqlCommand("SELECT * FROM Estados", con);
                    comando.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(dtEstados);
                    con.Close();
                    return dtEstados;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Consultar", ex);
            }
        }
    }
}
