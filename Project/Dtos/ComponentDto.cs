using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Dtos
{
    public class ComponentDto
    {
        [Key]
        public int Id { get; set; }
        public int PartId { get; set; }
        [Required(ErrorMessage = "Enter a Valid Name")]
        public string Name { get; set; }

        public int Qty { get; set; }
    }
}