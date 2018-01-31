using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PathfinderCore.Models
{
    [Table("ouvrage")]
    public class Ouvrage
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("nom_slug", TypeName = "varchar(5)")]
        public string NomSlug { get; set; }

        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }

        public List<Race> Races { get; set; }
    }
}
