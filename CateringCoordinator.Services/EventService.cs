using CateringCoodinator.Data;
using CateringCoordinator.Data;
using CateringCoordinator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId,
                    PrepArea = model.PrepArea,
                    NumOfGuest = model.NumOfGuest,
                    NumOfHelpers = model.NumOfHelpers,
                    SuppliesNeeded = model.SuppliesNeeded,
                    Location = model.Location,
                    IsFullService = model.IsFullService,
                    DateOfEvent = model.DateOfEvent.Date,
                    CostOfEvent = model.CostOfEvent,

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventList> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Events
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new EventList
                        {
                            EventId = e.EventId,
                            Customer = e.Customer,                           
                            Foods =  e.Foods,                         
                            PrepArea = e.PrepArea,
                            NumOfGuest = e.NumOfGuest,
                            NumOfHelpers = e.NumOfHelpers,
                            SuppliesNeeded = e.SuppliesNeeded,
                            Location = e.Location,
                            IsFullService = e.IsFullService,
                            DateOfEvent = e.DateOfEvent.Date,
                            CostOfEvent = e.CostOfEvent,
                        }
                     );
                return query.ToArray();
            }
        }

        public EventDetail GetEventById(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx 
                     .Events
                     .Single(e => e.EventId == eventId && e.OwnerId ==_userId);
                return
                    new Models.EventDetail
                    {
                        EventId = entity.EventId,
                        CustomerId = entity.CustomerId,
                        FoodId = entity.FoodId,
                        PrepArea = entity.PrepArea,
                        NumOfGuest = entity.NumOfGuest,
                        NumOfHelpers = entity.NumOfHelpers,
                        SuppliesNeeded = entity.SuppliesNeeded,
                        Location = entity.Location,
                        IsFullService = entity.IsFullService,
                        DateOfEvent = entity.DateOfEvent.Date,
                        CostOfEvent = entity.CostOfEvent,

                    };
            }
        }
        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.CustomerId = model.CustomerId;
                entity.FoodId = model.FoodId;
                entity.PrepArea = model.PrepArea;
                entity.NumOfGuest = model.NumOfGuest;
                entity.NumOfHelpers = model.NumOfHelpers;
                entity.SuppliesNeeded = model.SuppliesNeeded;
                entity.Location = model.Location;
                entity.IsFullService = model.IsFullService;
                entity.DateOfEvent = model.DateOfEvent;
                entity.CostOfEvent = model.CostOfEvent;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == eventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
