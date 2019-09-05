using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NetCoreIstio.Services.Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        List<User> _UserList; 

        public UserController(IConfiguration configuration )
        {
            _configuration = configuration;
            _UserList = LoadUsers();
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {

            var serviceVersion = _configuration.GetValue<string>("SERVICE_VERSION");
            if (serviceVersion == "v1")
            {
                return _UserList.Select(x => new User { Id = x.Id, Name = x.Name }).ToList();
            }
            else
            {
                return _UserList.Select(x => new User { Id = x.Id, Name = x.Name, Description=x.Description.ToString() + $" - Data from Version {serviceVersion}"  }).ToList();
            }
           
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return new User
            {
                Id = 1,
                Description = "coming forem V1 - Single Get id",
                Name = "Ravi"
            };
        }

        
        public List<User> LoadUsers()
        {
            List<User> Users = new List<User>
            {
                new User
                {
                   Id=1, 
                   Name="Test User 01", 
                   Description="Sample User 01"
                },
                new User
                {
                   Id=2,
                   Name="Test User 02",
                   Description="Sample User 02"
                },
                new User
                {
                   Id=3,
                   Name="Test User 03",
                   Description="Sample User 03"
                },
                new User
                {
                   Id=4,
                   Name="Test User 04",
                   Description="Sample User 04"
                }
            };
            return Users;
    }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
