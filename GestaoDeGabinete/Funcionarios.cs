// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir funcionários

using System.Collections.Generic;

namespace GestaoDeGabinete
{
    public class Funcionarios
    {
        #region Estado

        #region Propriedades

        const int MAXFUNCIONARIOS = 50;
        private static List<Funcionario> conjuntoFuncionarios;

        #endregion

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor default para a classe Funcionários
        /// </summary>
        static Funcionarios()
        {
            conjuntoFuncionarios = new List<Funcionario>();
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Devolve ou define a variável conjuntoFuncionarios
        /// </summary>
        public static List<Funcionario> ConjuntoFuncionarios
        {
            get { return conjuntoFuncionarios; }
            set { conjuntoFuncionarios = value; }
        }

        #endregion

        #region Outros métodos 

        /// <summary>
        /// Função para registar um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Novo funcionário</param>
        /// <returns>Verdadeiro caso seja adicionada</returns>
        public static bool RegistaFuncionario(Funcionario novoFuncionario)
        {
            if (conjuntoFuncionarios.Count == MAXFUNCIONARIOS)
                return false;

            // Verificar se o funcionário existe
            if (ExisteFuncionario(novoFuncionario))
                return false;

            conjuntoFuncionarios.Add(novoFuncionario);

            return true;
        }

        /// <summary>
        /// Função para verificar se um funcionário existe
        /// </summary>
        /// <param name="funcionario">Funcionário a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteFuncionario(Funcionario funcionario)
        {
            foreach (Funcionario f in conjuntoFuncionarios)
                if (f == funcionario && f.Valido)
                    return true;

            return false;
        }

        /// <summary>
        /// Eliminar um funcionário
        /// </summary>
        /// <param name="username">Username do funcionário</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaFuncionario(string username)
        {
            foreach (Funcionario f in conjuntoFuncionarios)
            {
                if (f.Username == username)
                {
                    f.Valido = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Envia um funcionário conforme o seu username
        /// </summary>
        /// <param name="username">Username do funcionário</param>
        /// <returns>Retorna o funcionário</returns>
        public static Funcionario EnviaFuncionario(string username)
        {
            foreach (Funcionario f in conjuntoFuncionarios)
                if (f.Username == username)
                    return f;

            // Retorna funcionário em branco
            return new Funcionario();
        }

        #endregion

        #endregion
    }
}
