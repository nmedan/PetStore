using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace PetStore.Models
{
    public class Igracka
    { 
        public int Id { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        [Range(double.Epsilon, double.MaxValue, ErrorMessage = "Ovo polje mora imati vrijednost veću od 0.")]
        public double Cijena { get; set; }

    }
}