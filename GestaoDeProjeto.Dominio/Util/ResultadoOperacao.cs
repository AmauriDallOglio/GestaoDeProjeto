using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeProjeto.Dominio.Util
{
    public class ResultadoOperacao<T> : ResultadoOperacao
    {
        public T Modelo { get; set; }


        public static Task<ResultadoOperacao<T>> RetornaSuccessoAsync(T data, string message)
        {
            return Task.FromResult(GeraSucessoAsync(data, message));
        }
        public static ResultadoOperacao<T> GeraSucessoAsync(T data, string message)
        {
            return new ResultadoOperacao<T> { Sucesso = true, Modelo = data, Mensagem = message };
        }

        public static Task<ResultadoOperacao<T>> RetornaFalhaAsync(T data, string message)
        {
            return Task.FromResult(GeraFalhaAsync(data, message));
        }
        public static ResultadoOperacao<T> GeraFalhaAsync(T data, string message)
        {
            return new ResultadoOperacao<T> { Sucesso = false, Modelo = data, Mensagem = message };
        }


        public ResultadoOperacao<T> RetornaSuccesso(T data, string message)
        {
            return GeraSucesso(data, message);
        }
        public ResultadoOperacao<T> GeraSucesso(T data, string message)
        {
            return new ResultadoOperacao<T> { Sucesso = true, Modelo = data, Mensagem = message };
        }

        public ResultadoOperacao<T> RetornaFalha(T data, string message)
        {
            return GeraFalha(data, message);
        }
        public ResultadoOperacao<T> GeraFalha(T data, string message)
        {
            return new ResultadoOperacao<T> { Sucesso = false, Modelo = data, Mensagem = message };
        }

    }
    public class ResultadoOperacao
    {
        public bool Sucesso { get; set; } = true;
        public string Mensagem { get; set; } = "Operação concluída com sucesso";

        public ResultadoOperacao RetornaErro(string mensagem)
        {
            return new ResultadoOperacao { Sucesso = false, Mensagem = mensagem };
        }

        public ResultadoOperacao RetornaSucesso(string mensagem)
        {
            return new ResultadoOperacao { Sucesso = true, Mensagem = mensagem };
        }
    }
    public enum TipoMensagemOperacaoEnumumerador
    {
        Erro = 0,
        Alerta = 1,
        Info = 2,
        Sucesso = 3,
    }

}
