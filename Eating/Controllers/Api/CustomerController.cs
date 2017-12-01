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
            
            if (query.VerifyCode != 0)
                return BadRequest($"尚未通過驗證,{query.C_Id}");
           
            return Ok(query);
        }

        [HttpPost]
        public IHttpActionResult Verify(CustomerVerifyDTO customerVerify)
        {
            if (!ModelState.IsValid)
                return BadRequest("請輸入驗證碼");

            if (customerService.Verify(customerVerify.C_Id, customerVerify.VerifyCode))
                return Ok(customerService.GetCustomer(customerVerify.C_Id));
            else
                return BadRequest("驗證碼錯誤! 請重新確認");
        }

        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Register(CustomerRegisterDTO customerRegisterDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("請檢查欄位是否有遺漏");
            if (customerService.AccountIsduplicate(customerRegisterDTO.C_Account))
                return BadRequest("帳號已被註冊！");
            if (customerService.PhoneNumIsDuplicate(customerRegisterDTO.C_PhoneNum))
                return BadRequest("手機號碼已經使用過囉");
           
            var customer = Mapper.Map<CustomerRegisterDTO, Customer>(customerRegisterDTO);
            var result = customerService.Register(ref customer);

            if (result.Success == false)
                return BadRequest("Error 資料有誤");

            return Created(new Uri(Request.RequestUri + "/" + customer.C_Id), customer);

        }

    }
}