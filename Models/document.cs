//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NotariatProjetUTC503.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class document
    {
        public int id { get; set; }
        public int idDossier { get; set; }
    
        public virtual dossier dossier { get; set; }
    }
}
