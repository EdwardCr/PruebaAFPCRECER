using System;

namespace Order.DTO
{
    public class OrdenDTO
    {
        public int OrdenId { get; set; }
        public string ClienteId { get; set; }
        public string LibroId { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string url_download { get; set; }
        public string thumbnail { get; set; }
    }
}
