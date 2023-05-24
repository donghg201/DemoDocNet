using Demo.Controllers;
using Demo.Dto;
using Demo.Models;
using Demo.Repositories;
using Demo.Repositories.IRepositories;
using Demo.Services;
using Demo.Uow;
using Demo.Uow.IUow;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoUnitTest
{
    [TestClass]
    public class CustomerTest
    {
        //CustomerController customerController;
        //CustomerService customerService; 
        //ICustomerUow customerUow;
        //MyDbContext dbContext;

        //[TestInitialize]
        //public void Initialize() 
        //{
        //    dbContext = new MyDbContext();
        //    customerUow = new CustomerUow(dbContext);
        //    customerService = new CustomerService(customerUow);
        //    customerController = new CustomerController(customerService);
        //}

        //CustomerDto customerDto = new CustomerDto()
        //{
        //    Address = "02 Quang Trung",
        //    City = "Đà Nẵng",
        //    CustTypeCd = "Individual",
        //    FedId = "245225",
        //    PostalCode = "550000",
        //    State = "Vietnam",
        //    StateId = null,
        //    IncorpDate = null,
        //    Name = null,
        //    FirstName = "Võ",
        //    LastName = "Đông",
        //    BirthDate = new DateTime(2001, 10, 22, 00, 00, 00),
        //};

        //CustomerDto customerAdd = new CustomerDto()
        //{
        //    Address = "02 Quang Trung",
        //    City = "Đà Nẵng",
        //    CustTypeCd = "I",
        //    FedId = "245225",
        //    PostalCode = "550000",
        //    State = "Vietnam",
        //    StateId = null,
        //    IncorpDate = null,
        //    Name = null,
        //    FirstName = "Võ",
        //    LastName = "Đông",
        //    BirthDate = new DateTime(2001, 10, 22, 00, 00, 00),
        //};

        //CustomerDto customerNotCustTypeCd = new CustomerDto()
        //{
        //    Address = "02 Quang Trung",
        //    City = "Đà Nẵng",
        //    CustTypeCd = null,
        //    FedId = "245225",
        //    PostalCode = "550000",
        //    State = "Vietnam",
        //    StateId = null,
        //    IncorpDate = null,
        //    Name = null,
        //    FirstName = "Võ",
        //    LastName = "Đông",
        //    BirthDate = new DateTime(2001, 10, 22, 00, 00, 00),
        //};

        ////CustomerDto customerNotCustTypeCd = new CustomerDto()
        ////{
        ////    Address = "02 Quang Trung",
        ////    City = "Đà Nẵng",
        ////    CustTypeCd = "I",
        ////    FedId = "245225",
        ////    PostalCode = "550000",
        ////    State = "Vietnam",
        ////    StateId = null,
        ////    IncorpDate = null,
        ////    Name = null,
        ////    FirstName = "Võ",
        ////    LastName = "Đông",
        ////    BirthDate = new DateTime(2001, 10, 22, 00, 00, 00),
        ////};

        //[TestMethod]
        //public void Customer_Controller_GetAll_Successful()
        //{
        //    var listCustomer = customerController.GetAll();

        //    Assert.IsNotNull(listCustomer);
        //}

        //[TestMethod]
        //public void Customer_Controller_GetById_Successful()
        //{
        //    var id = 1;
        //    var customer = customerController.GetCustomer(id);

        //    Assert.IsNotNull(customer);
        //}

        //[TestMethod]
        //public void Customer_Controller_GetById_IdNull()
        //{
        //    var id = 0;
        //    var customer = customerController.GetCustomer(id);

        //    Assert.AreNotEqual(customer, customerDto);
        //}

        //[TestMethod]
        //public void Customer_Controller_Add_Successful()
        //{
        //    var listBefore = customerController.GetAll();

        //    var customer = customerController.Add(customerAdd);

        //    var listAfter = customerController.GetAll();

        //    Assert.AreNotEqual(listBefore, listAfter);
        //}

        //[TestMethod]
        //public void Customer_Controller_GetInfoCustomer_Successful()
        //{
        //    string name = "Đông";
        //    var customer = customerController.GetInfoCustomer(name);

        //    Assert.IsNotNull (customer);
        //}
        //--------------------------------------
        //[TestMethod]
        //public void Customer_Controller_GetInfoCustomer_NotFound()
        //{
        //    string name = "Tùng";
        //    var customer = customerController.GetInfoCustomer(name);

        //    Assert.IsInstanceOfType<NotFoundObjectResult>(customer, typeof(Customer));
        //}

        //[TestMethod]
        //public void Customer_Controller_Add_NotFoundCustTypeId()
        //{
        //    var customer = customerController.Add(customerNotCustTypeCd);

        //    Assert.AreNotEqual(customer, customerNotCustTypeCd);
        //}

        //[TestMethod]
        //public void Customer_Repository_GetAllTest_EqualNumber()
        //{
        //    var list = customerRepository.FetchAll().ToList();

        //    Assert.AreEqual(9, list.Count);
        //}

        //[TestMethod]
        //public void Customer_Repository_GetAllTest_NotNull()
        //{
        //    var list = customerRepository.FetchAll().ToList();

        //    Assert.IsNotNull(list);
        //}

        //[TestMethod]
        //public void Customer_Repository_GetByIdTest_NotNull()
        //{
        //    var id = 1;

        //    var customer = customerRepository.FindById(id);

        //    Assert.IsNotNull(customer);
        //}

        //[TestMethod]
        //public void Customer_Repository_GetByIdTest_NotFound()
        //{
        //    var id = 100;

        //    var customer = customerRepository.FindById(id);

        //    Assert.IsNull(customer);
        //}


        //[TestMethod]
        //public void Customer_Repository_CreateCustomerTest_Successful()
        //{
        //    var beforeList = customerRepository.FetchAll().ToList();
        //    Customer customer = new Customer()
        //    {
        //        Address = "02 Quang Trung",
        //        City = "Đà Nẵng",
        //        CustTypeCd = "I",
        //        FedId = "245225",
        //        PostalCode = "550000",
        //        State = "Vietnam",
        //    };
        //    var result = customerRepository.Add(customer);
        //    uow.SaveChanges();

        //    var afterlist = customerRepository.FetchAll().ToList();

        //    Assert.AreEqual(beforeList.Count + 1, afterlist.Count);
        //}

        //[TestMethod]
        //public void Customer_Repository_CreateCustomerTest_NotNull()
        //{
        //    Customer customer = new Customer()
        //    {
        //        Address = "02 Quang Trung",
        //        City = "Đà Nẵng",
        //        CustTypeCd = "I",
        //        FedId = "245225",
        //        PostalCode = "550000",
        //        State = "Vietnam",
        //    };
        //    var result = customerRepository.Add(customer);
        //    uow.SaveChanges();

        //    Assert.IsNotNull(result);
        //}

        //[TestMethod]
        //public void Customer_Repository_CreateCustomerTest_NullCustTypeId()
        //{
        //    var beforeList = customerRepository.FetchAll().ToList();
        //    Customer customer = new Customer()
        //    {
        //        Address = "02 Quang Trung",
        //        City = "Đà Nẵng",
        //        CustTypeCd = null,
        //        FedId = "245225",
        //        PostalCode = "550000",
        //        State = "Vietnam",
        //    };
        //    var result = customerRepository.Add(customer);
        //    uow.SaveChanges();

        //    var afterlist = customerRepository.FetchAll().ToList();
        //    Assert.AreNotEqual(beforeList.Count + 1, afterlist.Count);
        //}
    }
}
