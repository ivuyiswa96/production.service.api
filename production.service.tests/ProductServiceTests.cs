using System;
using System.Linq;
using production.service.api.Models;
using production.service.api.Services;
using Xunit;

namespace production.service.tests;
public class ProductServiceTests
{
    [Fact]
    public void Create_AddsProductToList()
    {
        var service = new ProductService();
        var product = new Product { Name = "Mercedes-Benz", Description = "2015 CLA A/T", Price = 60000 };

        service.Create(product);
        var result = service.GetAll();

        Assert.Single(result);
    }

    [Fact]
    public void GetById_ReturnsCorrectProduct()
    {
        var service = new ProductService();
        var product = new Product { Name = "Mpesu", Description = "African product to build the country", Price = 599.00 };
        service.Create(product);
        var saved = service.GetAll().First();

        var result = service.GetById(saved.ProductID);

        Assert.Equal("Mpesu", result.Name);
    }

    [Fact]
    public void Delete_RemovesProduct()
    {
        var service = new ProductService();
        var product = new Product { Name = "USB-C Cable", Description = "1.5m fast charging cable", Price = 149.50 };
        service.Create(product);
        var saved = service.GetAll().First();

        service.Delete(saved.ProductID);
        var all = service.GetAll();

        Assert.Empty(all);
    }

    [Fact]
    public void Update_ChangesValues()
    {
        var service = new ProductService();
        var product = new Product { Name = "Jordan 8", Description = "Nike Limited edition for PSG", Price = 6299.00 };
        service.Create(product);
        var saved = service.GetAll().First();

        var updated = new Product { Name = "Smartwatch Pro", Description = "GPS & heart rate tracking", Price = 1799.00 };
        var result = service.Update(updated, saved.ProductID);

        var after = service.GetById(saved.ProductID);

        Assert.True(result);
        Assert.Equal("Smartwatch Pro", after.Name);
        Assert.Equal(1799.00, after.Price);
    }

    [Fact]
    public void Update_ReturnsFalse_WhenProductNotFound()
    {
        var service = new ProductService();
        var product = new Product { Name = "Noise Cancelling Headphones", Description = "Over-ear with mic", Price = 2499.99};
        var result = service.Update(product, Guid.NewGuid());

        Assert.False(result);
    }
}
