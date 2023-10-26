using AuthorizationTask.Data;
using AuthorizationTask.Entities.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;

namespace AuthorizationTask.Pages
{
    public class RegistrationModel : PageModel
    {
        private readonly SqlServerDbContext _dbContext;

        [BindProperty]
        public User NewUser { get; set; }

        public string regErrorMessage = "";

        //private readonly RandomNumberGenerator _rng;

        //private PasswordHasherCompatibilityMode _compatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;

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
