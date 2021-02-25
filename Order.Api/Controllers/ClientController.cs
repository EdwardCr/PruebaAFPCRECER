using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Order.DAL;
using Order.DTO;

namespace Order.Api.Controllers
{
    [ApiController]
    [Route("client")]
    public class ClientController : ControllerBase
    {

        private ClienteDal clientedb =new ClienteDal();
        
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
           
            var resultado=clientedb.Obtener(id);  
          
            if(resultado.ClienteId==0){
                return NotFound();
            }else{
                return Ok(resultado);
            }

            
        }
    }
}
