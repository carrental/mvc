using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;

namespace CarRental.Controllers
{
    public class CustomObj
    {
        public int id;
        public string desc;
        public DateTime stdt;
        public DateTime enddt;

        public CustomObj(int p1, string p2, DateTime dateTime1, DateTime dateTime2)
        {
            // TODO: Complete member initialization
            this.id = p1;
            this.desc = p2;
            this.stdt = dateTime1;
            this.enddt= dateTime2;
        }

    }
    public class CustomController : Controller
    {
        //
        // GET: /Custom/
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this); //initializes dhtmlxScheduler
            scheduler.LoadData = true;// allows loading data
            scheduler.EnableDataprocessor = true;// enables DataProcessor in order to enable implementation CRUD operations
            return View(scheduler);
        }


        //
       public ActionResult Data()
        {
           //events for loading to scheduler

           //selecting cars according to form values
            var context = new CarRental.Data.CarRentalDb();
            var orders = _SelectOrders(context).ToList();

            //if no cars found - show message and load default set
            if (orders.Count() == 0)
            {
                ViewData["Message"] = "Nothing was found on your request";
                orders = _SelectOrders(context).ToList();//select default set of events
            }


            var objList = new List<CustomObj>();
            for (int i = 0; i < 5; i++)
            {
                objList.Add(new CustomObj(i + 1, i.ToString(), DateTime.Today.AddDays(-i), DateTime.Today.AddDays(i)));
            }
           

            return new SchedulerAjaxData(objList);
        }
 
        //public ActionResult Save(Event updatedEvent, FormCollection formData)
        //{
        //    var action = new DataAction(formData);
        //    var context = new SampleDataContext();
 
        //    try
        //    {
        //        switch (action.Type)
        //        {
        //            case DataActionTypes.Insert: // your Insert logic
        //                context.Events.InsertOnSubmit(updatedEvent);
        //                break;
        //            case DataActionTypes.Delete: // your Delete logic
        //                updatedEvent = context.Events.SingleOrDefault(ev => ev.id == updatedEvent.id);
        //                context.Events.DeleteOnSubmit(updatedEvent);
        //                break;
        //            default:// "update"   // your Update logic
        //                updatedEvent = context.Events.SingleOrDefault(
        //                ev => ev.id == updatedEvent.id);
        //                UpdateModel(updatedEvent);
        //                break;
        //        }
        //        context.SubmitChanges();
        //        action.TargetId = updatedEvent.id;
        //    }
        //    catch (Exception a)
        //    {
        //        action.Type = DataActionTypes.Error;
        //    }
        //    return (new AjaxSaveResponse(action));
        //}

        /// <summary>
        /// Select cars
        /// </summary>
        /// <param name="context">context</param>
        /// <param name="state">state</param>
        /// <returns>IQueryable of car</returns>
        protected IQueryable<CarRental.Data.Order> _SelectOrders(CarRental.Data.CarRentalDb context)
        {
            IQueryable<CarRental.Data.Order> orders = from order in context.Orders select order;
            return orders;
        }

	}
}