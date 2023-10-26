using AuthorizationTask.Data;
using AuthorizationTask.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

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
            if (NewUser.Login.Length > 0 & NewUser.Password.Length > 0)
            {
                _dbContext.Users.Add(NewUser);
                _dbContext.SaveChanges();

                return RedirectToPage("UserPersonalAccount");
                
            }
            else
            {
                regErrorMessage = "Регистрация не удалась, проверьте введенные значения.";
                return null;
            }
        }
    }
}
