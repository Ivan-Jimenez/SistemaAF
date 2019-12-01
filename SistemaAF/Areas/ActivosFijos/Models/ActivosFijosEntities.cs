using System.Data.Entity;

namespace SistemaAF.Areas.ActivosFijos.Models
{
    public class ActivosFijosEntities : DbContext
    {
        public ActivosFijosEntities() : base("SistemaAFEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Extranjeros> Extranjeros { get; set; }
        public DbSet<Nacionales> Nacionales { get; set; }
        public DbSet<NacionalDocument> NacionalDocument { get; set; }
        public DbSet<ExtranjeroDocument> ExtranjeroDocument { get; set; }
    }
}