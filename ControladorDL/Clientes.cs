// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020
// Versão: 1.0
// Comentários: Classe para gerir clientes

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
        public class Clientes
    {
        #region Estado

        #region Propriedades

        const int MAXCLIENTES = 50;
        static List<Cliente> conjuntoClientes;

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
            CarregaDados();
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

            // Define novo cliente como válido
            novoCliente.Valido = true;

            conjuntoClientes.Add(novoCliente);

            GuardaDados();
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
        /// Função para verificar se um cliente existe
        /// </summary>
        /// <param name="nif">NIF do Cliente a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteCliente(int nif)
        {
            foreach (Cliente c in conjuntoClientes)
                if (c.Nif == nif && c.Valido)
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

        /// <summary>
        /// Envio do número de clientes registados
        /// </summary>
        /// <returns>Número de clientes</returns>
        public static uint ContadorDeClientes()
        { return (uint)conjuntoClientes.Count; }


        /// <summary>
        /// Guarda objecto que contém os dados das pessoas num ficheiro de texto em binário
        /// </summary>
        private static void GuardaDados()
        {
            // Declaração de variáveis locais
            string caminhoFicheiro;
            Stream stream;

            // Definir caminho absoluto onde o ficheiro de texto será criado e escrito
            caminhoFicheiro = Environment.CurrentDirectory + "//clientes.dat";


            // Inicializar stream de escrita através da criação do ficheiro onde serão guardados
            // Caso o ficheiro já exista, será reescrito 
            stream = File.Create(caminhoFicheiro);


            // Inicializar classe responsável por serializar os dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Serializar objecto que contém os dados em binário
            serializador.Serialize(stream, conjuntoClientes);


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
            caminhoFicheiro = Environment.CurrentDirectory + "//clientes.dat";


            // Se o ficheiro alvo não existir, ignorar o resto das iterações do presente método
            if (File.Exists(caminhoFicheiro) == false) return;

            // Inicializar stream de leitura através da abertura do ficheiro onde os dados estão guardados  
            stream = File.Open(caminhoFicheiro, FileMode.Open);

            // Inicializar classe responsável por serializar dados em binário
            var serializador = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();


            // Carregar binário "desserializado" para o objecto que contém os dados
            conjuntoClientes = (List<Cliente>)serializador.Deserialize(stream);

            // Fechar stream de leitura de modo a libertar os recursos do sistema
            stream.Close();
        }

        #endregion

        #endregion
    }
}
