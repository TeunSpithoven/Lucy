using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;

namespace Lucy.Models
{
    public class Dream
    {
        // data annotation
        [Key]
        // dit wordt een primarary kolom van de tabel
        public int Id { get; set; }
        public string Title { get; set; }
        public string Story { get; set; }
    }
}
