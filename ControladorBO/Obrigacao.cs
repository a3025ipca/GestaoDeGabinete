// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para definir o que é uma Obrigação


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBO
{
    [Serializable]
    public class Obrigacao
    {
        #region Estado

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável Username
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Devolve ou define o estado da variável valido
        /// Variável usada para eliminar o funcionário
        /// </summary>
        public bool Valido { get; set; }

        /// <summary>
        /// Devolve ou define a lista de clientes associados a esta obrigação
        /// </summary>
        public List<Cliente> ListaClientes { get; set; }

        #endregion

        #region Variáveis Globais

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe obrigação
        /// </summary>
        public Obrigacao()
        {
            Nome = default;
            Valido = true;
        }

        /// <summary>
        /// Construtor para criar uma obrigação
        /// </summary>
        /// <param name="nome">Nome da obrigação</param>
        public Obrigacao(string nome)
        {
            Nome = nome;
            ListaClientes = new List<Cliente>();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Função para comparar duas obrigações
        /// </summary>
        /// <param name="obj">Objeto do tipo Obrigacao</param>
        /// <returns>Verdadeiro caso seja igual, falso caso sejam diferentes</returns>
        public override bool Equals(object obj)
        {
            // Variáveis locais
            Obrigacao aux;

            // Verifica se o objeto enviado é do tipo Obrigação
            if (!(obj is Obrigacao))
                return false;

            // Converte o objeto para Obrigação
            aux = (Obrigacao)obj;

            // Verifica se são iguais
            return (aux.Nome == this.Nome);
        }

        /// <summary>
        /// Operador para verificar se duas obrigações são iguais
        /// </summary>
        /// <param name="obrigacao1">Obrigação 1</param>
        /// <param name="obrigacao2">Obrigação 2</param>
        /// <returns>Verdadeiro caso seja iguais, falso caso sejam diferentes</returns>
        public static bool operator ==(Obrigacao obrigacao1, Obrigacao obrigacao2)
        {
            if (object.ReferenceEquals(obrigacao1, null))
                return object.ReferenceEquals(obrigacao2, null);

            return (obrigacao1.Equals(obrigacao2));
        }

        /// <summary>
        /// Operador para verificar se duas obrigações são diferentes
        /// </summary>
        /// <param name="obrigacao1">Obrigação 1</param>
        /// <param name="obrigacao2">Obrigação 2</param>
        /// <returns>Verdadeiro caso seja diferentes, falso caso sejam iguais</returns>
        public static bool operator !=(Obrigacao obrigacao1, Obrigacao obrigacao2)
        {
            return (!(obrigacao1.Equals(obrigacao2)));
        }

        public override int GetHashCode()
        {
            return this.Nome.GetHashCode();
        }

        #endregion

        #region Outros métodos

        #endregion

        #endregion
    }
}
