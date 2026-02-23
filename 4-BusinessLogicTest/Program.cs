using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.IO.Ports;
using System.Runtime.Remoting.Contexts;

using ManteHos.Entities;
using ManteHos.Persistence;
using ManteHos.Services;
using System.Xml.Linq;


namespace BusinessLogicTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IManteHosService service = new ManteHosService(new EntityFrameworkDAL(new ManteHosDbContext()));

                new Program(service);
            }
            catch (Exception e)
            {
                printError(e);
                Console.WriteLine("Press any key.");
                Console.ReadLine();
            }


        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        private IManteHosService service;

        Program(IManteHosService service)
        {
            this.service = service;

            DBInitialization();

            TestLoginLogout();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            // A partir de aquí vuestras invocaciones a las pruebas que diseñeis

        }

        void DBInitialization()
        {
            try
            {
                Console.WriteLine("INITIALIZATING DB...");

                service.DBInitialization();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("DATA CREATED.");
        }

        void TestLoginLogout()
        {
            Console.WriteLine();
            Console.WriteLine("Testing login...");

            try
            {
                service.Login("h1", "h1");
                if (service.UserLogged().Id != "h1")
                    Console.Out.WriteLine("Error con el usuario identificado.");
                else
                    Console.Out.WriteLine("WELCOME " + service.UserLogged().FullName);
                service.Logout();
                if (service.UserLogged() != null)
                    Console.Out.WriteLine("Sigue alguien identificado.");
            }
            catch (Exception e)
            {
                printError(e);
            }
        }

        //
        // A partir de aquí el resto de pruebas
        //





    }
}
