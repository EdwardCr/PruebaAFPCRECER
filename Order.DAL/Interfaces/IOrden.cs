using System;
using Order.DTO;

namespace Order.DAL.Interfaces
{
    public interface IOrden
    {
        int Actualizar(int id,OrdenDTO cliente);
        bool Eliminar(int id);
         OrdenDTO Obtener(int id);
        int Registrar(OrdenDTO cliente);
    }
}
