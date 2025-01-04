﻿using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public bool Boss { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;


        public virtual ICollection<Post> Posts { get; } = new List<Post>();
    }
}
