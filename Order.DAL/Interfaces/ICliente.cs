using System;
using Order.DTO;

namespace Order.DAL.Interfaces
{
    public interface ICliente
    {
        int Actualizar(int id,ClienteDTO cliente);
        bool Eliminar(int id);
         ClienteDTO Obtener(int id);
        int Registrar(ClienteDTO cliente);
    }
}
