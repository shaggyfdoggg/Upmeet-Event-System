using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upmeet_Event_System.Models;

namespace Upmeet_Event_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        EventDbContext _dbContext = new EventDbContext();
        [HttpGet]
        public List<Favorite> GetUsers()
        {
            return _dbContext.Favorites.ToList();
        }
        [HttpGet("UserNames")]
        public List<Favorite> GetUserNames()
        {
            return _dbContext.Favorites.GroupBy(x => x.Username).Select(x => x.First()).ToList();
        }
        [HttpPost]
        public Favorite AddFavorite([FromBody] Favorite newFavorite)
        {
            _dbContext.Favorites.Add(newFavorite);
            _dbContext.SaveChanges();
            return newFavorite;
        }
        [HttpDelete("{id}")]
        public Favorite DeleteFavorite(int id)
        {
            Favorite deleted = _dbContext.Favorites.Find(id);
            _dbContext.Favorites.Remove(deleted);
            _dbContext.SaveChanges();

            return deleted;
        }
        //[HttpGet("{UserName}")]
        //public List<Favorite> GetByUserName(string userName)
        //{
        //    return _dbContext.Favorites.Where(c=>c.Username==userName).ToList();
        //}
        [HttpGet("{UserName}")]
        public List<Event> GetEventByUserName(string userName)
        {
            List<Event> favoriteEvents = new List<Event>();
            List<Favorite> user= _dbContext.Favorites.Where(c => c.Username == userName).ToList();
            List<int> eventNumber = user.Select(x => (int)x.EventId).ToList();
                foreach(int i in eventNumber)
            {
                Event e = _dbContext.Events.FirstOrDefault(y => y.Id == i);
                favoriteEvents.Add(e);
            }
            return favoriteEvents;
        }
    }
}
