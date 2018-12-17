using CateringCoordinator.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CateringCoordinator.Contracts
{
     public interface IEvent
    {
        bool CreateEvent(EventCreate model);
        IEnumerable<EventList> GetEvents();
        EventDetail GetEventById(int eventId);
        bool UpdateEvent(EventEdit model);
        bool DeleteEvent(int Id);
    }
}
