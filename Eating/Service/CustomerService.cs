using Eating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eating.Interface;
using Eating.Repository;
using Eating.DTOs;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;

namespace Eating.Service
{
    public class CustomerService
    {
        IRepository<Customer> repository = new GenericRepository<Customer>(new ApplicationDbContext());
        ApplicationDbContext db = new ApplicationDbContext();
        public bool PasswordCheck(Customer _restaurant, string _password)
        {
            bool result = (_restaurant.C_Password.Equals(HashPassword(_password))|| 
                _restaurant.C_Password==_password);

            return result;
        }


        public string HashPassword(string password)
        {
            string saltKey = "SDajg83Q2hrgsd9GFjdeSflm3gh5H";
            string saltAndPassword = string.Concat(password, saltKey);
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] PasswordData = Encoding.Default.GetBytes(saltAndPassword);
            byte[] HashData = sha1Hasher.ComputeHash(PasswordData);
            string HashResult = "";

            for (int i = 0; i < HashData.Length; i++)
            {
                HashResult += HashData[i].ToString("x2");
            }

            return HashResult;
        }
        public bool AccountIsduplicate(string account)
        {
           var q = db.Customers.Where(a => a.C_Account == account).SingleOrDefault();
            return (q != null ? true : false);
        }
  
        public CustomerRegisterDTO login(CustomerLoginDTO loginDTO)
        {
            var query = db.Customers.Where(a => a.C_Account == loginDTO.C_Account).SingleOrDefault();
            if (query != null)
            {
                if (PasswordCheck(query, loginDTO.C_Password))
                {
                    return Mapper.Map<Customer,CustomerRegisterDTO>(query);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public IResult register(ref Customer instance)
        {
            instance.SignUpTime = DateTime.Now;
            instance.C_Password = HashPassword(instance.C_Password);

            IResult result = new Result(false);
            try
            {
                repository.Create(instance);
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Exception = e;
            }
           
            return result;
        } 
    }
}