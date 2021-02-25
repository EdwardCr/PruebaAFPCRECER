using System;
using Order.DAL.Interfaces;
using Order.DTO;
using System.Data;
using System.Data.SqlClient;

namespace Order.DAL
{
    public class ClienteDal:ICliente
    {

        private SqlConnection con = new SqlConnection("");
        public  ClienteDTO Obtener(int id){
            return new ClienteDTO();
         }
       public int Registrar(ClienteDTO cliente){
            return 1;
        }
       public  ClienteDTO Actualizar(){
            return new ClienteDTO();
        }
        public int Eliminar(int id){
            return 1;
        }
    }
}
