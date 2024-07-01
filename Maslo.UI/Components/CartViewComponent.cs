using Microsoft.AspNetCore.Mvc;

namespace Maslo.UI.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }
    }
}
