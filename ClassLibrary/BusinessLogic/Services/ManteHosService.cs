using ManteHos.Entities;
using ManteHos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManteHos.Services
{
    public class ManteHosService : IManteHosService
    {
        private readonly IDAL dal;
        private Employee User_Logged;

        public ManteHosService(IDAL dal)
        {
            this.dal = dal;
        }

        public void RemoveAllData() { dal.RemoveAllData(); }
        public void Commit() { dal.Commit(); }

        // 1. INICIALIZACIÓN DE DATOS (Vital que se ejecute)
        public void DBInitialization()
        {
            RemoveAllData();

            // JEFE
            Head head = new Head("Ibañez", "h1", "h1"); dal.Insert(head);

            // MAESTROS
            Master m1 = new Master("Bárcenas", "m1", "m1"); dal.Insert(m1);

            // AREAS
            Area a1 = new Area("Mecánica", m1); dal.Insert(a1);

            // OPERARIOS
            Operator op1 = new Operator("Pepe Gotera", "o1", "o1", Shift.Morning);
            op1.Area = a1;
            dal.Insert(op1);

            // EN DBInitialization (ManteHosService.cs)

            // ... (código de Mecánica que ya tienes) ...

            // AÑADIR ESTO PARA RECUPERAR LAS OTRAS ÁREAS
            Master m2 = new Master("He-Man", "m2", "m2"); dal.Insert(m2);
            Area a2 = new Area("Electricidad", m2); dal.Insert(a2);

            Master m3 = new Master("Picasso", "m3", "m3"); dal.Insert(m3);
            Area a3 = new Area("Pintura", m3); dal.Insert(a3);

            // ... (resto del código) ...



            dal.Commit();
        }

        // 2. GUARDAR LA ORDEN (Método Nuclear)
        public WorkOrder AssignWorkOrder(Incident incident, List<Operator> operators)
        {
            Incident incReal = dal.GetById<Incident>(incident.Id);
            WorkOrder wo = new WorkOrder(DateTime.Now, incReal);

            // Guardamos antes de asignar operarios para generar el ID
            dal.Insert(wo);
            dal.Commit();

            // Recuperamos la orden "VIVA"
            WorkOrder ordenViva = dal.GetById<WorkOrder>(wo.Id);
            if (ordenViva.Operators == null) ordenViva.Operators = new List<Operator>();

            foreach (var opGUI in operators)
            {
                Operator opReal = dal.GetById<Operator>(opGUI.Id);
                ordenViva.Operators.Add(opReal);
            }

            incReal.Status = Status.InProgress;
            dal.Commit();

            return ordenViva;
        }

        public List<WorkOrder> GetOpenWorkOrdersForOperator(Operator op)
        {
            if (op == null) return new List<WorkOrder>();

            // Descargamos todo para asegurar (evita líos de SQL)
            var todas = dal.GetAll<WorkOrder>().ToList();

            // Filtramos en memoria corregiendo el error de la fecha
            return todas.Where(wo =>
                // AQUI ESTABA EL ERROR:
                // Comprobamos si es nulo O si es la fecha mínima (año 0001)
                (wo.EndDate == null || wo.EndDate == DateTime.MinValue)
                &&
                // Comprobamos el operario asegurando espacios limpios
                wo.Operators != null && wo.Operators.Any(o => o.Id.Trim() == op.Id.Trim())
            ).ToList();
        }

        // --- MÉTODOS QUE FALTABAN (LOS AÑADO AQUÍ) ---

        public List<Operator> GetOperatorsByArea(int areaId)
        {
            return dal.GetWhere<Operator>(o => o.Area != null && o.Area.Id == areaId).ToList();
        }

        public WorkOrder AddWorkOrder(Incident incident)
        {
            if (incident == null) throw new ServiceException("Incidencia nula");
            Incident incReal = dal.GetById<Incident>(incident.Id);
            WorkOrder wo = new WorkOrder(DateTime.Now, incReal);
            dal.Insert(wo);
            dal.Commit();
            return wo;
        }

        // --- RESTO DE MÉTODOS DE LA INTERFAZ ---

        public void Login(string l, string p) { User_Logged = dal.GetById<Employee>(l); }
        public Employee UserLogged() { return User_Logged; }
        public void Logout() { User_Logged = null; }

        //public IEnumerable<Incident> GetIncidentsPendingReview() { return dal.GetAll<Incident>().Where(i => i.Status == Status.Created); }
        public void ReviewIncident(Incident i, bool a, string r, Area ar, Priority p)
        {
            i.Status = a ? Status.Accepted : Status.Rejected;
            if (a) { i.Area = ar; i.Priority = p; } else { i.RejectReason = r; }
            dal.Commit();
        }
        public List<Incident> GetIncidentsForMaster(string id)
        {
            var m = dal.GetById<Master>(id);
            return dal.GetWhere<Incident>(i => i.Area.Id == m.Area.Id && i.Status == Status.Accepted).ToList();
        }
        public WorkOrder GetWorkOrderByIncident(Incident i)
        {
            return dal.GetWhere<WorkOrder>(w => w.Incident.Id == i.Id).FirstOrDefault();
        }
        public void AddIncident(Incident i) { dal.Insert(i); dal.Commit(); }
        //public IEnumerable<Area> GetAreas() { return dal.GetAll<Area>(); }
        // EN ManteHosService.cs

        // CAMBIO 1: Añadir .ToList() aquí para que el ComboBox no explote
        public IEnumerable<Area> GetAreas()
        {
            return dal.GetAll<Area>().ToList(); // <--- ¡IMPORTANTE EL .ToList()!
        }

        // CAMBIO 2: Añadir .ToList() aquí también por si acaso
        public IEnumerable<Incident> GetIncidentsPendingReview()
        {
            return dal.GetAll<Incident>()
                      .Where(i => i.Status == Status.Created)
                      .ToList(); // <--- ¡IMPORTANTE EL .ToList()!
        }
        public List<Operator> GetOperatorsForIncident(Incident i)
        {
            // Reutilizamos el método que acabamos de añadir
            if (i.Area == null) return new List<Operator>();
            return GetOperatorsByArea(i.Area.Id);
        }

        public WorkOrder CloseWorkOrder(WorkOrder wo, string r, DateTime d)
        {
            var real = dal.GetById<WorkOrder>(wo.Id);
            real.RepairReport = r; real.EndDate = d; real.Incident.Status = Status.Completed;
            dal.Commit(); return real;
        }
        public void UpdateWorkOrderOperators(WorkOrder w, List<Operator> ops)
        {
            // Implementación básica necesaria para que no falle la interfaz
            var real = dal.GetById<WorkOrder>(w.Id);
            real.Operators.Clear();
            foreach (var op in ops) real.Operators.Add(dal.GetById<Operator>(op.Id));
            dal.Commit();
        }

        // Métodos vacíos o simples para cumplir interfaz
        public void AssignOperatorToWorkOrder(WorkOrder w, Operator o) { }
        public void RemoveOperatorFromWorkOrder(WorkOrder w, Operator o) { }
        public void AddPerson(Employee e) { dal.Insert(e); dal.Commit(); }
        public void AddArea(Area a) { dal.Insert(a); dal.Commit(); }
        public void AddPart(Part p) { dal.Insert(p); dal.Commit(); }
        // EN ManteHosService.cs

        public WorkOrder GetWorkOrderById(int id)
        {
            // Recupera la orden completa usando el ID
            return dal.GetById<WorkOrder>(id);
        }

        public List<Incident> GetPendingIncidents()
        {
            // Usamos el DAL para filtrar
            return dal.GetWhere<Incident>(x => x.Status == Status.Created).ToList();
        }

        public List<Area> GetAllAreas()
        {
            return dal.GetAll<Area>().ToList();
        }
    }
}