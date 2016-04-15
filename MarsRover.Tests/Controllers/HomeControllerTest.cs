using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using MarsRover.Controllers;
using MarsRover.Models;

namespace MarsRover.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void MoveRover()
        {
            // Arrange
            var viewModel = new HomePageViewModel
            {
                UpperRightXCoOrdinate = 5,
                UpperRightYCoOrdinate = 5,
                MarsRover = new List<MarsRoverModel>
                {
                    new MarsRoverModel
                    {
                        CurrentPosition = new CurrentPositionModel
                        {
                            SelectedDirection = "N",
                            X = 1,
                            Y = 2   
                        },
                        MoveOrders = "LMLMLMLMM"
                    },
                    new MarsRoverModel
                    {
                        CurrentPosition = new CurrentPositionModel
                        {
                            SelectedDirection = "E",
                            X = 3,
                            Y = 3
                        },
                        MoveOrders = "MMRMMRMRRM"
                    }
                }
            };

            HomeController controller = new HomeController();

            // Act
            var rover1 = controller.MoveRover(viewModel.MarsRover[0], viewModel.UpperRightXCoOrdinate, viewModel.UpperRightYCoOrdinate);
            var rover2 = controller.MoveRover(viewModel.MarsRover[1], viewModel.UpperRightXCoOrdinate, viewModel.UpperRightYCoOrdinate);

            // Assert
            Assert.AreEqual("1 3 N", rover1);
            Assert.AreEqual("5 1 E", rover2);
        }
    }
}
