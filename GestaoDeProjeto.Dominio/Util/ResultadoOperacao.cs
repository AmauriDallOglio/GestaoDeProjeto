namespace GestaoDeProjeto.Dominio.Util
{
    public class ResultadoOperacao
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = string.Empty;
        public long TempoResposta { get; set; } = 0;
        public string NomeObjeto { get; set; } = string.Empty;
        public ResultadoOperacao RetornaErro(string mensagem)
        {
            return new ResultadoOperacao { Sucesso = false, Mensagem = mensagem };
        }

        public ResultadoOperacao RetornaSucesso(string mensagem)
        {
            return new ResultadoOperacao { Sucesso = true, Mensagem = mensagem };
        }
    }

    public class ResultadoOperacao<T> : ResultadoOperacao
    {
        public T Resultado { get; set; }


        public async static Task<ResultadoOperacao<T>> RetornaSuccessoAsync(T data, string nomeObjeto, string message)
        {
            return await Task.FromResult(GeraSucessoAsync(data, message, nomeObjeto));
        }
        public static ResultadoOperacao<T> GeraSucessoAsync(T data, string message, string nomeObjeto)
        {
            return new ResultadoOperacao<T> { Sucesso = true, Resultado = data, Mensagem = message, NomeObjeto = nomeObjeto };
        }

        public async static Task<ResultadoOperacao<T>> RetornaFalhaAsync(T data, string message, string nomeObjeto = "")
        {
            return await Task.FromResult(GeraFalhaAsync(data, message, nomeObjeto));
        }
        public static ResultadoOperacao<T> GeraFalhaAsync(T data, string message, string nomeObjeto = "")
        {
            return new ResultadoOperacao<T> { Sucesso = false, Resultado = data, Mensagem = message, NomeObjeto = nomeObjeto };
        }


        public ResultadoOperacao<T> RetornaSuccesso(T data, string message, string nomeObjeto)
        {
            return GeraSucesso(data, message, nomeObjeto);
        }
        public ResultadoOperacao<T> GeraSucesso(T data, string message, string nomeObjeto)
        {
            return new ResultadoOperacao<T> { Sucesso = true, NomeObjeto = nomeObjeto, Resultado = data, Mensagem = message };
        }

        public ResultadoOperacao<T> RetornaFalha(T data, string message)
        {
            return GeraFalha(data, message);
        }
        public ResultadoOperacao<T> GeraFalha(T data, string message)
        {
            return new ResultadoOperacao<T> { Sucesso = false, Resultado = data, Mensagem = message };
        }


        private static string RetornaNomeObjeto(T data)
        {
            string nomeObjeto = typeof(T).Name;
            return nomeObjeto;
        }
    }
}
