using AuthorizationTask.Data;
using AuthorizationTask.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationTask.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly SqlServerDbContext _dbContext;

        [BindProperty]
        public User NewUser { get; set; }

        public string regErrorMessage = "";

        public RegistrationModel(SqlServerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void OnGet()
        {
            
        }

        public IActionResult? OnPost()
        {
            if (NewUser.Login != null & NewUser.Password != null)
            {
                string hashPassword = Identity.PasswordHasher.HashPasswordV3(NewUser.Password);

                NewUser.Password = hashPassword;

                _dbContext.Users.Add(NewUser);
                _dbContext.SaveChanges();

                return RedirectToPage("UserPersonalAccount", new { id = NewUser.Id });
            }
            else
            {
                regErrorMessage = "Регистрация не удалась, проверьте введенные значения.";
                return null;
            }
        }
    }
}
