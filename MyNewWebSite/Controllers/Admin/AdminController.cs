using Microsoft.AspNetCore.Mvc;
using MyNewWebSite.AccessLayer.Models;
using MyNewWebSite.Core.Classes;
using MyNewWebSite.Core.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyNewWebSite.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public AdminController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }
        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var useraccount = _repository.Owner.FindByCondotion(x =>x.Age == 0);
            var owner = _repository.Owner.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET api/<AdminController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdminController>
        //[HasPermission(AllPermission.Full)]
        [HttpPost("login")]
        public void Post([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            else
            {

            }
        }

        // PUT api/<AdminController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
