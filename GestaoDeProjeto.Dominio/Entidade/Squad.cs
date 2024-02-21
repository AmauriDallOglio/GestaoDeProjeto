namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Squad
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Descricao { get; set; } = string.Empty;
        //public byte[]? ArrayImagem { get; set; }
        //public string? UrlImagem { get; set; } = string.Empty;
        public bool Inativo { get; set; }

    }
}
