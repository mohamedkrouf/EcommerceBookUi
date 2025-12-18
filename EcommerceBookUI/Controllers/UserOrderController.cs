using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBookUI.Controllers
{
    [Authorize]// Ensures that only authenticated users can access the actions in this controller
    public class UserOrderController : Controller
    {
        private readonly IUserOrderRepository _userOrderRepo;

        public UserOrderController(IUserOrderRepository userOrderRepo)
        {
            _userOrderRepo = userOrderRepo;
        }
        public async Task<IActionResult> UserOrders() // we are going to call it from areas/idend/pages/accounts/manage/managenav.cshtml to show the orders of the logged-in user
        {
            var orders = await _userOrderRepo.UserOrders();
            return View(orders);
        }//<!-- creates the order link in the modify profile part-->
    }
}
