// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para definir o que é um Cliente

namespace GestaoDeGabinete
{
    public class Cliente
    {
        #region Estado

        #region Propriedades

        #endregion

        #region Variáveis Globais

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe Cliente
        /// </summary>
        public Cliente()
        {
            Nif = default;
            Nome = default;
            Valido = true;
        }

        /// <summary>
        /// Construtor para criar um cliente
        /// </summary>
        /// <param name="nif">Nif do cliente</param>
        /// <param name="nome">Nome do cliente</param>
        public Cliente(int nif, string nome)
        {
            Nif = nif;
            Nome = nome;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável Nif
        /// </summary>
        public int Nif { get; set; }

        /// <summary>
        /// Devolve ou define a variável nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Devolve ou define o estado da variável valido
        /// Variável usada para eliminar o cliente
        /// </summary>
        public bool Valido { get; set; }

        #endregion

        #region Operadores

        /// <summary>
        /// Função para comparar dois clientes
        /// </summary>
        /// <param name="obj">Objeto do tipo cliente</param>
        /// <returns>Verdadeiro caso seja igual, falso caso sejam diferentes</returns>
        public override bool Equals(object obj)
        {
            // Variáveis locais
            Cliente aux;

            // Verifica se o objeto enviado é do tipo Cliente
            if (!(obj is Cliente))
                return false;

            // Converte o objeto para Cliente
            aux = (Cliente)obj;

            // Verifica se são iguais
            return (aux.Nif == this.Nif);
        }

        /// <summary>
        /// Operador para verificar se dois clientes são iguais
        /// </summary>
        /// <param name="cliente1">Cliente 1</param>
        /// <param name="cliente2">Cliente 2</param>
        /// <returns>Verdadeiro caso seja iguais, falso caso sejam diferentes</returns>
        public static bool operator ==(Cliente cliente1, Cliente cliente2)
        {
            return (cliente1.Equals(cliente2));
        }

        /// <summary>
        /// Operador para verificar se dois clientes são diferentes
        /// </summary>
        /// <param name="cliente1">Cliente 1</param>
        /// <param name="cliente2">Cliente 2</param>
        /// <returns>Verdadeiro caso seja diferentes, falso caso sejam iguais</returns>
        public static bool operator !=(Cliente cliente1, Cliente cliente2)
        {
            return (!(cliente1.Equals(cliente2)));
        }

        public override int GetHashCode()
        {
            return this.Nif.GetHashCode();
        }

        #endregion

        #region Outros métodos

        #endregion

        #endregion
    }
}
