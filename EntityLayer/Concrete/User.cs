using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Concrete
{
    public class User:IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [StringLength(25)]
        [Required]
        public string UserName { get; set; }
        [StringLength(15)]
        [Required]
        public string Password { get; set; }

        public string TokenKey { get; set; }
    }
}
