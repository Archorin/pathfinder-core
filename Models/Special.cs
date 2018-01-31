using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("special")]
    public class Special
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}