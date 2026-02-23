using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManteHos.Entities;
using ManteHos.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Program();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
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


        Program()
        {
            IDAL dal = new EntityFrameworkDAL(new ManteHosDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal)
        {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE PERSONAS");
            //public Course(string descr, string name)

            Head head = new Head("Ibañez", "h1", "h1");
            dal.Insert<Head>(head);
            dal.Commit();

            Master master1 = new Master("Bárcenas", "m1", "m1");
            dal.Insert<Master>(master1);
            dal.Commit();

            Master master2 = new Master("He-Man", "m2", "m2");
            dal.Insert<Master>(master2);
            dal.Commit();

            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            dal.Insert<Operator>(op1);
            dal.Commit();

            Employee empleado1 = new Employee("Sacarino", "e2", "e2");
            dal.Insert<Employee>(empleado1);
            dal.Commit();

            
            Console.WriteLine("\n// CREACIÓN DE ÁREAS");

            // Area a1 (asignada a master1)
            Area a1 = new Area("Área A", master1);
            dal.Insert<Area>(a1);
            master1.Area = a1; // Relación bidireccional

            // Area a2 (asignada a master2)
            Area a2 = new Area("Área B", master2);
            dal.Insert<Area>(a2);
            master2.Area = a2; // Relación bidireccional

            dal.Commit(); // Se guardan las 2 áreas y se actualizan las referencias en los masters

           
            Console.WriteLine("\n// CREACIÓN DE PIEZAS");

            // Part p1 (con stock inicial)
            Part p1 = new Part("P-COOL-FAN", 20, "Ventilador Refrigeración", 5, "Unidades", 15.50f);
            dal.Insert<Part>(p1);

            // Part p2 (otra pieza)
            Part p2 = new Part("P-FILTER", 10, "Filtro de Aire", 3, "Unidades", 5.00f);
            dal.Insert<Part>(p2);

            dal.Commit(); // Se guardan las 2 piezas

            
            Console.WriteLine("\n// CREACIÓN DE INCIDENTES");
            DateTime hoy = DateTime.Today;
            // Incident i1 (Reportado por empleado1, asignado a a1)
            Incident i1 = new Incident("Dpto. 1", "Aire Acondicionado Roto", hoy.AddDays(-2), empleado1);
            i1.Area = a1; // Relación con Area
            a1.Incidents.Add(i1); // Relación bidireccional
            empleado1.ReportedIncidents.Add(i1); // Relación bidireccional con Reporter
            dal.Insert<Incident>(i1);

            // Incident i2 (Reportado por empleado1, asignado a a2)
            Incident i2 = new Incident("Dpto. 2", "Caldera sin presión", hoy.AddDays(-1), empleado1);
            i2.Area = a2; // Relación con Area
            a2.Incidents.Add(i2);
            empleado1.ReportedIncidents.Add(i2);
            dal.Insert<Incident>(i2);

            dal.Commit(); // Se guardan los 2 incidentes

            Console.WriteLine("\n// CREACIÓN DE PARTE DE TRABAJO");

            // WorkOrder o1 (Asignado al incidente i1)
            WorkOrder o1 = new WorkOrder(hoy, i1);

            // Relación N:M con Operator: op1
            o1.Operators.Add(op1);
            op1.WorkOrders.Add(o1);

            // Asignar el WorkOrder al Incidente
            i1.WorkOrder = o1;

            dal.Insert<WorkOrder>(o1);
            dal.Commit(); // Se guarda el WorkOrder y se actualizan las relaciones N:M y el Incidente

           
            Console.WriteLine("\n// CREACIÓN DE PIEZA USADA");

            // UsedPart up1 (Usa 5 unidades de p1. Stock p1: 20 -> 15)
            UsedPart up1 = new UsedPart(5, p1);

            // Relación N:M con WorkOrder: o1
            o1.UsedParts.Add(up1);

            dal.Insert<UsedPart>(up1);
            dal.Commit(); 

            Console.WriteLine("\nBase de datos poblada correctamente.");
        }

        

        private void PrintSampleDB(IDAL dal)
        {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nPersonas creadas:");
            foreach (Employee p in dal.GetAll<Employee>())
                Console.WriteLine("   FullName: " + p.FullName + " Id: " + p.Id + " Password: " + p.Password);

            // Show the rest of the database
            Console.WriteLine("\nPiezas creadas:");
            foreach (Part p in dal.GetAll<Part>())
                Console.WriteLine("   Code: " + p.Code + " Description: " + p.Description + " CurrentQuantity: " + p.CurrentQuantity);

            Console.WriteLine("\nÁreas, Indicencias, Órdenes de trabajo y piezas pedidas creadas:");
            foreach (Area a in dal.GetAll<Area>())
            {
                Console.WriteLine("   Name: " + a.Name);
                foreach (Incident i in a.Incidents)
                {
                    Console.WriteLine("      Incident Id: " + i.Id + " ReportDate: " + i.ReportDate + " Description: " + i.Description);
                    WorkOrder o = i.WorkOrder;
                    if (o != null)
                    {
                        Console.WriteLine("          WorkOrder Id: " + o.Id + " StartDate: " + o.StartDate);
                        foreach (UsedPart up in o.UsedParts)
                        {
                            Console.WriteLine("             Part Description: " + up.Part.Description + " Quantity: " + up.Quantity);
                        }
                    }

                }
            }


        }

    }

}
