using System.Net;
using AutoFixture;
using FluentAssertions;
using MicroService.Catalog.API.Controllers;
using MicroService.Catalog.API.Data;
using MicroService.Catalog.API.Entities;
using MicroService.Catalog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MicroService.Catalog.API.Tests;

public class CatalogControllerTest
{
    private CatalogController _controller;
    private static readonly Task<IEnumerable<Product>> Products = GetProducts();

    [Fact]
    public async void GetProducts_WithValidRequest_ShouldGetAllProducts()
    {
        //arrange
        var repoMoq = new Mock<IProductRepository>();
        repoMoq.Setup(x => x.GetProducts()).Returns(Products);
        var repository = repoMoq.Object;
        _controller = new CatalogController(repository);
        var expectedResult = Products.Result;
        
        //act
        var products = await _controller.GetProducts();
        var okResult = products as OkObjectResult;
        var actualProducts = okResult.Value as IEnumerable<Product>;
        
        //assert
        products.Should().BeOfType<OkObjectResult>();
        okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        actualProducts.Should().BeSameAs(expectedResult);
    }
    
    [Fact]
    public async void GetProduct_WithInvalidId_ShouldReturnNotFoundCode()
    {
        //arrange
        var repoMoq = new Mock<IProductRepository>();
        repoMoq.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(GetProduct(string.Empty));
        var repository = repoMoq.Object;
        _controller = new CatalogController(repository);
        var expectedResult = HttpStatusCode.NotFound;
        
        //act
        var product = await _controller.GetProduct("TestId");
        
        //assert
        product.Should().BeOfType<NotFoundResult>();
        product.Should().NotBeOfType<OkObjectResult>();
    }
    [Fact]
    public async void GetProduct_WithValidId_ShouldReturnProduct()
    {
        //arrange
        var repoMoq = new Mock<IProductRepository>();
        repoMoq.Setup(x => x.GetProduct(It.IsAny<string>())).Returns(GetProduct("MyTestId"));
        var repository = repoMoq.Object;
        _controller = new CatalogController(repository);
        var expectedResult = HttpStatusCode.NotFound;
        
        //act
        var product = await _controller.GetProduct("MyTestId");
        var okResult = product as OkObjectResult;
        var actualProduct = okResult.Value as Product;
        
        //assert
        product.Should().BeOfType<OkObjectResult>();
        okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);
        actualProduct.Id.Should().BeSameAs(GetProduct("MyTestId").Result.Id);
    }

    private static Task<IEnumerable<Product>> GetProducts()
    {
        var fixture = new Fixture();
        var products = new List<Product>();
        products.Add(GetProduct("").Result);
        for (var i = 0; i < 10; i++) products.Add(fixture.Build<Product>().Create());

        return Task.FromResult<IEnumerable<Product>>(products);
    }
    private static Task<Product> GetProduct(string id)
    {
        var fixture = new Fixture();
        if (id == "MyTestId")
            Task.FromResult(fixture.Build<Product>().With(prop => prop.Id, "MyTestId").Create());
        return Task.FromResult(fixture.Build<Product>().Create());
    }
}