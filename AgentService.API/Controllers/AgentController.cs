using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        //AgentManager manageAgent = new AgentManager(new EfAgentRepository());
        private IAgentService manageAgent;
        public AgentController(IAgentService agentService)
        {
            this.manageAgent = agentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manageAgent.GetAllElement()); // 200 + retrieved data 
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (manageAgent.GetElementById(id)!=null)
            {
                return Ok(manageAgent.GetElementById(id)); // 200 + retrieved data
            }
            return NotFound(); // 404
        }

        [HttpPost]
        public IActionResult Post([FromBody]Agent agent)
        {
            if (ModelState.IsValid)
            {
                var newAgent = manageAgent.InsertElement(agent);
                return CreatedAtAction("Get", new { agentId = newAgent.AgentId }, newAgent); // 201 + data + header info for data location
            }
            return BadRequest(ModelState); // 400 + validation errors
        }

        [HttpPut]
        public IActionResult Put([FromBody]Agent oldAgent)
        {
            if (manageAgent.GetElementById(oldAgent.AgentId)!=null)
            {
                return Ok(manageAgent.UpdateElement(oldAgent)); // 200 + data
            }
            return NotFound(); // 404 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (manageAgent.GetElementById(id) != null)
            {
                manageAgent.DeleteElement(id);
                return Ok(); // 200
            }
            return NotFound(); // 404 
        }
    }
}
