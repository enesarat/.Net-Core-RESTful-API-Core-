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
        public List<Agent> Get()
        {
            return manageAgent.GetAllElement();
        }
        
        [HttpGet("{id}")]
        public Agent Get(int id)
        {
            return manageAgent.GetElementById(id);
        }

        [HttpPost]
        public Agent Post([FromBody]Agent newAgent)
        {
            return manageAgent.InsertElement(newAgent);
        }

        [HttpPut]
        public Agent Put([FromBody]Agent oldAgent)
        {
            return manageAgent.UpdateElement(oldAgent);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            manageAgent.DeleteElement(id);
        }
    }
}
