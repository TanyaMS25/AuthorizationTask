using AuthorizationTask.Data;
using AuthorizationTask.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthorizationTask.Pages
{
    public class AuthorizationModel : PageModel
    {
        private readonly SqlServerDbContext _dbContext;

        public User? AuthUser { get; set; } = new User();

        [BindProperty]
        public User CheckUser { get; set; }

        public string authErrorMessage = "";

        public AuthorizationModel(SqlServerDbContext dbContext)
        {
            if(dbContext != null)
            {
                _dbContext = dbContext;
            }
        }

        public void OnGet()
        {
            
        }

        public IActionResult? OnPost()
        {
            AuthUser = _dbContext.Users.FirstOrDefault(p => (p.Login == CheckUser.Login) & (p.Password == CheckUser.Password));

            if (AuthUser == null)
            {
                authErrorMessage = "Авторизация не удалась, проверьте введенные значения.";
                return null;
            }
            else
            {
                return RedirectToPage("UserPersonalAccount", new { id = AuthUser.Id });
            }
        }
    }
}
