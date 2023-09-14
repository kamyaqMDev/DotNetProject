using Microsoft.AspNetCore.Mvc;

namespace UserMailingList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserMailingListController : ControllerBase
    {
        private static List<UserMailing> userMailings = new List<UserMailing>();

        [HttpPost]
        public IActionResult AddUser(UserMailing userMailing)
        {
            userMailings.Add(userMailing);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<UserMailing> GetUserMailingList(string LastName , bool? ascending)
        {
          var result = userMailings.AsQueryable();

          if (!string.IsNullOrEmpty(LastName))
          {
            result = result.Where(entry => entry.LastName == LastName);
          }

          result = ascending == false
              ? result.OrderByDescending(entry => entry.LastName).ThenByDescending(entry => entry.FirstName)
              : result.OrderBy(entry => entry.LastName).ThenBy(entry => entry.FirstName);

          return result.ToList();
    }
    }

}
