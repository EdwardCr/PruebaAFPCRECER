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
        

          [HttpGet]
        public  IActionResult GetAll()
        {
           
            var resultado=clientedb.Todo();
          
        return Ok(resultado);            
        }

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
        [HttpPost]
        public IActionResult Create([FromBody] ClienteDTO cliente){
            int resultado = clientedb.Registrar(cliente);

            if(resultado!=0){
                return Ok(new {message="Cliente registrado"});
            }else{
                return Ok(new {message = "Client no registrado"});
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] ClienteDTO cliente){
            int resultado = clientedb.Actualizar(id,cliente);

            if(resultado!=0){
                return Ok(new {message="Cliente actualizado"});
            }else{
                return Ok(new {message = "No se pudo actualizar"});
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool resultado = clientedb.Eliminar(id);

            if(resultado){
                return Ok(new {message="Cliente eliminado"});
            }else{
                return Ok(new {message = "Cliente no se pudo eliminar"});
            }
            
        }

    }
}
