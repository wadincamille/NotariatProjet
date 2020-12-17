using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetNotariatUTC503.Models
{

    [MetadataType(typeof(clientMetaData))]
    public partial class client
    {
        public int getid()
        {
            return 0;
        }

    }

    public class clientMetaData
    {

        [Display(Name = "Nom de famille:")]
        public int nom { get; set; }

        [Display(Name = "Nom etat civil:")]
        public int nomEtatCivil { get; set; }

        [Display(Name = "Prénom:")]
        public int prenom { get; set; }

        [Display(Name = "Prénoms:")]
        public int prenoms { get; set; }

        [Display(Name = "Rue:")]
        public int rue { get; set; }

        [Display(Name = "Code postal:")]
        public int cp { get; set; }

        [Display(Name = "Ville:")]
        public int ville { get; set; }

        [Display(Name = "Date de naissance:")]
        public int dateNaiss { get; set; }

        [Display(Name = "Lieu de naissance:")]
        public int lieuxNaiss { get; set; }

        [Display(Name = "Nationalité:")]
        public int nationalite { get; set; }

        [Display(Name = "Profession:")]
        public int profession { get; set; }

        [Display(Name = "Tel portable:")]
        public int telPortable { get; set; }

        [Display(Name = "Tel fixe:")]
        public int telFixe { get; set; }

        [Display(Name = "Adresse mail:")]
        public int mail { get; set; }

        [Display(Name = "Adresse fiscale:")]
        public int idAdFiscale { get; set; }

        [Display(Name = "Date de décès:")]
        public int dateDC { get; set; }

        [Display(Name = "Lieu de décès:")]
        public int lieuxDC { get; set; }

      



    }
}