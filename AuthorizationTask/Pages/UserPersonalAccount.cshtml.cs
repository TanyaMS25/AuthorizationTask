using AuthorizationTask.Data;
using AuthorizationTask.Entities.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationTask.Pages
{
    public class UserPersonalAccountModel : PageModel
    {
        private readonly SqlServerDbContext _dbContext;

        public int? UserId { get; private set; }

        public User? User { get; set; } = new();

        public string errorMessage = "";

        public UserPersonalAccountModel(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(int id)
        {
            if (id > 0)
            {
                UserId = id;
                User = _dbContext.Users.FirstOrDefault(p => p.Id == UserId);

                if (User != null)
                {
                    if (User.Name == null)
                    {
                        User.Name = "NoName";
                    }
                }
            }
        }
    }
}
