using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("statistique")]
    public class Statistique
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("niveau", TypeName = "tinyint"), Required]
        public int Niveau { get; set; }
        
        [Column("valeur", TypeName = "tinyint"), Required]
        public int Valeur { get; set; }

        [Column("courbe"), Required]
        public int CourbeId { get; set; }
        public Courbe Courbe { get; set; }
    }
}