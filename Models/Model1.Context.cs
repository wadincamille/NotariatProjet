﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NotariatProjetUTC503Entities : DbContext
    {
        public NotariatProjetUTC503Entities()
            : base("name=NotariatProjetUTC503Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<adFiscale> adFiscale { get; set; }
        public virtual DbSet<bien> bien { get; set; }
        public virtual DbSet<claire> claire { get; set; }
        public virtual DbSet<client> client { get; set; }
        public virtual DbSet<client_dossier> client_dossier { get; set; }
        public virtual DbSet<document> document { get; set; }
        public virtual DbSet<dossier> dossier { get; set; }
        public virtual DbSet<mail> mail { get; set; }
        public virtual DbSet<mvtfont> mvtfont { get; set; }
        public virtual DbSet<nature> nature { get; set; }
        public virtual DbSet<notaire> notaire { get; set; }
        public virtual DbSet<origine> origine { get; set; }
        public virtual DbSet<secretaire> secretaire { get; set; }
        public virtual DbSet<Table> Table { get; set; }
        public virtual DbSet<typeActe> typeActe { get; set; }
        public virtual DbSet<typeClient> typeClient { get; set; }
    }
}
