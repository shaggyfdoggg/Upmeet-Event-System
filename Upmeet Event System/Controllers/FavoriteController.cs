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
        public List<Favorite> GetFavorite()
        {
            return _dbContext.Favorites.ToList();
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
        [HttpGet("{UserName}")]
        public List<Favorite> GetByUserName(string userName)
        {
            return _dbContext.Favorites.Where(c=>c.Username==userName).ToList();
        }
        [HttpGet("{UserName}")]
        public List<Favorite> GetEventByUserName(string userName, Favorite x)
        {
            List<Favorite> user= _dbContext.Favorites.Where(c => c.Username == userName).ToList();
            List<int> eventNumber = user.Select(x => x.EventId-0).ToList();
                //List<int> applePeces = apples.Select(x => x * 2).ToList();
            return;
        }
    }
}
