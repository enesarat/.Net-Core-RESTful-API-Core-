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

        /// <summary>
        /// Get all agents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manageAgent.GetAllElement()); // 200 + retrieved data 
        }
        
        /// <summary>
        /// Get agent by id property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetAgentById(int id)
        {
            if (manageAgent.GetElementById(id)!=null)
            {
                return Ok(manageAgent.GetElementById(id)); // 200 + retrieved data
            }
            return NotFound(); // 404
        }

        /// <summary>
        /// Add agent
        /// </summary>
        /// <param name="agent"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update the agent
        /// </summary>
        /// <param name="oldAgent"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody]Agent oldAgent)
        {
            if (manageAgent.GetElementById(oldAgent.AgentId)!=null)
            {
                return Ok(manageAgent.UpdateElement(oldAgent)); // 200 + data
            }
            return NotFound(); // 404 
        }

        /// <summary>
        /// Delete the agent by id property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteAgentById(int id)
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
