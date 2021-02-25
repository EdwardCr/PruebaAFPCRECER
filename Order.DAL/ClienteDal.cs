using System;
using Order.DAL.Interfaces;
using Order.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Order.DAL
{
    public class ClienteDal : ICliente
    {
        public ClienteDTO Actualizar()
        {
            throw new NotImplementedException();
        }

        public int Eliminar(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
