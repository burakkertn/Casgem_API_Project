using Microsoft.AspNetCore.Mvc;

namespace Casgem_API_Project.ViewComponents.Default
{
    public class _SectionPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
