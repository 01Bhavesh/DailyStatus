using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Model.DTO;
using System;
using System.Threading.Tasks;

namespace New_CRUDTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public UserController(IUserService userService, IOrderService orderService, IProductService productService)
        {
            _userService = userService;
            _orderService = orderService;
            _productService = productService;
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateUser(User user)
        {
            _userService.AddUser(user);
            return Ok(new { message = "User is added successfully." });
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllUser(int page = 1, int pagesize = 10)
        {
            var (lst, totalcount) = await _userService.GetUser(page, pagesize);
            return Ok(new { lst, totalcount });
        }

        [Route("update")]
        [HttpPost]
        public ActionResult UpdateUser(User user)
        {
            _userService.UpdateUser(user);
            return Ok("Updated successfully..");
        }

        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok("Deleted successfully..");
        }

        [Route("products")]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts(int page = 1, int pageSize = 10)
        {
            var (products, totalCount) = await _productService.GetProducts(page, pageSize);
            return Ok(new { products, totalCount });
        }

        [Route("placeOrder")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder(OrderCreatedDTO orderDto)
        {
            _orderService.CreateOrder(orderDto);
            return Ok(new { message = "Order placed successfully." });
        }

        [Route("getuserorder")]
        [HttpGet]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await _orderService.GetOrdersByUserId(userId);
            if (orders == null)
            {
                return NotFound(new { message = "No orders found for this user." });
            }
            return Ok(orders);
        }

        [Route("error")]
        [HttpPost]
        public IActionResult Error()
        {
            int b = 10;
            int c = 0;
            int a = b / c; // This will throw an exception handled by middleware
            return Ok("Operation successful");
        }
    }
}