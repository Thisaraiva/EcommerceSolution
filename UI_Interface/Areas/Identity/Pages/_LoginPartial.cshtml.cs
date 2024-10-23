using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace UI_Interface.Areas.Identity.Pages
{
    public class _LoginPartialModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public _LoginPartialModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public ApplicationUser CurrentUser { get; set; }
        public bool IsSignedIn { get; set; }

        public async Task OnGetAsync()
        {
            IsSignedIn = _signInManager.IsSignedIn(User);
            if (IsSignedIn)
            {
                CurrentUser = await _userManager.GetUserAsync(User);
            }
        }
    }
}
