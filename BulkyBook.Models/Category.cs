﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Catory Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
