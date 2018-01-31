using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;

namespace PathfinderCore.Models
{
    [Table("alignement")]
    public class Alignement
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("nom", TypeName = "varchar(50)")]
        public string Nom { get; set; }

        [Column("description", TypeName = "varchar(1000)")]
        public string Description { get; set; }

        private List<ClasseAlignement> ClasseAlignements { get; } = new List<ClasseAlignement>();

        [NotMapped]
        public IEnumerable<Classe> Classes => ClasseAlignements.Select(ca => ca.Classe);
    }
}