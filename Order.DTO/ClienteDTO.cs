using System;

namespace Order.DTO
{
    public class ClienteDTO
    {
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
