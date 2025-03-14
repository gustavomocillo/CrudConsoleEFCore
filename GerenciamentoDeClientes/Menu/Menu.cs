using ClientsManagement.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClientsManagement.Menu
{
    public class Menu
    {
        public void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Gerenciamento de Clientes");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1 - Adicionar Cliente");
            Console.WriteLine("2 - Consultar Cliente (ID)");
            Console.WriteLine("3 - Exibir Clientes");
            Console.WriteLine("4 - Editar Cliente");
            Console.WriteLine("5 - Remover Cliente");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("---------------------------");

            Console.Write("O que você deseja? ");
            
            if (int.TryParse(Console.ReadLine(), out int option))
            {
                Configuration(option);
            }
            else
            {
                Console.WriteLine("\nERRO. [Enter]");
                Console.ReadKey();
                MainMenu();
            }
        }
        public void Configuration(int option)
        {
            Console.Clear();

            switch (option)
            {
                case 0: 
                    Environment.Exit(0);
                    break;
                case 1:
                    Functions.Functions.AddClient();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 2:
                    Functions.Functions.GetClientById();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 3:
                    Functions.Functions.GetAllClients();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    Functions.Functions.UpdateClient();
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 5:
                    Functions.Functions.DeleteClient();
                    Console.ReadKey();
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("\nERRO! [Enter]");
                    Console.ReadKey();
                    MainMenu();
                    break;
            }
        }
    }
}
