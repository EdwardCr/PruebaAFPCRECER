using System;
using Order.DTO;

namespace Order.DAL.Interfaces
{

    interface IName
    {
        
    }

    public interface ICliente
    {
        ClienteDTO Obtener(int id);
        int Registrar(ClienteDTO cliente);
        ClienteDTO Actualizar();
        int Eliminar(int id);
        
    }
}
