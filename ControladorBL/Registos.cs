using ControladorBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorBL
{
    public class Registos
    {
        public static bool RegistaRegisto(Registo registo)
        {
            if (ControladorDL.Registos.ExisteRegisto(registo))
                return false;

            try
            {
                return ControladorDL.Registos.RegistaRegisto(registo);
            }
            catch (Exception e) { throw e; }
        }

        public static bool ExisteRegisto(Registo registo)
        {
            try
            {
                return ControladorDL.Registos.ExisteRegisto(registo);
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// Função que retorna uma lista com os registos da obrigação
        /// </summary>
        /// <param name="obrigacao">Obrigação que pretendemos verificar nos registos</param>
        /// <returns>Listagem com os registos</returns>
        public static List<Registo> ListarPorObrigacao(Obrigacao obrigacao)
        {
            return ControladorDL.Registos.ListarPorObrigacao(obrigacao);
        }

        /// <summary>
        /// Função que retorna uma lista com os registos do cliente
        /// </summary>
        /// <param name="cliente">Cliente que pretendemos verificar os registos</param>
        /// <returns>Listagem com os registos</returns>
        public static List<Registo> ListarPorCliente(Cliente cliente)
        {
            return ControladorDL.Registos.ListarPorCliente(cliente);
        }




    } // public class Registos
} // namespace ControladorBL
