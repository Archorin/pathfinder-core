using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("dv")]
    public class DV
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("nom", TypeName = "varchar(3)")]
        public string Nom { get; set; }

        public List<Classe> Classes { get; set; }
    }
}