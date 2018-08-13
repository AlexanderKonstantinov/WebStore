using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Domain.Dto.Order;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Models.Cart;
using WebStore.Domain.Models.Order;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;


namespace WebStore.Tests
{
    [TestClass]
    public class CartControllerTests
    {
        private IMapper _mapper;

        private CartController _controller;

        Mock<ICartService> _mockCartService;
        Mock<IOrdersData> _mockOrdersService;

        [TestInitialize]
        public void SetupTest()
        {
            _mockCartService = new Mock<ICartService>();
            _mockOrdersService = new Mock<IOrdersData>();

            _mapper = new Mapper(new MapperConfiguration(cfg =>
                cfg.CreateMap<ProductDto, ProductViewModel>()
                    .ForMember(nameof(ProductViewModel.Brand),
                        opt => opt.MapFrom(p => p.Brand != null
                            ? p.Brand.Name
                            : String.Empty))));

            _controller = new CartController(_mockCartService.Object,
                _mockOrdersService.Object, _mapper);
        }

        [TestMethod]
        public void Checkout_ModelState_Invalid_Returns_ViewModel()
        {
            _controller.ModelState.AddModelError("error", "InvalidModel");
            var result = _controller.Checkout(new OrderViewModel()
            {
                Name = "test"
            });
            var viewResult = Assert.IsType<ViewResult>(result);
            var model =
                Assert.IsAssignableFrom<DetailsViewModel>(viewResult.ViewData.Model);
            Assert.Equal("test", model.OrderViewModel.Name);
        }

        //[TestMethod]
        //public void Checkout_Calls_Service_And_Return_Redirect()
        //{
        //    #region Arrange
        //    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, "1"),
        //    }));

        //    // setting up cartService
        //    var mockCartService = new Mock<ICartService>();
        //    mockCartService.Setup(c => c.TransformCart()).Returns(new
        //        CartViewModel()
        //        {
        //            Items = new Dictionary<ProductViewModel, int>()
        //            {
        //                { new ProductViewModel(), 1 }
        //            }
        //        });

        //    // setting up ordersService
        //    var mockOrdersService = new Mock<IOrdersData>();
        //    mockOrdersService.Setup(c =>
        //            c.CreateOrder(It.IsAny<CreateOrderModel>(), It.IsAny<string>()))
        //        .Returns(new OrderDto() { Id = 1 });

        //    _controller.ControllerContext = new ControllerContext
        //    {
        //        HttpContext = new DefaultHttpContext
        //        {
        //            User = user
        //        }
        //    };
        //    #endregion
            
        //    // Act
        //    var result = _controller.Checkout(new OrderViewModel()
        //    {
        //        Name = "test",
        //        Address = "",
        //        Phone = ""
        //    });

        //    // Assert
        //    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Null(redirectResult.ControllerName);
        //    Assert.Equal("OrderConfirmed", redirectResult.ActionName);
        //    Assert.Equal(1, redirectResult.RouteValues["id"]);
        //}
    }
}
