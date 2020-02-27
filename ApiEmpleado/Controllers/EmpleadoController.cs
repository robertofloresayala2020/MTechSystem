using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BussinesCore;
using Commons;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEmpleado.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        [HttpPost("ConsultaEmpleado")]
        public IActionResult GetEmpleado(Empleado empleado)
        {

            var response = new ResultObjectProcess<List<Empleado>>();

            try
            {
                using (var bussines = new Empleado())
                {
                  
                    response.Entity = bussines.GetEmpleados(empleado.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                response.Entity = null;
                response.Success = false;
                response.Message = ex.Message;


            }

            return Ok( response );
           
        }


       




        [HttpPost("AgregaEmpleado")]
        public IActionResult PostEmpleado(Empleado item)
        {
            var response = new ResultObjectProcess<int>();

            try
            {
                using (var bussines = new Empleado())
                {
                    if (bussines.ValidaRFCUnico(item))
                        response.Entity = bussines.AddEmpleados(item);
                    else
                        {
                        response.Entity = 0;
                        response.Success = false;
                        response.Message = "Ya existe un empleado con el RFC:" + item.RFC;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Entity = 0;
                response.Success = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
        

    }
}
