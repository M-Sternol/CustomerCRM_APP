using System;
using System.Security.Cryptography.X509Certificates;
using DataStorage;
using LoginSystem = CustomerCRM.App.LoginManagement.LoginSystem;
using Registration = CustomerCRM.App.Registration.Registration;
using CustomerCRM.Domain.Services.Security;
using DataStorage.Raport;

namespace CustomerCRM
{
    internal class Program
    {
        private static IServicePasswordHasher passwordHasher;

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("====== Witaj! w systemie CRM Dla Klientów ======" + "\n");
                Console.WriteLine("1.Zaloguj się");
                Console.WriteLine("2.Zarejestruj się");
                Console.WriteLine("0.Wyjdź" + "\n");
                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        Console.Clear();
                        LoginSystem loginSystem = new LoginSystem();
                        loginSystem.Logging();
                        break;
                    case "2":
                        Console.Clear();
                        Registration RegistrationService = new Registration(passwordHasher);
                        RegistrationService.Register();
                        break;
                    case "0":
                        Console.WriteLine("Do Zobaczenia!");
                        isRunning = false;
                        break;
                    case "raport":
                        ReportGenerator reportGenerator = new ReportGenerator();
                        reportGenerator.GenerateReport();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Nieprawidłowa operacja! Spróbuj ponownie");
                        break;
                }
            }
        }

    }
}