using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetNotariatUTC503.Models
{

    [MetadataType(typeof(dossierMetaData))]
    public partial class dossier
    {
        public int getid()
        {
            return 0;
        }

    }

    public class dossierMetaData
    {

        [Display(Name = "Secrétaire:")]
        public int idSecretaire { get; set; }

        [Display(Name = "Notaire:")]
        public int idNotaire { get; set; }

        [Display(Name = "Claire:")]
        public int idClaire { get; set; }

    }
}