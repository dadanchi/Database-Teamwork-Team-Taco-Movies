using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacoMovies.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10), MinLength(6)]
        [Column(TypeName = "VARCHAR")]
        public string AccountNumber { get; set; }

        [Required]
        public int Ammount { get; set; }

        [Required]
        public virtual User User { get; set; }


    }
}
