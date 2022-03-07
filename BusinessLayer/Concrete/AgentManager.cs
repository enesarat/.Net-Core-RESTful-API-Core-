using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AgentManager : IAgentSevice
    {
        IAgentDAL agentAccess;
        public AgentManager(IAgentDAL agentAccess)
        {
            this.agentAccess = agentAccess;
        }
        public void DeleteElement(int id)
        {
            agentAccess.DeleteItem(id);
        }

        public List<Agent> GetAllElement()
        {
            var agentList = agentAccess.GetAllItems();
            return agentList;
        }

        public Agent GetElementById(int id)
        {
            var agent = agentAccess.GetItemById(id);
            return agent;
        }

        public Agent InsertElement(Agent item)
        {
            agentAccess.InsertItem(item);
            return item;
        }

        public Agent UpdateElement(Agent item)
        {
            agentAccess.UpdateItem(item);
            return item;
        }
    }
}
