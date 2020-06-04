using ControladorBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBL
{
    public class Obrigacoes
    {
        /// <summary>
        /// Função para registar uma nova obrigação
        /// </summary>
        /// <param name="novoObrigacao">Nova obrigação</param>
        /// <returns>
        /// 0: Erro, já existe esse funcionário ou número máximo de funcionários atingido
        /// 1: Adicionado com sucesso;
        /// </returns>
        public static bool RegistaObrigacao(Obrigacao novaObrigacao)
        {
            // Verificar se existe nova obrigação
            if (ControladorDL.Obrigacoes.ExisteObrigacao(novaObrigacao))
                return false;

            // Verifica se é a obrigação é adicionar com sucesso
            if (ControladorDL.Obrigacoes.RegistaObrigacao(novaObrigacao))
                return true;

            return false;
        }

        /// <summary>
        /// Função para verificar se uma obrigação já está registada
        /// </summary>
        /// <param name="nome">Nome da obrigação a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteObrigacao(string nome)
        {
            try
            {
                return ControladorDL.Obrigacoes.ExisteObrigacao(nome);
            }
            catch (Exception e) { throw e; }
        }



        /// <summary>
        /// Eliminar uma obrigação
        /// </summary>
        /// <param name="nome">Nome da obrigação que se pretende eliminar</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaObrigacao(string nome)
        {
            return ControladorDL.Obrigacoes.EliminaObrigacao(nome);
        }


        /// <summary>
        /// Envia uma obrigação
        /// </summary>
        /// <param name="nome">Nome da obrigação</param>
        /// <returns>Retorna a obrigação se existar ou null caso não exista</returns>
        public static Obrigacao EnviaObrigacao(string nome)
        {
            Obrigacao obrigacao = ControladorDL.Obrigacoes.EnviaObrigacao(nome);

            // Verificar se a obrigação existe
            if (string.IsNullOrEmpty(obrigacao.Nome)) return null; // se não existir retorna null

            // Retorna obrigação
            return obrigacao;
        }


    }
}
