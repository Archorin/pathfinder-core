using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PathfinderCore.Models
{
    [Table("race")]
    public class Race
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("nom_slug", TypeName = "varchar(50)")]
        public string NomSlug { get; set; }

        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }
        
        [Column("ouvrage"), Required]
        public int OuvrageId { get; set; }
        public Ouvrage Ouvrage { get; set; }

        [Column("description", TypeName = "text")]
        public string Description { get; set; }

        [Column("description_plus", TypeName = "text")]
        public string DescriptionPlus { get; set; }

        [Column("description_physique", TypeName = "text")]
        public string DescriptionPhysique { get; set; }

        [Column("societe", TypeName = "text")]
        public string Societe { get; set; }

        [Column("relation", TypeName = "text")]
        public string Relation { get; set; }

        [Column("alignement_religion", TypeName = "text")]
        public string AlignementReligion { get; set; }

        [Column("aventurier", TypeName = "text")]
        public string Aventurier { get; set; }
    }
}