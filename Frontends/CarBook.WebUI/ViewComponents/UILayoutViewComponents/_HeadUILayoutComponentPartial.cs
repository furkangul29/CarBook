using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        //Wiev component lere url lerden ulasım saglanamaz bu yüzden daha güvenlidir.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
