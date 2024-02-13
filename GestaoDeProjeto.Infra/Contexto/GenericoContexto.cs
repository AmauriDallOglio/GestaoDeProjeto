using GestaoDeProjeto.Dominio.Entidade;
using GestaoDeProjeto.Dominio.Util;
using GestaoDeProjeto.Infra.Mapeamento.Configuracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GestaoDeProjeto.Infra.Contexto
{

    public class GenericoContexto : DbContext
    {
        private readonly GestaoDeProjetoContexto _gestaoDeProjetoContexto;

        private int _IdEmpresa;
        public GenericoContexto(DbContextOptions options) : base(options)
        {
            _IdEmpresa = 2;
        }

        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfiguracaoMapeamento.Injetar(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }


        public virtual void MetodoInserir()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                object objeto = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        InserirInformacaoGlobal(objeto);
                        break;
                }
            }
        }



        public virtual void MetodoAlterar()
        {
            foreach (EntityEntry entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                object objeto = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        InserirInformacaoGlobal(objeto);
                        break;
                }
            }
        }

        protected virtual void InserirInformacaoGlobal(object entity)
        {
            SetaTenantId(entity);
 
        }

     

        private void SetaTenantId(object entity)
        {
            if (entity is IEmpresaObrigatorio)
            {
                var temTenant = entity as IEmpresaObrigatorio;
                temTenant.Id_Empresa = _IdEmpresa;
            }

        }

        //public void AplicarFiltroGlobalId<TEntity>(ModelBuilder modelBuilder) where TEntity : AuditableEntity<Guid>
        //{
        //    modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id == _IdEmpresa).Property(a => a.Id).HasColumnName("Id");
        //}

        //public void AplicarFiltroGlobalIdTenant<TEntity>(ModelBuilder modelBuilder) where TEntity : AuditableEntity<Guid>, IEmpresaObrigatorio
        //{
        //    modelBuilder.Entity<TEntity>().HasQueryFilter(e => e.Id_Empresa == _IdEmpresa).Property(a => a._IdEmpresa).HasColumnName("Id_Tenant");
        //}

    }

}
