using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("classe_alignement")]
    public class ClasseAlignement
    {
        [Column("classe_id")]
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }

        [Column("alignement_id")]
        public int AlignementId { get; set; }
        public Alignement Alignement { get; set; }
    }
}
