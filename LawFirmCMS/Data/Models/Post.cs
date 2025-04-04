﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LawFirmCMS.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [ValidateNever]
        public DateTime PublishDate { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee? Employee { get; set; }
        [Display(Name = "Employee")]
        [ValidateNever]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;

    }
}
