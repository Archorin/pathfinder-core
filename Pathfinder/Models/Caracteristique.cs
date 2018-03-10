using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PathfinderCore.Models
{
    [Table("caracteristique")]
    public class Caracteristique
    {
        [Key]
        [Column("nom_court", TypeName = "varchar(5)")]
        public string Id { get; set; }

        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }

        [Column("description", TypeName = "varchar(1000)")]
        public string Description { get; set; }

        public List<Competence> Competences { get; set; }
    }
}