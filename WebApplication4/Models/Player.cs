using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Ass2_Valorant.Models
{
    public class Player
    {
        [Key]
        public string ID { get; set; }
        public int Rank { get; set; }
        public int? NatID { get; set; }
        public virtual Nat Region { get; set; }
    }
}