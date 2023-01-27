using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Records.API.Controllers;
using Records.API.Data;
using Records.Model.Models;
using Xunit;

namespace Records.Test;

public class TestController
{
    private RecordsController _controller;
    private PeopleContext context;
    
    public TestController()
    {
        var log = new Mock<ILogger<RecordsController>>();
        context = new PeopleContext();
        _controller = new RecordsController(context, log.Object);
        context.Persons.Add(new Person()
        {
            LastName = "Doctor",
            FirstName = "Who",
            Email = "TARDIS@timeandspace.com",
            FavoriteColor = "TardisBlue",
            DateOfBirth = DateTime.Parse("11/23/1963")
        });
    }

    [Fact]
    public void Test_Controller_Get()
    {
        var response = _controller.GetName();
        Assert.True(response.First().LastName == "Doctor");
    }
}