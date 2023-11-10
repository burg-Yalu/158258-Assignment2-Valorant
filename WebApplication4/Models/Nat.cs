using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass2_Valorant.Models
{
    public class Nat
    {
        [Key]
        public int ID { get; set;}
        public string Nation { get; set;}
        public virtual ICollection<Player> Player { get; set;}
    }
}