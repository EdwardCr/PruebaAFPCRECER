using System;
using System.Collections.Generic;
using Order.DTO;

namespace Order.DAL.Interfaces
{
    public interface ICliente
    {
        int Actualizar(int id,ClienteDTO cliente);
        bool Eliminar(int id);
         ClienteDTO Obtener(int id);
         List<ClienteDTO> Todo();
        int Registrar(ClienteDTO cliente);
    }
}
