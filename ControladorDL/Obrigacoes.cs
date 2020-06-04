// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir obrigações
// Data: 23/05/2020
// Versão: 2.0
// Comentários: Acrescentado os métodos de guardar e carregar os dados em ficheiro binário


using ControladorBO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDL
{
    [Serializable]
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
            CarregaDados();
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

            novaObrigacao.Valido = true;

            conjuntoObrigacoes.Add(novaObrigacao);

            GuardaDados();
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
        /// Função para verificar se uma obrigação existe
        /// </summary>
        /// <param name="nome">Nome da obrigação a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteObrigacao(string nome)
        {
            foreach (Obrigacao o in conjuntoObrigacoes)
                if (o.Nome == nome && o.Valido)
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

        /// <summary>
        /// Guarda objecto que contém os dados das pessoas num ficheiro de texto em binário
        /// </summary>
        private static void GuardaDados()
        {
            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//obrigacoes.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar os dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados em binário
            serializador.Serialize(stream, conjuntoObrigacoes);


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
            caminhoFicheiro = Environment.CurrentDirectory + "//obrigacoes.dat";


            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(caminhoFicheiro) == false) return;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(caminhoFicheiro, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Carregar binário "desserializado" para o objecto que contém os dados
            conjuntoObrigacoes = (List<Obrigacao>)serializador.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion

        #endregion
    }
}
