using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("personnage")]
    public class Personnage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
       
        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }
    }
}