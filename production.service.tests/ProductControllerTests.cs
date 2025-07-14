

using Microsoft.AspNetCore.Mvc;
using Moq;
using production.service.api.Controllers;
using production.service.api.Interfaces;
using production.service.api.Models;
using production.service.api.Models.Dto;
using Xunit;

namespace production.service.tests;
public class ProductControllerTests
{
    private readonly Mock<IProductService> _mockService;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockService = new Mock<IProductService>();
        _controller = new ProductController(_mockService.Object);
    }

    [Fact]
    public void GetAll_ReturnsListOfProducts()
    {
  
        var products = new List<Product> { new Product(), new Product() };
        _mockService.Setup(s => s.GetAll()).Returns(products);

  
        var result = _controller.GetAll();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(2, returnedProducts.Count);
    }

    [Fact]
    public void GetById_ExistingId_ReturnsProduct()
    {

        var productId = Guid.NewGuid();
        var product = new Product { ProductID=productId};
        _mockService.Setup(s => s.GetById(productId)).Returns(product);

        var result = _controller.GetById(productId);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedProduct = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(productId, returnedProduct.ProductID);
    }

    [Fact]
    public void GetById_NotFound_ReturnsNotFound()
    {
        var productId = Guid.NewGuid();
        _mockService.Setup(s => s.GetById(productId)).Returns((Product)null);

        var result = _controller.GetById(productId);

        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Create_ValidDto_ReturnsOk()
    {

        var dto = new ProductDto { Name = "Test Product", Price = 100 };

        var result = _controller.Create(dto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public void Update_ExistingProduct_ReturnsNoContent()
    {
        var productId = Guid.NewGuid();
        var dto = new ProductDto { Name = "Updated Product", Price = 150 };
        _mockService.Setup(s => s.Update(It.IsAny<Product>(), productId)).Returns(true);

        var result = _controller.Update(productId, dto);

        Assert.IsType<NoContentResult>(result);
    }



    [Fact]
    public void Delete_ExistingProduct_ReturnsNoContent()
    {

        var productId = Guid.NewGuid();
        _mockService.Setup(s => s.GetById(productId)).Returns(new Product());

        var result = _controller.Delete(productId);

        Assert.IsType<NoContentResult>(result);
    }


}
