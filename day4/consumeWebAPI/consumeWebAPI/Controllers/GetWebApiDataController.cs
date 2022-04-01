using Microsoft.AspNetCore.Mvc;
using consumeWebAPI.Models;
namespace consumeWebAPI.Controllers
{
    public class GetWebApiDataController : Controller
    {
        public IActionResult PostData()
        {
            return View();
        }
        CommentsModel CommentsModel = new CommentsModel();
        public IActionResult CommentsData()
        {
            ViewBag.comments = CommentsModel.GetCommentslist();
            return View();
        }
    }
}
