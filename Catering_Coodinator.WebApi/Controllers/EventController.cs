using CateringCoordinator.Models.EventModels;
using CateringCoodinator.Data;
using CateringCoordinator.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Catering_Coodinator.WebApi.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            EventService eventService = CreateEventService();
            var events = eventService.GetEvents();
            return Ok(events);
        }

        public IHttpActionResult Get(int id)
        {
            EventService eventService = CreateEventService();
            var @event = eventService.GetEventById(id);
            return Ok(@event);
        }

        public IHttpActionResult Post(EventCreate @event)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEventService();
            if (!service.CreateEvent(@event))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(EventEdit @event)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEventService();
            if (!service.UpdateEvent(@event))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEventService();
            if (!service.DeleteEvent(id))
                return InternalServerError();
            return Ok();
        }
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var eventService = new EventService(userId);
            return eventService;
        }
    }
}