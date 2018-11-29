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
    class EventService
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
    }
}
