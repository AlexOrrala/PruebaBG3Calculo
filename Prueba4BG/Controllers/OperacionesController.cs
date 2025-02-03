using Microsoft.AspNetCore.Mvc;
using Prueba4BG.Models;
using Prueba4BG.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba4BG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionesController : ControllerBase
    {
        public OperacionesServices _operacionesServices { get; set; }
        public OperacionesController(OperacionesServices operacionesServices) { 
        _operacionesServices = operacionesServices;
        }

        // POST api/<OperacionesController>
        [HttpPost]
        public Task<Operaciones> Post([FromBody] Operaciones body)
        {
            return _operacionesServices.Operar(body);
        }
        
        //// GET: api/<OperacionesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<OperacionesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// PUT api/<OperacionesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OperacionesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
