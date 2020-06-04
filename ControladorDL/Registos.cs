// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir registos
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
    public class Registos
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
            CarregaDados();
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

            GuardaDados();
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


        /// <summary>
        /// Função que retorna uma lista com os registos da obrigação
        /// </summary>
        /// <param name="obrigacao">Obrigação que pretendemos verificar nos registos</param>
        /// <returns>Listagem com os registos</returns>
        public static List<Registo> ListarPorObrigacao(Obrigacao obrigacao)
        {
            // Variável auxiliar
            List<Registo> listaAuxiliar;

            // Inicializar variáveis
            listaAuxiliar = new List<Registo>();

            // Ciclo para percorrer os registos
            foreach (Registo r in conjuntoRegistos)
            {
                // Verificar se estamos perante a obrigação que desejamos
                if (r.Obrigacao == obrigacao)
                    listaAuxiliar.Add(r); // Adicionar registo à lista auxiliar
            }

            // Retornar lista auxiliar
            return listaAuxiliar;
        }

        /// <summary>
        /// Função que retorna uma lista com os registos do cliente
        /// </summary>
        /// <param name="cliente">Cliente que pretendemos verificar os registos</param>
        /// <returns>Listagem com os registos</returns>
        public static List<Registo> ListarPorCliente(Cliente cliente)
        {
            // Variável auxiliar
            List<Registo> listaAuxiliar;

            // Inicializar variáveis
            listaAuxiliar = new List<Registo>();

            // Ciclo para percorrer os registos
            foreach (Registo r in conjuntoRegistos)
            {
                // Verificar se estamos perante o cliente que desejamos
                if (r.Cliente == cliente)
                    listaAuxiliar.Add(r); // Adicionar o registo à lista auxiliar
            }

            // Retornar lista auxiliar
            return listaAuxiliar;
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
            caminhoFicheiro = Environment.CurrentDirectory + "//registos.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar os dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados em binário
            serializador.Serialize(stream, conjuntoRegistos);


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
            caminhoFicheiro = Environment.CurrentDirectory + "//registos.dat";


            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(caminhoFicheiro) == false) return;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(caminhoFicheiro, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Carregar binário "desserializado" para o objecto que contém os dados
            conjuntoRegistos = (List<Registo>)serializador.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion

        #endregion
    }
}
