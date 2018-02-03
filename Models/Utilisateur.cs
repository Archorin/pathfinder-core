using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
//https://www.pointblankdevelopment.com.au/blog/113/aspnet-core-20-angular-24-user-registration-and-login-tutorial-example#startup-cs
namespace PathfinderCore.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key]
        [Column("id", TypeName = "integer")]
        public int Id { get; set; }

        [Column("login", TypeName = "varchar(50)"), Required]
        public string Login { get; set; }

        [Column("password_hash", TypeName = "Binary"), MaxLength(256), Required]
        public byte[] PasswordHash { get; set; }

        [Column("password_salt", TypeName = "Binary"), MaxLength(256), Required]
        public byte[] PasswordSalt { get; set; }
    }
}