using EntityLayer.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    public class Agent:IEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AgentId { get; set; }
        [StringLength(50)]
        public string AgentName { get; set; }
        [StringLength(150)]
        public string AgentAddress { get; set; }
    }
}
