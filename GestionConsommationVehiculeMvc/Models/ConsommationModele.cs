using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionConsommationVehiculeMvc.Models
{
    public class ConsommationModele
    {
        public string plaque { get; set; }
        public string direction { get; set; }
        public string categorieconsommation{ get; set;}
        public int prixunitaire { get; set;}
        public int quantite { get; set; }
        public DateTime DateConsommation{ get; set; }
        public double prixtotal { get; set;}
    }
}