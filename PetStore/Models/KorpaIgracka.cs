using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class KorpaIgracka
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vrijednost ovog polja mora biti veća ili jednaka 1.")]
        public int BrojKomada { get; set; }

        public int IgrackaId { get; set; }

        public Igracka Igracka { get; set; }

    }
}