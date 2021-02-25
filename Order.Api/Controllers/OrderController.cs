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
    [Route("orden")]
    public class OrderController : ControllerBase
    {

        private OrdenDal ordendb =new OrdenDal();
        
        [HttpGet]
        public  IActionResult GetAll()
        {
           
            var resultado=ordendb.Todo();
          
        return Ok(resultado);            
        }

        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
           
            var resultado=ordendb.Obtener(id);  
          
            if(resultado.OrdenId==0){
                return NotFound();
            }else{
                return Ok(resultado);
            }

            
        }
        [HttpPost]
        public IActionResult Create([FromBody] OrdenDTO orden){
            int resultado = ordendb.Registrar(orden);

            if(resultado!=0){
                return Ok(new {message="orden registrada"});
            }else{
                return Ok(new {message = "Client no registrada"});
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] OrdenDTO orden){
            int resultado = ordendb.Actualizar(id,orden);

            if(resultado!=0){
                return Ok(new {message="orden actualizado"});
            }else{
                return Ok(new {message = "No se pudo actualizar"});
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            bool resultado = ordendb.Eliminar(id);

            if(resultado){
                return Ok(new {message="orden eliminado"});
            }else{
                return Ok(new {message = "orden no se pudo eliminar"});
            }
            
        }

    }
}
