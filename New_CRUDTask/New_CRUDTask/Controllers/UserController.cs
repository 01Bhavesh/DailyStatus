using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using New_CRUDTask.ExceptionHandling;
using New_CRUDTask.IServiceImplementation;
using New_CRUDTask.Model;
using New_CRUDTask.Model.DTO;
using New_CRUDTask.ServiceImplementation;
using System;

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
            try { 
                    _userService.AddUser(user);
                    return Ok(new { message = "User is added successfully." });
                }
            catch (TaskException ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Unexpected error...", error = ex.Message });
                };
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
            try
            {
                _userService.UpdateUser(user);
                return Ok("Updated successfully..");
            }
            catch (TaskException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Unexpected error...", error = ex.Message });
            };
        }
        [Route("delete")]
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            try {
                    _userService.DeleteUser(id);
                    return Ok("Deleted successfully..");
                }
            catch (TaskException ex)
                {
                    return BadRequest(new { message = ex.Message});
                }
            catch (Exception ex)
                {
                    return StatusCode(500, new { message = "Unexpected error...", error = ex.Message });
                };
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
            try
            {
                _orderService.CreateOrder(orderDto);
                return Ok(new { message = "Order placed successfully." });
            }
            catch (TaskException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Unexpected error...", error = ex.Message });
            };
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
            try
            {
                int b = 10;
                int c = 0;
                int a = b / c;
            }
            catch (Exception ex)
            {
                var taskException = new TaskException("An error occurred..", ex);
                return BadRequest(new
                {
                    Message = taskException.Message?? "An unknown error occurred.",
                    InnerException = taskException.InnerException?.Message
                });
            }
            return Ok("Operation successful");
        }

    }
}
