using System;
using Order.DAL.Interfaces;
using Order.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Order.DAL
{
    public class OrdenDal : IOrden
    {
        public  int Actualizar(int id,OrdenDTO orden)
        {
            int respuesta = 0;

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    SqlCommand query = new SqlCommand("UPDATE Ordenes SET LibroId=@p0,title= @p1, author=@p2,url_download=@p3,thumbnail=@p4 WHERE OrdenId=@p5", con);

                    query.Parameters.AddWithValue("@p0", orden.LibroId);
                    query.Parameters.AddWithValue("@p1", orden.title);
                    query.Parameters.AddWithValue("@p2", orden.author);
                    query.Parameters.AddWithValue("@p3", orden.url_download);
                    query.Parameters.AddWithValue("@p4", orden.thumbnail);
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

                    SqlCommand query = new SqlCommand("Delete from Ordenes where OrdenId=@p1", con);
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

        public OrdenDTO Obtener(int id)
        {
            OrdenDTO orden = new OrdenDTO();

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Ordenes WHERE OrdenId = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows) {

                            orden.OrdenId = Convert.ToInt32(dr["OrdenId"]);
                            orden.ClienteId = dr["ClienteId"].ToString();
                            orden.title = dr["title"].ToString();
                            orden.author = dr["author"].ToString();
                            orden.thumbnail = dr["thumbnail"].ToString();
                            orden.url_download = dr["url_download"].ToString();
                            orden.LibroId = dr["LibroId"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return orden;
        }

        public int Registrar(OrdenDTO orden)
        {
            int respuesta = 0;

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true"))
                {
                    con.Open();

                    SqlCommand query = new SqlCommand("INSERT INTO Ordenes(ClienteId, title,author,url_download, LibroId,thumbnail) VALUES (@p0, @p1, @p2,@p3,@p4,@p5)", con);

                    query.Parameters.AddWithValue("@p0", orden.ClienteId);
                    query.Parameters.AddWithValue("@p1", orden.title);
                    query.Parameters.AddWithValue("@p2", orden.author);
                    query.Parameters.AddWithValue("@p3", orden.url_download);
                    query.Parameters.AddWithValue("@p4", orden.LibroId);
                    query.Parameters.AddWithValue("@p5", orden.thumbnail);
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
        public List<OrdenDTO> Todo(){
              List<OrdenDTO> ordenes = new List<OrdenDTO>();

            try
            {
                using (var con = new SqlConnection("Server=localhost;Database=Ordenes;Trusted_Connection=True;MultipleActiveResultSets=true")) 
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM Ordenes", con);
                    using (var dr = query.ExecuteReader()) 
                    {
                        while (dr.Read()) 
                        {
                            
                            var orden =  new OrdenDTO { 
                            OrdenId = Convert.ToInt32(dr["OrdenId"]),
                            ClienteId = dr["ClienteId"].ToString(),
                            title = dr["title"].ToString(),
                            author = dr["author"].ToString(),
                            thumbnail = dr["thumbnail"].ToString(),
                            url_download = dr["url_download"].ToString(),
                            LibroId = dr["LibroId"].ToString()
                            };

                            
                            ordenes.Add(orden);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw;
            }

           return ordenes;
        }
    }
}
