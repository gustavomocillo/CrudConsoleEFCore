using ClientsManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClientsManagement.Functions
{
    public class Functions
    {
        public static void AddClient()
        {
            string name;
            string email;
            string phone;
            string state;
            string city;
            string street;
            string number;
            
            using var db = new AppDbContext.ClientsManagementDbContext();

            do
            {
                Console.Write("Nome do cliente: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));

            do {
                Console.Write("\nEmail: ");
                email = Console.ReadLine();
            } while (string.IsNullOrEmpty(email));

            do {
                Console.Write("\nTelefone: ");
                phone = Console.ReadLine();
            } while (string.IsNullOrEmpty(phone));

            do {
                Console.Write("\nSigla do estado: ");
                state = Console.ReadLine();
            } while (string.IsNullOrEmpty(state) || state.Length > 2);
            
            do {
                Console.Write("\nNome da cidade: ");
                city = Console.ReadLine();
            } while (string.IsNullOrEmpty(city));

            do {
                Console.Write("\nNome da rua: ");
                street = Console.ReadLine();
            } while (string.IsNullOrEmpty(street));
            
            do {
                Console.Write("\nNúmero: ");
                number = Console.ReadLine();
            } while (string.IsNullOrEmpty(number));

            var client = new Client()
            {
                Name = name,
                Email = email,
                Phone = phone
            };

            var address = new Address()
            {
                State = state,
                City = city,
                Street = street,
                Number = number,
                ClientId = client.Id,
                Client = client
            };

            try
            {
                db.AddRange(client, address);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void GetClientById()
        {
            using var db = new AppDbContext.ClientsManagementDbContext();

            Console.Write("Digite o Id do cliente: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    var client = db.Clients.Include(c => c.Address).FirstOrDefault(c => c.Id == id);

                    if (client == null)
                    {
                        Console.WriteLine("Cliente não encontrado. [Enter]");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Nome: {client.Name}");
                        Console.WriteLine($"Email: {client.Email}");
                        Console.WriteLine($"Telefone: {client.Phone}");
                        Console.WriteLine($"Estado: {client.Address.State}");
                        Console.WriteLine($"Cidade: {client.Address.City}");
                        Console.WriteLine($"Rua: {client.Address.Street}");
                        Console.WriteLine($"Número: {client.Address.Number}");
                        Console.WriteLine($"Id: {client.Id}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

            }
            else
            {
                Console.WriteLine("ERRO. [Enter]");
                Console.ReadKey();
            }
        }
        public static void GetAllClients() 
        {
            using var db = new AppDbContext.ClientsManagementDbContext();

            try
            {
                var clients = db.Clients.Include(c => c.Address).ToList();

                if (clients != null)
                {
                    foreach (var item in clients)
                    {
                        Console.WriteLine($"Nome: {item.Name}");
                        Console.WriteLine($"Email: {item.Email}");
                        Console.WriteLine($"Telefone: {item.Phone}");
                        Console.WriteLine($"Estado: {item.Address.State}");
                        Console.WriteLine($"Cidade: {item.Address.City}");
                        Console.WriteLine($"Rua: {item.Address.Street}");
                        Console.WriteLine($"Número: {item.Address.Number}");
                        Console.WriteLine($"Id: {item.Id}");
                        Console.WriteLine("-------------------------------------------");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void UpdateClient()
        {
            using var db = new AppDbContext.ClientsManagementDbContext();

            Console.Write("Id do cliente que deseja editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var clients = db.Clients.Include(c => c.Address).FirstOrDefault(c => c.Id == id);

                if (clients != null)
                {
                    string name;
                    string email;
                    string phone;
                    string state;
                    string city;
                    string street;
                    string number;

                    do
                    {
                        Console.Write("Nome do cliente: ");
                        name = Console.ReadLine();
                    } while (string.IsNullOrEmpty(name));

                    do
                    {
                        Console.Write("\nEmail: ");
                        email = Console.ReadLine();
                    } while (string.IsNullOrEmpty(email));

                    do
                    {
                        Console.Write("\nTelefone: ");
                        phone = Console.ReadLine();
                    } while (string.IsNullOrEmpty(phone));

                    do
                    {
                        Console.Write("\nSigla do estado: ");
                        state = Console.ReadLine();
                    } while (string.IsNullOrEmpty(state) || state.Length > 2);

                    do
                    {
                        Console.Write("\nNome da cidade: ");
                        city = Console.ReadLine();
                    } while (string.IsNullOrEmpty(city));

                    do
                    {
                        Console.Write("\nNome da rua: ");
                        street = Console.ReadLine();
                    } while (string.IsNullOrEmpty(street));

                    do
                    {
                        Console.Write("\nNúmero: ");
                        number = Console.ReadLine();
                    } while (string.IsNullOrEmpty(number));

                    clients.Name = name;
                    clients.Email = email;
                    clients.Phone = phone;
                    clients.Address.State = state;
                    clients.Address.City = city;
                    clients.Address.Street = street;
                    clients.Address.Number = number;

                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Cliente não encontrado. [Enter]");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("ERRO. [Enter]");
                Console.ReadKey();
            }
        }
        public static void DeleteClient()
        {
            using var db = new AppDbContext.ClientsManagementDbContext();

            Console.Write("Id do cliente que deseja remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    var client = db.Clients.Find(id);

                    if (client != null)
                    {
                        db.Clients.Remove(client);
                    }
                    else
                    {
                        Console.WriteLine("Cliente não encontrado. [Enter]");
                        Console.ReadKey();
                    }

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("ERRO. [Enter]");
                Console.ReadKey();
            }
        }
    }
}
