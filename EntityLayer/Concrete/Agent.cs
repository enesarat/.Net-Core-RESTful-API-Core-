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
        [Required]
        public string AgentName { get; set; }
        [StringLength(50)]
        [Required]
        public string AgentManagerName{ get; set; }
        [StringLength(150)]
        [Required]
        public string AgentAddress { get; set; }
    }
}
