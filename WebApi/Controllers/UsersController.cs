using Microsoft.AspNetCore.Mvc;
//fix: Removed "using System.Runtime.Intrinsics.Arm;" - it was added by mistake and is not used
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        static readonly string FilePath = "Users.txt";
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Riki", "Efrat" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return user;
                }
            }
            return NotFound();
            
        }
        
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
      
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get),new {Id = user.Id },user);
        }


        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("login")]
        public ActionResult<User> Login([FromBody] LogUser loginUser)
        {
            
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Email == loginUser.Email && user.Password ==
                    loginUser.Password)
                        return Ok(user);
                }
            }
            
            return NotFound();
        }



        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id,[FromBody] User userPut)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                //fix: Keep the id, otherwise the updated user is saved without it
                userPut.Id = id;
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userPut));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
