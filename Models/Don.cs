using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathfinderCore.Models
{
    [Table("don")]
    public class Don
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}