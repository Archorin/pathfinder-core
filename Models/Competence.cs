using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("competence")]
    public class Competence
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }

        [Column("sans_formation", TypeName = "bit"), Required]
        public bool SansFormation { get; set; }

        [Column("penalite_armure", TypeName = "bit"), Required]
        public bool PenaliteArmure { get; set; }

        [Column("caracteristique"), Required]
        public int CaracteristiqueId { get; set; }
        public Caracteristique Caracteristique { get; set; }
    }
}