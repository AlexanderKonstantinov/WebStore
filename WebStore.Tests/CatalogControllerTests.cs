﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Domain.Dto.Product;
using WebStore.Domain.Filters;
using WebStore.Domain.Models.Product;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;

namespace WebStore.Tests
{
    [TestClass]
    public class CatalogControllerTests
    {
        private IMapper _mapper;

        private CatalogController _controller;

        private Mock<IProductData> _productMock;

        [TestInitialize]
        public void SetupTest()
        {
            _productMock = new Mock<IProductData>();

            _mapper = new Mapper(new MapperConfiguration(cfg =>
                cfg.CreateMap<ProductDto, ProductViewModel>()
                    .ForMember(nameof(ProductViewModel.Brand),
                        opt => opt.MapFrom(p => p.Brand != null
                            ? p.Brand.Name
                            : String.Empty))));

            _controller = new CatalogController(_productMock.Object, _mapper);
        }

        [TestMethod]
        public void ProductDetails_Returns_View_With_Correct_Item()
        {
            // Arrange
            _productMock.Setup(p =>
                p.GetProductById(It.IsAny<int>())).Returns(new ProductDto()
            {
                Id = 1,
                Name = "Test",
                ImageUrl = "TestImage.jpg",
                Condition = "new",
                Order = 0,
                Price = 10,
                Brand = new BrandDto()
                {
                    Id = 1,
                    Name = "TestBrand"
                }
            });

            // Act
            var result = _controller.ProductDetails(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(1, model.Id);
            Assert.Equal("Test", model.Name);
            Assert.Equal(10, model.Price);
            Assert.Equal("TestBrand", model.Brand);
            Assert.Equal("new", model.Condition);
        }

        [TestMethod]
        public void ProductDetails_Returns_NotFound()
        {
            // Arrange
            _productMock.Setup(p =>
                p.GetProductById(It.IsAny<int>())).Returns((ProductDto)null);

            // Act
            var result = _controller.ProductDetails(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [TestMethod]
        public void Shop_Method_Returns_Correct_View()
        {
            // Arrange
            _productMock.Setup(p =>
                p.GetProducts(It.IsAny<ProductFilter>())).Returns(new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Test",
                    ImageUrl = "TestImage.jpg",
                    Order = 0,
                    Price = 10,
                    Condition = "new",
                    Brand = new BrandDto()
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Test2",
                    ImageUrl = "TestImage2.jpg",
                    Order = 1,
                    Price = 22,
                    Condition = "new",
                    Brand = new BrandDto()
                    {
                        Id = 1,
                        Name = "TestBrand"
                    }
                }
            });

            // Act
            var result = _controller.Shop(1, 5);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Products.Count());
            Assert.Equal(5, model.BrandId);
            Assert.Equal(1, model.SectionId);
            Assert.Equal("TestImage2.jpg",
                model.Products.ToList()[1].ImageUrl);
        }

    }
}
