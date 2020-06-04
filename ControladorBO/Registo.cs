// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para definir o que é um Registo


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBO
{
    [Serializable]
     public enum Estado
    {
        None,
        Notificar,
        Validar,
        Enviar
    }

    [Serializable]
    public class Registo
    {
        #region Estado

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável Cliente
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Devolve ou define a variável Obrigacao
        /// </summary>
        public Obrigacao Obrigacao { get; set; }

        /// <summary>
        /// Devolve ou define a variável Funcionario
        /// </summary>
        public Funcionario Funcionario { get; set; }

        /// <summary>
        /// Devolve ou define a variável Mes
        /// </summary>
        public int Mes { get; set; }

        /// <summary>
        /// Devolve ou define a variável Ano
        /// </summary>
        public int Ano { get; set; }

        /// <summary>
        /// Devolve ou define a variável Estado
        /// </summary>
        public Estado Estado { get; set; }

        /// <summary>
        /// Devolve ou define o estado da variável valido
        /// Variável usada para eliminar o registo
        /// </summary>
        public bool Valido { get; set; }


        #endregion

        #region Variáveis Globais

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe registo
        /// </summary>
        public Registo()
        {
            Cliente = default;
            Funcionario = default;
            Obrigacao = default;
            Mes = Ano = default;
            Estado = default;
            Valido = true;
        }

        /// <summary>
        /// Construtor para a classe Registo
        /// </summary>
        /// <param name="cliente">Cliente associado ao registo</param>
        /// <param name="funcionario">Funcionário que alterou o estado do registo</param>
        /// <param name="obrigacao">Obrigação associada ao registo</param>
        /// <param name="mes">Mes associado ao registo</param>
        /// <param name="ano">Ano associado ao registo</param>
        /// <param name="estado">Estado do registo</param>
        public Registo(Cliente cliente, Funcionario funcionario, Obrigacao obrigacao, int mes, int ano, Estado estado)
        {
            Cliente = cliente;
            Funcionario = funcionario;
            Obrigacao = obrigacao;
            Mes = mes;
            Ano = ano;
            Estado = estado;
            Valido = true;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Função para comparar dois registos
        /// </summary>
        /// <param name="obj">Objeto do tipo Obrigacao</param>
        /// <returns>Verdadeiro caso seja igual, falso caso sejam diferentes</returns>
        public override bool Equals(object obj)
        {
            // Variáveis locais
            Registo aux;

            // Verifica se o objeto enviado é do tipo Obrigação
            if (!(obj is Registo))
                return false;

            // Converte o objeto para Obrigação
            aux = (Registo)obj;

            // Verifica se são iguais
            return (aux.Cliente == this.Cliente && aux.Obrigacao == this.Obrigacao && aux.Mes == this.Mes && aux.Ano == this.Ano);
        }

        /// <summary>
        /// Operador para verificar se dois registos são iguais
        /// </summary>
        /// <param name="registo1">Registo 1</param>
        /// <param name="registo2">Registo 2</param>
        /// <returns>Verdadeiro caso seja iguais, falso caso sejam diferentes</returns>
        public static bool operator ==(Registo registo1, Obrigacao registo2)
        {
            return (registo1.Equals(registo2));
        }

        /// <summary>
        /// Operador para verificar se dois registos são diferentes
        /// </summary>
        /// <param name="registo1">Registo 1</param>
        /// <param name="registo2">Registo 2</param>
        /// <returns>Verdadeiro caso seja diferentes, falso caso sejam iguais</returns>
        public static bool operator !=(Registo registo1, Obrigacao registo2)
        {
            return (!(registo1.Equals(registo2)));
        }


        #endregion

        #region Outros métodos

        #endregion

        #endregion
    }
}
