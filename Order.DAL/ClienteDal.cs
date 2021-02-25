using System;
using Order.DAL.Interfaces;
using Order.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Order.DAL
{
    public class ClienteDal : ICliente
    {
        public  int Actualizar(int id,ClienteDTO cliente)
        {
            int respuesta = 0;

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    SqlCommand query = new SqlCommand("UPDATE Cliente SET Nombres=@p0,Apellidos= @p1, Fecha_nacimiento=@p2,telefono=@p3,email=@p4 WHERE ClienteId=@p5", con);

                    query.Parameters.AddWithValue("@p0", cliente.Nombres);
                    query.Parameters.AddWithValue("@p1", cliente.Apellidos);
                    query.Parameters.AddWithValue("@p2", cliente.Fecha_Nacimiento);
                    query.Parameters.AddWithValue("@p3", cliente.telefono);
                    query.Parameters.AddWithValue("@p4", cliente.email);
                    query.Parameters.AddWithValue("@p5", id);
                    query.ExecuteNonQuery();
                    respuesta = 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    SqlCommand query = new SqlCommand("Delete from Cliente where ClienteId=@p1", con);
                    query.Parameters.AddWithValue("@p1", id);
                    query.ExecuteNonQuery();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public ClienteDTO Obtener(int id)
        {
            ClienteDTO cliente = new ClienteDTO();

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Cliente WHERE ClienteId = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows) {
                            cliente.ClienteId = Convert.ToInt32(dr["ClienteId"]);
                            cliente.Nombres = dr["Nombres"].ToString();
                            cliente.Apellidos = dr["Apellidos"].ToString();
                            cliente.Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_nacimiento"]);
                            cliente.telefono=dr["telefono"].ToString();
                            cliente.email = dr["email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return cliente;
        }

        public int Registrar(ClienteDTO cliente)
        {
            int respuesta = 0;

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    SqlCommand query = new SqlCommand("INSERT INTO Cliente(Nombres, Apellidos,Fecha_nacimiento,telefono, email) VALUES (@p0, @p1, @p2,@p3,@p4)", con);

                    query.Parameters.AddWithValue("@p0", cliente.Nombres);
                    query.Parameters.AddWithValue("@p1", cliente.Apellidos);
                    query.Parameters.AddWithValue("@p2", cliente.Fecha_Nacimiento);
                    query.Parameters.AddWithValue("@p3", cliente.telefono);
                    query.Parameters.AddWithValue("@p4", cliente.email);
                    query.ExecuteNonQuery();
                    respuesta = 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }
    }
}
