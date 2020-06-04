// Autor: César Morgado
// Email: a3025@alunos.ipca.pt
// Data: 23/04/2020


using ControladorBL;
using ControladorBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDeTarefas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variáveis
            int opcao = -1;

            if (Funcionarios.ContadorDeFuncionarios() == 0)
            {
                Console.Write("Não existem funcionários registados!\nRegiste o primeiro funcionário!");

                RegistaFuncionario();
            }
            else
            {
                Login();
            }



            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    default: break;

                    case 1: RegistarCliente(); break;

                    case 2: ExisteCliente(); break;

                    case 3: RegistaObrigacao(); break;

                    case 4: ExisteObrigacao(); break;

                    case 5: RegistaFuncionario(); break;

                    case 6: ExisteFuncionario(); break;

                    case 7: RegistaRegisto(); break;

                    case 8: ListaPorObrigacao(); break;

                    case 9: ListaPorCliente(); break;

                    case 10: EliminaCliente(); break;

                    case 11: EliminaObrigacao(); break;

                    case 12: EliminaFuncionario(); break;

                    case 0: break; // Caso de saída
                }

                if (opcao != 0) { Console.WriteLine("Prima uma tecla para continuar..."); Console.ReadKey(); }

            } while (opcao != 0);
        }

        /// <summary>
        /// Método para apresentar o menu e recolher a opção do utilizador
        /// </summary>
        /// <returns>Opção escolhida</returns>
        static int Menu()
        {
            int opcao = -1;

            Console.Clear();

            Console.WriteLine("====== MENU ======");
            Console.WriteLine("1 - Registar cliente");
            Console.WriteLine("2 - Existe cliente?");
            Console.WriteLine();
            Console.WriteLine("3 - Registar obrigação");
            Console.WriteLine("4 - Existe obrigação?");
            Console.WriteLine();
            Console.WriteLine("5 - Registar funcionário");
            Console.WriteLine("6 - Existe funcionário?");
            Console.WriteLine();
            Console.WriteLine("7 - Registar Registo");
            Console.WriteLine();
            Console.WriteLine("8 - Listar registos por obrigação");
            Console.WriteLine("9 - Listar registos por cliente");
            Console.WriteLine();
            Console.WriteLine("10 - Elimina cliente");
            Console.WriteLine("11 - Elimina obrigação");
            Console.WriteLine("12 - Elimina funcionário");
            Console.WriteLine();
            Console.WriteLine("0 - Sair");
            Console.Write("Introduza a opção que deseja: ");
            opcao = RegrasGerais.LeInteiro();

            return opcao;
        }

        static void Login()
        {
            // Variáveis auxiliares
            // Variáveis auxiliares
            string username, password;
            Funcionario funcionario;
            bool logado;
            int tentativas;

            // Inicializar variáveis
            logado = false;
            tentativas = 0;

            // Ciclo para verificar o login
            while (!logado)
            {
                // Verificar se já tentou efetuado o login sem sucesso
                if (tentativas > 0)
                    Console.WriteLine("Acesso incorreto!! Tente outra vez");

                Console.Write("Acesso ao programa!\nInsira o username: ");
                username = Console.ReadLine();

                Console.Write("Insira a password: ");
                password = Console.ReadLine();

                funcionario = new Funcionario(username, password);

                // Verifica se o acesso é válido
                logado = Funcionarios.VerificaAcesso(funcionario);

                // Incrementa o número de tentativas
                tentativas++;
            }
        }

        /// <summary>
        /// Método para registar um novo cliente
        /// </summary>
        /// <returns></returns>
        static void RegistarCliente() // Opção 1 do menu
        {
            // Variáveis auxiliares
            int nif;
            string nome;
            Cliente cliente;

            Console.Write("Insira o NIF do cliente: ");
            nif = RegrasGerais.LeInteiro();

            // Verificar se o NIF do cliente já está registado
            if (Clientes.ExisteCliente(nif))
            {
                Console.WriteLine("O NIF indicado já se encontra registado!");
                return;
            }

            Console.Write("Insira o nome: ");
            nome = Console.ReadLine();

            // Verificar se o nome inserido é válido
            if (!RegrasGerais.ValidaNome(nome))
            {
                Console.WriteLine("O nome não é válido!\n Tente novamente!");
                return;
            }

            cliente = new Cliente(nif, nome);


            // se o cliente não for inserido
            if (!Clientes.RegistaCliente(cliente))
            {
                Console.WriteLine("O cliente não foi adicionado.");
                return;
            }

            Console.WriteLine("O cliente foi adicionado.");
        }
        

        /// <summary>
        /// Método para verificar se um cliente já está registado
        /// </summary>
        static void ExisteCliente() // Opção 2 do menu
        {
            // Variáveis auxiliares
            int nif;

            // Limpar consola
            Console.Clear();

            // Perguntar o NIF do cliente a verificar
            Console.WriteLine("Insira o NIF do cliente que pretende verificar que existe: ");
            nif = Convert.ToInt32(Console.ReadLine());

            if (Clientes.ExisteCliente(nif))
            {
                Console.WriteLine("O cliente existe!");
                return;
            }

            Console.WriteLine("O cliente não existe!");
        }


        /// <summary>
        /// Método para registar uma nova obrigação
        /// </summary>
        /// <returns></returns>
        static void RegistaObrigacao() // Opção 3 do menu
        {
            // Variáveis auxiliares
            string nome;
            Obrigacao obrigacao;

            Console.Write("Insira o nome da obrigação: ");
            nome = Console.ReadLine();

            // Verificar se a Obrigação já está registada
            if (Obrigacoes.ExisteObrigacao(nome))
            {
                Console.WriteLine("A obrigação indicada já se encontra registada!");
                return;
            }

            obrigacao = new Obrigacao(nome);

            if (Obrigacoes.RegistaObrigacao(obrigacao))
            {
                Console.WriteLine("A obrigação foi adicionada!");
                return;
            }

            Console.WriteLine("A obrigação não foi adicionada!");
        }


        /// <summary>
        /// Método para verificar se uma obrigacao já está registada
        /// </summary>
        static void ExisteObrigacao() // Opção 4 do menu
        {
            // Variáveis auxiliares
            string nome;

            // Limpar consola
            Console.Clear();

            // Perguntar o nome da obrigação a verificar
            Console.WriteLine("Insira a obrigação que pretende verificar que existe: ");
            nome = Console.ReadLine();

            if (Obrigacoes.ExisteObrigacao(nome))
            {
                Console.WriteLine("A obrigacao existe!");
                return;
            }

            Console.WriteLine("A obrigacao não existe!");
        }


        /// <summary>
        /// Método para registar um novo funcionário
        /// </summary>
        /// <returns></returns>
        static void RegistaFuncionario() // Opção 5 do menu
        {
            // Variáveis auxiliares
            int tentativas;
            string username, password;
            Funcionario funcionario;

            // Inicializar variáveis
            tentativas = 0;
            username = "";

            while (!RegrasGerais.ValidaNome(username))
            {
                if (tentativas > 0)
                    Console.WriteLine("O username não é válido");

                Console.Write("Insira o username: ");
                username = Console.ReadLine();

                tentativas++;
            }

            Console.Write("Insira a password: ");
            password = Console.ReadLine();

            funcionario = new Funcionario(username, password);


            // Se o funcionário não for inserido
            if (Funcionarios.RegistaFuncionario(funcionario) == 0)
            {
                Console.WriteLine("O funcionário não foi registado");
                return;
            }

            Console.WriteLine("O funcionário foi registado");
        }


        /// <summary>
        /// Método para verificar se determinado funcionário existe
        /// </summary>
        /// <returns></returns>
        static void ExisteFuncionario()   // Opção 6 do menu
        {
            // Variáveis auxiliares
            string username;

            // Limpar consola
            Console.Clear();

            // Perguntar o username do funcionário a verificar
            Console.WriteLine("Insira o Username do funcionário que pretende verificar que existe: ");
            username = Console.ReadLine();

            if (ControladorBL.Funcionarios.ExisteFuncionario(username))
            {
                Console.WriteLine("O Funcionário existe!");
                return;
            }

            Console.WriteLine("O Funcionário não existe!");
        }


        /// <summary>
        /// Método para registar tarefas efetuadas
        /// </summary>
        /// <returns></returns>
        static void RegistaRegisto()  // Opção 7 do menu
        {
            // Variáveis auxiliares
            Cliente cliente;
            Funcionario funcionario;
            Obrigacao obrigacao;
            Registo registo;
            Estado estadoRegisto;
            int mes, ano, nif, tentativas;
            string username, nomeObrigacao;

            // Inicializar variáveis
            cliente = null;
            funcionario = null;
            obrigacao = null;
            tentativas = 0;
            mes = 0;
            ano = 0;

            Console.WriteLine("Cria registo!");

            // Ciclo que pergunta o cliente até ser válido
            while (cliente == null)
            {
                if (tentativas > 0)
                    Console.WriteLine("Esse cliente não existe!");

                Console.WriteLine("Insira o NIF do cliente associado: ");
                nif = RegrasGerais.LeInteiro();

                cliente = Clientes.EnviaCliente(nif);
                tentativas++;
            }

            tentativas = 0;

            // Ciclo que pergunta o cliente até ser válido
            while (funcionario == null)
            {
                if (tentativas > 0)
                    Console.WriteLine("Esse funcionário não existe!");

                Console.WriteLine("Insira o username do funcionário associado: ");
                username = Console.ReadLine();

                funcionario = Funcionarios.EnviaFuncionario(username);
                tentativas++;
            }

            tentativas = 0;

            // Ciclo que pergunta a obrigação até ser válida
            while (obrigacao == null)
            {
                if (tentativas > 0)
                    Console.WriteLine("Essa obrigação não existe!");

                Console.WriteLine("Insira o nome da obrigação associada: ");
                nomeObrigacao = Console.ReadLine();

                obrigacao = Obrigacoes.EnviaObrigacao(nomeObrigacao);
                tentativas++;
            }

            tentativas = 0;

            // Pede ao utilizador o estado do registo
            estadoRegisto = RegrasGerais.LeEstado();

            // Ciclo para verificar se o mês é válido
            while (mes > 12 || mes < 1)
            {
                if (tentativas > 0)
                    Console.WriteLine("Esse mês não existe!");

                Console.WriteLine("Insira o mês do registo: ");
                mes = RegrasGerais.LeInteiro();

                tentativas++;
            }

            tentativas = 0;

            // Ciclo para verificar se o ano é válido
            while (ano < 2000 || ano > DateTime.Now.Year)
            {
                if (tentativas > 0)
                    Console.WriteLine("Esse ano não é aceite!");

                Console.WriteLine("Insira o ano do registo: ");
                ano = RegrasGerais.LeInteiro();

                tentativas++;
            }

            // Cria o registo
            registo = new Registo(cliente, funcionario, obrigacao, mes, ano, estadoRegisto);

            // Verificar se o registo não foi adicionado
            if (!Registos.RegistaRegisto(registo))
            {
                Console.WriteLine("O registo não foi registado.");
                return;
            }

            Console.WriteLine("O registo foi registado.");
        }

        /// <summary>
        /// 
        /// </summary>
        static void ListaPorObrigacao()
        {
            // Variáveis auxiliares
            Obrigacao obrigacao;
            string nomeObrigacao;
            List<Registo> listagemRegistos;

            // Perguntar ao utilizador o nome da obrigação
            Console.WriteLine("Insira o nome da obrigação associada: ");
            nomeObrigacao = Console.ReadLine();

            // Obter obrigação
            obrigacao = Obrigacoes.EnviaObrigacao(nomeObrigacao);
            
            // Verificar se a obrigação não existe
            if (obrigacao == null)
            {
                Console.WriteLine("Essa obrigação não se encontra registada");
                return;
            }

            // Obter registos associados à obrigação
            listagemRegistos = Registos.ListarPorObrigacao(obrigacao);

            // Verificar se existem registos
            if (listagemRegistos.Count == 0)
            {
                Console.WriteLine("Não existem registos nessa obrigação.");
                return;
            }


            Console.WriteLine($"Nome da obrigação: {obrigacao.Nome}");

            // Listar registos da obrigação
            foreach (Registo r in listagemRegistos)
            {
                Console.WriteLine($"Mês: {r.Mes}");
                Console.WriteLine($"Ano: {r.Ano}");
                Console.WriteLine($"Estado: {r.Estado}");
                Console.WriteLine($"Cliente: {r.Cliente.Nome} | NIF: {r.Cliente.Nif}");
                Console.WriteLine($"Funcionário: {r.Funcionario.Username}");
                Console.WriteLine("########\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void ListaPorCliente()
        {
            // Variáveis auxiliares
            Cliente cliente;
            int nifCliente;
            List<Registo> listagemRegistos;

            // Perguntar ao utilizador o nif do cliente
            Console.WriteLine("Insira o nif do cliente: ");
            nifCliente = RegrasGerais.LeInteiro();

            // Obter cliente
            cliente = Clientes.EnviaCliente(nifCliente);

            // Verificar se o cliente não existe
            if (cliente == null)
            {
                Console.WriteLine("Esse cliente não se encontra registado");
                return;
            }

            // Obter registos do cliente
            listagemRegistos = Registos.ListarPorCliente(cliente);

            // Verificar se tem registos associados
            if (listagemRegistos.Count == 0)
            {
                Console.WriteLine("Não existem registos nessa obrigação.");
                return;
            }

            
            Console.WriteLine($"Nome do cliente: {cliente.Nome}");

            // Listar registos do cliente
            foreach (Registo r in listagemRegistos)
            {
                Console.WriteLine($"Obrigação: {r.Obrigacao.Nome}");
                Console.WriteLine($"Mês: {r.Mes}");
                Console.WriteLine($"Ano: {r.Ano}");
                Console.WriteLine($"Estado: {r.Estado}");
                Console.WriteLine($"Funcionário: {r.Funcionario.Username}");
                Console.WriteLine("########\n");
            }
        }

        /// <summary>
        /// Método para eliminar um cliente
        /// </summary>
        /// <returns></returns>
        static void EliminaCliente()  // Opção 10 do menu
        {
            // Variável auxiliar
            int nif;
            string aux;

            // Limpar consola
            Console.Clear();

            // Perguntar ao utilizador o nif do cliente que pretende eliminar
            Console.Write("Insira o nif do cliente que deseja eliminar: ");
            nif = RegrasGerais.LeInteiro();

            if (nif == -1)
            {
                Console.WriteLine("O nif é inválido.");
                return;
            }

            if (!ControladorBL.Clientes.ExisteCliente(nif))
            {
                Console.WriteLine("Esse cliente não se encontra registado!");
                return;
            }

            Console.Clear();

            Console.Write("ESTA AÇÃO É IRREVERSÍVEL! TODOS OS DADOS DESTE CLIENTE SÃO ELIMINADOS!\n TEM A CERTEZA QUE DESEJA CONTINUAR? CASO SIM, DIGITE \"S\"\n");
            aux = Console.ReadLine();

            if (aux != "S")
            {
                Console.WriteLine("O cliente não foi eliminado porque o utilizador cancelou.");
                return;
            }

            if (ControladorBL.Clientes.EliminaCliente(nif))
            {
                Console.WriteLine("O cliente foi eliminado.");
                return;
            }

            Console.WriteLine("O cliente não foi eliminado.");
        }


        /// <summary>
        /// Método para eliminar uma obrigação
        /// </summary>
        /// <returns></returns>
        static void EliminaObrigacao()  // Opção 11 do menu
        {
            // Variável auxiliar
            string nome, aux;

            // Limpar consola
            Console.Clear();

            // Perguntar o nome da obrigação que pretende eliminar
            Console.Write("Insira a obrigacao que deseja eliminar: ");
            nome = Console.ReadLine();

            
            if (!ControladorBL.Obrigacoes.ExisteObrigacao(nome))
            {
                Console.WriteLine("Essa obrigacao não se encontra registada!");
                return;
            }

            Console.Clear();

            Console.Write("ESTA AÇÃO É IRREVERSÍVEL! A OBRIGAÇAO INDICADA SERÁ ELIMINADA!\n TEM A CERTEZA QUE DESEJA CONTINUAR? CASO SIM, DIGITE \"S\"\n");
            aux = Console.ReadLine();

            if (aux != "S")
            {
                Console.WriteLine("A obrigação não foi eliminada porque o utilizador cancelou.");
                return;
            }

            if (ControladorBL.Obrigacoes.EliminaObrigacao(nome))
            {
                Console.WriteLine("A obrigacao foi eliminado.");
                return;
            }

            Console.WriteLine("A obrigacao não foi eliminado.");
        }


        /// <summary>
        /// Método para eliminar um funcionário
        /// </summary>
        /// <returns></returns>
        static void EliminaFuncionario()  // Opção 12 do menu
        {
            // Variável auxiliar
            string aux, username;

            // Limpar consola
            Console.Clear();

            // Perguntar ao utilizador o username do funcionário que pretende eliminar
            Console.Write("Insira o username do funcionário que deseja eliminar: ");
            username = Console.ReadLine();


            if (!ControladorBL.Funcionarios.ExisteFuncionario(username))
            {
                Console.WriteLine("Esse funcionário não se encontra registado!");
                return;
            }

            Console.Clear();

            Console.Write("ESTA AÇÃO É IRREVERSÍVEL! TODOS OS DADOS DESTE FUNCIONÁRIO SÃO ELIMINADOS!\n TEM A CERTEZA QUE DESEJA CONTINUAR? CASO SIM, DIGITE \"S\"\n");
            aux = Console.ReadLine();

            if (aux != "S")
            {
                Console.WriteLine("O funcionário não foi eliminado porque o utilizador cancelou.");
                return;
            }

            if (ControladorBL.Funcionarios.EliminaFuncionario(username))
            {
                Console.WriteLine("O funcionário foi eliminado.");
                return;
            }

            Console.WriteLine("O funcionário não foi eliminado.");
        }
    }
}
