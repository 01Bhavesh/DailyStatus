﻿using CRUDoperation.IServiceImplementation;
using CRUDoperation.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDoperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _service;
        public ProductController(IProduct service)
        {
            _service = service;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult> GetAllProduct() 
        {
            var products = _service.GetAllProduct();
            return Ok(products);
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult> GetProductById(int id) 
        {
            var product = _service.GetProductById(id);
            return Ok(product);
        }
        [Route("Create")]
        [HttpPost]
        public async Task<ActionResult> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool flag = await _service.CreateProduct(product);
            if (!flag)
            {
                return BadRequest();   
            }
            return Ok();
        }
        [Route("Update")]
        [HttpPost]
        public async Task<ActionResult> EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool flag = await _service.UpdateProduct(product);
            if (!flag)
            {
                return BadRequest();
            }
            return Ok();
        }
        [Route("Delete")]
        [HttpGet]
        public async Task<ActionResult> DeleteProduct(int Id)
        {
            bool flag = await _service.DeleteProduct(Id);
            if (!flag)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}
