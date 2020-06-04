using ControladorBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBL
{
    public class Clientes
    {
        /// <summary>
        /// Função para registar um novo cliente
        /// </summary>
        /// <param name="novoCliente">Novo cliente</param>
        /// <returns>
        /// 0: Erro, já existe esse cliente ou número máximo de clientes atingido
        /// 1: Adicionado com sucesso;
        /// </returns>
        public static bool RegistaCliente(Cliente cliente)
        {
            if (ControladorDL.Clientes.ExisteCliente(cliente))
                return false;

            try
            {
                return ControladorDL.Clientes.RegistaCliente(cliente);
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Função para verificar se uma cliente já está registado
        /// </summary>
        /// <param name="nif">NIF do cliente a procurar</param>
        /// <returns>Verdadeiro caso exista, falso caso não exista</returns>
        public static bool ExisteCliente(int nif)
        {
            try
            {
                return ControladorDL.Clientes.ExisteCliente(nif);
            }
            catch (Exception e) { throw e; }
        }


        /// <summary>
        /// Eliminar um cliente
        /// </summary>
        /// <param name="nif">NIF do cliente</param>
        /// <returns>Falso caso ocorra algum erro; verdadeiro caso elimine</returns>
        public static bool EliminaCliente(int nif)
        {
            return ControladorDL.Clientes.EliminaCliente(nif);
        }
 
        /// <summary>
        /// Envia um cliente conforme o NIF
        /// </summary>
        /// <param name="nif">NIF do cliente</param>
        /// <returns>Retorna o cliente se existir ou null caso não exista</returns>
        public static Cliente EnviaCliente(int nif)
        {
            Cliente cliente = ControladorDL.Clientes.EnviaCliente(nif);

            // Verificar se o cliente existe
            if (string.IsNullOrEmpty(cliente.Nif.ToString())) return null; // se não existir retorna null

            // Retorna cliente
            return cliente;
        }

        /// <summary>
        /// Envio o número de clientes registados
        /// </summary>
        /// <returns>Número de clientes</returns>
        public static uint ContadorDeClientes()
        {
            return ControladorDL.Clientes.ContadorDeClientes();
        }
    }
}
