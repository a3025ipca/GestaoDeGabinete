// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir obrigações

using System.Collections.Generic;

namespace GestaoDeGabinete
{
    public class Obrigacoes
    {
        #region Estado

        #region Propriedades

        const int MAXOBRIGACOES = 50;
        private static List<Obrigacao> conjuntoObrigacoes;

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe Obrigações
        /// </summary>
        static Obrigacoes()
        {
            conjuntoObrigacoes = new List<Obrigacao>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável conjuntoObrigacoes
        /// </summary>
        public static List<Obrigacao> ConjuntoObrigacoes
        {
            get { return conjuntoObrigacoes; }
            set { conjuntoObrigacoes = value; }
        }

        #endregion

        #region Outros métodos

        /// <summary>
        /// Função para registar uma nova obrigação
        /// </summary>
        /// <param name="novaObrigacao">Nova obrigação</param>
        /// <returns>Verdadeiro caso seja adicionada</returns>
        public static bool RegistaObrigacao(Obrigacao novaObrigacao)
        {
            if (conjuntoObrigacoes.Count == MAXOBRIGACOES)
                return false;

            // Verificar se a obrigação existe
            if (ExisteObrigacao(novaObrigacao))
                return false;

            conjuntoObrigacoes.Add(novaObrigacao);

            return true;
        }

        /// <summary>
        /// Função para verificar se uma obrigação existe
        /// </summary>
        /// <param name="obrigacao">Obrigação a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteObrigacao(Obrigacao obrigacao)
        {
            foreach (Obrigacao o in conjuntoObrigacoes)
                if (o == obrigacao && o.Valido)
                    return true;

            return false;
        }

        /// <summary>
        /// Eliminar uma obrigação
        /// </summary>
        /// <param name="nome">Nome da obrigação</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaObrigacao(string nome)
        {
            foreach (Obrigacao o in conjuntoObrigacoes)
            {
                if (o.Nome == nome)
                {
                    o.Valido = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Envia uma obrigação
        /// </summary>
        /// <param name="nome">Nome da obrigação</param>
        /// <returns>Retorna a obrigação</returns>
        public static Obrigacao EnviaObrigacao(string nome)
        {
            foreach (Obrigacao o in conjuntoObrigacoes)
                if (o.Nome == nome)
                    return o;

            // Retorna obrigação em branco
            return new Obrigacao();
        }

        #endregion

        #endregion
    }
}
