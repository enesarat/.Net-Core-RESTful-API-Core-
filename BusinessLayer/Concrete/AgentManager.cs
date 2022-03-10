using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AgentManager : IAgentService
    {
        IAgentDAL agentAccess;
        public AgentManager(IAgentDAL agentAccess)
        {
            this.agentAccess = agentAccess;
        }
        public async Task DeleteElement(int id)
        {
            await agentAccess.DeleteItem(id);
        }

        public async Task<List<Agent>> GetAllElement()
        {
            var agentList = await agentAccess.GetAllItems();
            return agentList;
        }

        public async Task<Agent> GetElementById(int id)
        {
            var agent = await agentAccess.GetItemById(id);
            return agent;
        }

        public async Task<Agent> InsertElement(Agent item)
        {
            await agentAccess .InsertItem(item);
            return item;
        }

        public async Task<Agent> UpdateElement(Agent item)
        {
            await agentAccess .UpdateItem(item);
            return item;
        }
    }
}
