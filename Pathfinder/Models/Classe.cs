using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PathfinderCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PathfinderCore.Models
{
    [Table("classe")]
    public class Classe
    {
        [Key]
        public int Id { get; set; }
        [Column("nom", TypeName = "varchar(50)"), Required]
        public string Nom { get; set; }

        [Column("bba"), Required]
        public int BBAId { get; set; }
        public Courbe BBA { get; set; }

        [Column("vigueur"), Required]
        public int VigueurId { get; set; }
        public Courbe Vigueur { get; set; }

        [Column("volonte"), Required]
        public int VolonteId { get; set; }
        public Courbe Volonte { get; set; }

        [Column("reflexe"), Required]
        public int ReflexeId { get; set; }
        public Courbe Reflexe { get; set; }

        [Column("dv"), Required]
        public int DVId { get; set; }
        public DV DV { get; set; }

        [Column("ouvrage"), Required]
        public int OuvrageId { get; set; }
        public Ouvrage Ouvrage { get; set; }

        private List<ClasseAlignement> ClasseAlignements { get; } = new List<ClasseAlignement>();

        [NotMapped]
        public IEnumerable<Alignement> Alignements => ClasseAlignements.Select(ca => ca.Alignement);
    }
}