using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using Upmeet_Event_System.Models;

namespace Upmeet_Event_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        EventDbContext _dbContext = new EventDbContext();
        [HttpGet]
        public List<Event> GetAll()
        {       
            return _dbContext.Events.ToList();

        }
        [HttpGet("{id}")]
        public Event GetEventById(int id)
        {
            return _dbContext.Events.Find(id);
        }
        [HttpPost]
        public Event AddEvent([FromBody] Event newEvent)
        {
            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();
            return newEvent;
        }

        [HttpDelete("{id}")]
        public Event DeleteEvent(int id)
        {
            Event deleted = _dbContext.Events.Find(id);
            _dbContext.Events.Remove(deleted);
            _dbContext.SaveChanges();

            return deleted;
        }
        [HttpPut]
        public Event ReplaceMeal(int id, [FromBody] Event newEvent)
        {
            Event e = _dbContext.Events.FirstOrDefault(e => e.Id == id);
            e.Id = id;
            e.Name = newEvent.Name;
            e.Description = newEvent.Description;
            e.DateTime = newEvent.DateTime;
            e.Location = newEvent.Location;
            e.Attending = newEvent.Attending;

            _dbContext.Events.Update(e);
            _dbContext.SaveChanges();
            return e;
        }


    }
}
