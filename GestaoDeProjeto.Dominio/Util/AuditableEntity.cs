namespace GestaoDeProjeto.Dominio.Util
{
    public abstract class AuditableEntity<TId> : IAuditableEntity<TId>
    {
        public TId Id { get; set; }
    }

 
}
