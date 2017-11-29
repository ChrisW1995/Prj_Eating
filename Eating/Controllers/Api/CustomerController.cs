using AutoMapper;
using Eating.DTOs;
using Eating.Models;
using Eating.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Eating
{
    
    public class CustomerController : ApiController
    {
        CustomerService customerService = new CustomerService();
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<string> Get(int id)
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        // GET api/<controller>/
        public IHttpActionResult Login(CustomerLoginDTO customerLogin)
        {
            var query = customerService.Login(customerLogin);
            if(query == null)
            {
                return NotFound();
            }
            return Ok(query);
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Register(CustomerRegisterDTO customerRegisterDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("請檢查欄位是否有遺漏");
            if (customerService.AccountIsduplicate(customerRegisterDTO.C_Account))
                return BadRequest("帳號已被註冊！");
           
            var customer = Mapper.Map<CustomerRegisterDTO, Customer>(customerRegisterDTO);
            var result = customerService.Register(ref customer);

            if (result.Success == false)
                return BadRequest("Error 資料有誤");

            return Created(new Uri(Request.RequestUri + "/" + customer.C_Id), customerRegisterDTO);

        }

    }
}