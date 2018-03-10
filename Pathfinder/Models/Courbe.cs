using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PathfinderCore.Models
{
    [Table("courbe")]
    public class Courbe
    {
        [Key]
        public int Id { get; set; }

        [Column("nom", TypeName = "varchar(16)")]
        public string Nom { get; set; }

        public List<Statistique> Statistiques { get; set; }
    }
}