// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 24/05/2020
// Versão: 2.0


using ControladorBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBL
{
    public class Funcionarios
    {
        /// <summary>
        /// Função para registar um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Novo funcionário</param>
        /// <returns>
        /// 0: Erro, já existe esse funcionário ou número máximo de funcionários atingido
        /// 1: Adicionado com sucesso;
        /// </returns>
        public static uint RegistaFuncionario(Funcionario novoFuncionario)
        {
            // Verificar se existe novo funcionário
            if (ControladorDL.Funcionarios.ExisteFuncionario(novoFuncionario))
                return 0;

            // Verifica se é o funcionário é adicionar com sucesso
            if (ControladorDL.Funcionarios.RegistaFuncionario(novoFuncionario))
                return 1;

            return 0;
        }


        /// <summary>
        /// Função para verificar se um funcionário existe
        /// </summary>

        public static bool ExisteFuncionario(string username)
        {
            try
            {
                return ControladorDL.Funcionarios.ExisteFuncionario(username);
            }
            catch (Exception e) { throw e; }
        }


        /// <summary>
        /// Eliminar um funcionário
        /// </summary>
        /// <param name="username">Username do funcionário</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaFuncionario(string username)
        {
            return ControladorDL.Funcionarios.EliminaFuncionario(username);
        }

        /// <summary>
        /// Envia um funcionário conforme o seu username
        /// </summary>
        /// <param name="username">Username do funcionário</param>
        /// <returns>Retorna o funcionário caso exista, se não retorna null</returns>
        public static Funcionario EnviaFuncionario(string username)
        {
            Funcionario funcionario = ControladorDL.Funcionarios.EnviaFuncionario(username);

            // Verificar se o funcionário existe
            if (string.IsNullOrEmpty(funcionario.Username)) return null; // se não existir retorna null

            // Retorna funcionário
            return funcionario;
        }

        /// <summary>
        /// Envio o número de funcionários registados
        /// </summary>
        /// <returns>Número de funcionários</returns>
        public static uint ContadorDeFuncionarios()
        {
            return ControladorDL.Funcionarios.ContadorDeFuncionarios();
        }

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
            if (!ControladorDL.Funcionarios.ExisteFuncionario(funcionario)) return false;

            return ControladorDL.Funcionarios.VerificaAcesso(funcionario);
        }

    }
}


