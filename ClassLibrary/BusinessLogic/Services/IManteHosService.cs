using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteHos.Entities;


namespace ManteHos.Services
{
    public interface IManteHosService
    {
        void RemoveAllData();
        void Commit();
        void DBInitialization();

     
        void Login(string login, string password);

        void Logout();

        void ReviewIncident(Incident incident, bool accepted, string rejectReason, Area area, Priority newPriority);

        //WorkOrder AssignWorkOrder(int incidentID, List<Operator> operators);

        Employee UserLogged();

        void AddIncident(Incident incident);

        WorkOrder AssignWorkOrder(Incident incident, List<Operator> operators);

        WorkOrder CloseWorkOrder(WorkOrder wo, string report, DateTime endDate);

        IEnumerable<Area> GetAreas();

        IEnumerable<Incident> GetIncidentsPendingReview();

        //IEnumerable<Operator> GetOpenWorkerOrderForIncident(Incident incident);

        
        List<Incident> GetIncidentsForMaster(string masterId);
        List<Operator> GetOperatorsByArea(int areaId);
        List<Operator> GetOperatorsForIncident(Incident incident);
        WorkOrder AddWorkOrder(Incident incident);
        void AssignOperatorToWorkOrder(WorkOrder wo, Operator op);
        void RemoveOperatorFromWorkOrder(WorkOrder wo, Operator op);
        WorkOrder GetWorkOrderByIncident(Incident incident);
        void UpdateWorkOrderOperators(WorkOrder workOrder, List<Operator> newOperators);
        List<WorkOrder> GetOpenWorkOrdersForOperator(Operator op);
        WorkOrder GetWorkOrderById(int id);
        List<Incident> GetPendingIncidents();
        List<Area> GetAllAreas();



    }
}