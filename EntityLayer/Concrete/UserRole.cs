using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class UserRole : IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        [StringLength(25)]
        [Required]
        public string RoleName { get; set; }
        public List<User> Users { get; set; }

    }
}
