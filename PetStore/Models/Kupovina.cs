using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace PetStore.Models
{
    public class Kupovina
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string KupacIme { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string KupacPrezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string BrojKreditneKartice { get; set; }

    }
}