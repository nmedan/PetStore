using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class KorpaIgrackaKupovina
    {
        [Key]
        [Column(Order = 0)]
        public int KorpaIgrackaId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int KupovinaId { get; set; }

        public KorpaIgracka KorpaIgracka { get; set; }

        public Kupovina Kupovina { get; set; }
    }
}