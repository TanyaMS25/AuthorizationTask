using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Razor;
using AuthorizationTask.Entities.Entities;

namespace AuthorizationTask.Pages
{
    public class AuthorizationModel
    {
        public User User { get; set; }
        

        public string Login { get; set; } = "";

        public void OnGet()
        {
        }
        
    }
}
