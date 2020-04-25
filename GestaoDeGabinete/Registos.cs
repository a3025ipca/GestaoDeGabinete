// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir registos

using System.Collections.Generic;

namespace GestaoDeGabinete
{
    class Registos
    {
        #region Estado

        #region Propriedades

        const int MAXREGISTOS = 200;
        private static List<Registo> conjuntoRegistos;

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe Registos
        /// </summary>
        static Registos()
        {
            conjuntoRegistos = new List<Registo>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável conjuntoRegistos
        /// </summary>
        public static List<Registo> ConjuntoRegistos
        {
            get { return conjuntoRegistos; }
            set { conjuntoRegistos = value; }
        }

        #endregion

        #region Outros métodos

        /// <summary>
        /// Função para registar um novo registo
        /// </summary>
        /// <param name="novoRegisto">Novo registo</param>
        /// <returns>Verdadeiro caso seja adicionada</returns>
        public static bool RegistaRegisto(Registo novoRegisto)
        {
            if (conjuntoRegistos.Count == MAXREGISTOS)
                return false;

            // Verificar se a obrigação existe
            if (ExisteRegisto(novoRegisto))
                return false;

            conjuntoRegistos.Add(novoRegisto);

            return true;
        }

        /// <summary>
        /// Função para verificar se um registo existe
        /// </summary>
        /// <param name="registo">Registo a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteRegisto(Registo registo)
        {
            foreach (Registo r in conjuntoRegistos)
                if (r == registo && r.Valido)
                    return true;

            return false;
        }

        /// <summary>
        /// Elimina um registo
        /// </summary>
        /// <param name="cliente">Cliente associado ao registo</param>
        /// <param name="obrigacao">Obrigação associada ao registo</param>
        /// <param name="mes">Mes do registo</param>
        /// <param name="ano">Ano do registo</param>
        /// <returns>Verdadeiro caso seja eliminado, falso caso não seja</returns>
        public static bool EliminaRegisto(Cliente cliente, Obrigacao obrigacao, int mes, int ano)
        {
            foreach (Registo r in conjuntoRegistos)
            {
                if (r.Cliente == cliente && r.Obrigacao == obrigacao && r.Mes == mes && r.Ano == ano)
                {
                    r.Valido = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Envia um registo
        /// </summary>
        /// <param name="cliente">Cliente associado ao registo</param>
        /// <param name="obrigacao">Obrigação associada ao registo</param>
        /// <param name="mes">Mes do registo</param>
        /// <param name="ano">Ano do registo</param>
        /// <returns>Retorna o registo</returns>
        public static Registo EnviaRegisto(Cliente cliente, Obrigacao obrigacao, int mes, int ano)
        {
            foreach (Registo r in conjuntoRegistos)
                if (r.Cliente == cliente && r.Obrigacao == obrigacao && r.Mes == mes && r.Ano == ano)
                    return r;

            // Retorna registo em branco
            return new Registo();
        }

        #endregion

        #endregion
    }
}
