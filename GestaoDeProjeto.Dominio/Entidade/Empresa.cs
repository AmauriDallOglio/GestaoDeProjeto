namespace GestaoDeProjeto.Dominio.Entidade
{
    public class Empresa
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }
        public string Cnpj { get; set; } = string.Empty;
        public string PessoaContato { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public bool Inativo { get; set; }


        //public List<Squad> Squads { get; set; }

     
        public virtual List<Projeto> Projetos { get; set; } = new List<Projeto>();

        public Empresa DadosDoIncluir()
        {
            DataCadastro = DateTime.Now;
            Inativo = false;
            return this;
        }
    }
}