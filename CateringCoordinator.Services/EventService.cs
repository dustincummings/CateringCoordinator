using CateringCoodinator.Data;
using CateringCoordinator.Data;
using CateringCoordinator.Models;
using CateringCoordinator.Models.EventModels;
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
                    NumOfGuest = model.NumOfGuest,
                    Location = model.Location,
                    DateOfEvent = model.DateOfEvent,
                    CustomerId = model.CustomerId,
                    FoodId = model.FoodId,
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
                            FoodName = e.Food.Name,
                            FoodId = e.FoodId,
                            CustomerId =e.CustomerId,
                            NumOfGuest = e.NumOfGuest,
                            Location = e.Location,
                            DateOfEvent = e.DateOfEvent,
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
                     .Single(e => e.EventId == eventId && e.OwnerId == _userId);

                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        FoodName = entity.Food.Name,
                        FullName = entity.Customer.FullName,
                        NumOfGuest = entity.NumOfGuest,
                        Location = entity.Location,
                        DateOfEvent = entity.DateOfEvent,
                        FoodId = entity.Food.FoodId,
                        CustomerId=entity.Customer.CustomerId,
                        Customer=entity.Customer,
                        Food=entity.Food,

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

                entity.CustomerId  = model.CustomerId;
                entity.FoodId = model.FoodId;
                entity.NumOfGuest = model.NumOfGuest;
                entity.Location = model.Location;
                entity.DateOfEvent = model.DateOfEvent;

                return ctx.SaveChanges() == 1;

            }
        }
        public bool DeleteEvent(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == Id && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
