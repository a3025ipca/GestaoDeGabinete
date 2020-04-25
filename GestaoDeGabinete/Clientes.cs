// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir clientes

using System.Collections.Generic;

namespace GestaoDeGabinete
{
    public class Clientes
    {
        #region Estado

        #region Propriedades

        const int MAXCLIENTES = 50;
        private static List<Cliente> conjuntoClientes;

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe Clientes
        /// </summary>
        static Clientes()
        {
            conjuntoClientes = new List<Cliente>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável conjuntoClientes
        /// </summary>
        public static List<Cliente> ConjuntoClientes
        {
            get { return conjuntoClientes; }
            set { conjuntoClientes = value; }
        }

        #endregion

        #region Outros métodos

        /// <summary>
        /// Função para registar um novo cliente
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <returns>Verdadeiro caso seja adicionado</returns>
        public static bool RegistaCliente(Cliente novoCliente)
        {
            if (conjuntoClientes.Count == MAXCLIENTES)
                return false;

            // Verificar se o cliente existe
            if (ExisteCliente(novoCliente))
                return false;

            conjuntoClientes.Add(novoCliente);

            return true;
        }

        /// <summary>
        /// Função para verificar se um cliente existe
        /// </summary>
        /// <param name="cliente">Cliente a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteCliente(Cliente cliente)
        {
            foreach (Cliente c in conjuntoClientes)
                if (c == cliente && c.Valido)
                    return true;

            return false;
        }

        /// <summary>
        /// Eliminar um cliente
        /// </summary>
        /// <param name="nif">Nif do cliente</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaCliente(int nif)
        {
            foreach (Cliente c in conjuntoClientes)
            {
                if (c.Nif == nif)
                {
                    c.Valido = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Envia um cliente conforme o seu nif
        /// </summary>
        /// <param name="nif">Nif do cliente</param>
        /// <returns>Retorna o cliente</returns>
        public static Cliente EnviaCliente(int nif)
        {
            foreach (Cliente c in conjuntoClientes)
                if (c.Nif == nif)
                    return c;

            // Retorna cliente em branco
            return new Cliente();
        }

        #endregion

        #endregion
    }
}
