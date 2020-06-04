// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 24/05/2020
// Versão: 1.0
// Comentários: Classe para definir as regras gerais


using ControladorBO;
using System;

namespace ControladorDeTarefas
{
    class RegrasGerais
    {
        /// <summary>
        /// Função que verifica se um nome é válido
        /// </summary>
        /// <param name="nome">Nome</param>
        /// <returns>Verdadeiro caso seja válido</returns>
        public static bool ValidaNome(string nome)
        {
            if (nome.Length < 3)
                return false;

            return true;
        }

        /// <summary>
        /// Método que força a leitura de um estado dum registo
        /// </summary>
        /// <returns>Estado do registo inserido</returns>
        public static Estado LeEstado()
        {
            Estado estado;
            int opcao;

            do
            {
                Console.WriteLine("Selecione o estado do registo:");
                Console.WriteLine("1 - Nenhum");
                Console.WriteLine("2 - Notificado");
                Console.WriteLine("3 - Validado");
                Console.WriteLine("4 - Enviado");

                Console.Write("Insira a sua opção: ");
                opcao = LeInteiro();
            } while (opcao <= 0 || opcao > 4);

            switch (opcao)
            {
                default: estado = Estado.None; break;
                case 1: estado = Estado.None; break;
                case 2: estado = Estado.Notificar; break;
                case 3: estado = Estado.Validar; break;
                case 4: estado = Estado.Enviar; break;
            }

            return estado;
        }


        #region Leitura de valores

        /// <summary>
        /// Método que força a leitura de um inteiro
        /// </summary>
        /// <returns>inteiro inserido</returns>
        public static int LeInteiro()
        {
            string aux;
            int numeroTentativas = 0, numero;

            do
            {
                if (numeroTentativas > 0)
                    Console.WriteLine("Não foi inserido um número inteiro!!! Tente outra vez...!\nInsira um número inteiro: ");

                numeroTentativas++;

                aux = Console.ReadLine();
            } while (!int.TryParse(aux, out numero));

            return numero;
        }

        /// <summary>
        /// Método que força a leitura de um double
        /// </summary>
        /// <returns>Double inserido</returns>
        public static double LeDouble()
        {
            string aux;
            int numeroTentativas = 0;
            double numero;

            do
            {
                if (numeroTentativas > 0)
                    Console.WriteLine("Não foi inserido um número double!!! Tente outra vez...!\nInsira um número double: ");

                numeroTentativas++;
                aux = Console.ReadLine();
            } while (!double.TryParse(aux, out numero));

            return numero;
        }


        /// <summary>
        /// Método que força a leitura de uma data
        /// </summary>
        /// <returns>Data inserida</returns>
        public static DateTime LeData()
        {
            DateTime data;
            string aux;
            int numeroTentativas = 0;

            do
            {
                if (numeroTentativas > 0)
                    Console.WriteLine("Tipo de data inválido! Volte a inserir!");

                aux = Console.ReadLine();
                numeroTentativas++;
            } while (!DateTime.TryParse(aux, out data));

            return data;
        }

        #endregion
    }
}
