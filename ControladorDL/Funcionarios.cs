// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir funcionários
// Data: 23/05/2020
// Versão: 2.0
// Comentários: Acrescentado os métodos de guardar e carregar os dados em ficheiro binário


using ControladorBO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ControladorDL
{
    [Serializable]
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
            CarregaDados();
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

            novoFuncionario.Valido = true;
            conjuntoFuncionarios.Add(novoFuncionario);

            GuardaDados();
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
        /// Função para verificar se um funcionário existe
        /// </summary>
        /// <param name="funcionario">Funcionário a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteFuncionario(string username)
        {
            foreach (Funcionario f in conjuntoFuncionarios)
                if (f.Username == username && f.Valido)
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
        /// Envia um funcionário conforme o seu username (caso por ex seja necessário nos )
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

        /// <summary>
        /// Envio do número de funcionários registados
        /// </summary>
        /// <returns>Número de funcionários</returns>
        public static uint ContadorDeFuncionarios()
        { return (uint)conjuntoFuncionarios.Count; }

        /// <summary>
        /// Verifica se os dados de acesso introduzidos são válidos
        /// </summary>
        /// <param name="funcionario">Funcionário</param>
        /// <returns>
        /// Verdadeiro: Acesso correto
        /// Falso: Acesso incorreto
        /// </returns>
        public static bool VerificaAcesso(Funcionario funcionario)
        {
            foreach (Funcionario f in conjuntoFuncionarios)
            {
                if (funcionario.Username == f.Username && funcionario.Senha == f.Senha && f.Valido)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Guarda objecto que contém os dados das pessoas num ficheiro de texto em binário
        /// </summary>
        private static void GuardaDados()
        {
            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//funcionarios.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar os dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados em binário
            serializador.Serialize(stream, conjuntoFuncionarios);


            // Fechar stream de escrita de modo a libertar os recursos do sistema
            stream.Close();
        }

        /// <summary>
        /// Carrega ficheiro que contém objecto guardado de forma persistente para a aplicação
        /// </summary>
        private static void CarregaDados()
        {
            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            // Definir caminho absoluto de onde o ficheiro de texto será carregado
            caminhoFicheiro = Environment.CurrentDirectory + "//funcionarios.dat";


            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(caminhoFicheiro) == false) return;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(caminhoFicheiro, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Carregar binário "desserializado" para o objecto que contém os dados
            conjuntoFuncionarios = (List<Funcionario>)serializador.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion

        #endregion
    }
}
