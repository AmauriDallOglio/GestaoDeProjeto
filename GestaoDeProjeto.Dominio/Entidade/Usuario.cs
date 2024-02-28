namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public Empresa Empresa { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public byte Situacao { get; set; }

 

    }

}
