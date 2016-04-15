using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarsRover.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new HomePageViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(HomePageViewModel viewModel)
        {
            //Add error handling to check casing of input, valid characters for directions etc.

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            foreach (var marsRover in viewModel.MarsRover)
            {
                marsRover.FinalPosition = MoveRover(marsRover, viewModel.UpperRightXCoOrdinate, viewModel.UpperRightYCoOrdinate);
            }

            return View(viewModel);
        }

        //Move to a service layer
        public string MoveRover(MarsRoverModel marsRover, int maximumX, int maximumY)
        {
            //Add error handling using maximum params to check the rover is in bounds

            int x = marsRover.CurrentPosition.X;
            int y = marsRover.CurrentPosition.Y;
            string direction = marsRover.CurrentPosition.SelectedDirection;

            foreach (var order in marsRover.MoveOrders)
            {
                switch (order.ToString().ToUpper())
                {
                    case "L":
                        switch (direction)
                        {
                            case "N":
                                direction = "W";
                                break;
                            case "E":
                                direction = "N";
                                break;
                            case "W":
                                direction = "S";
                                break;
                            default:
                                //South
                                direction = "E";
                                break;
                        }
                        break;
                    case "R":
                        switch (direction)
                        {
                            case "N":
                                direction = "E";
                                break;
                            case "E":
                                direction = "S";
                                break;
                            case "W":
                                direction = "N";
                                break;
                            default:
                                //South
                                direction = "W";
                                break;
                        }
                        break;
                    default:
                        //M
                        switch (direction)
                        {
                            case "N":
                                y++;
                                break;
                            case "E":
                                x++;
                                break;
                            case "W":
                                x--;
                                break;
                            default:
                                //South
                                y--;
                                break;
                        }
                        break;
                }
            }

            return string.Format("{0} {1} {2}", x, y, direction);
        }
    }
}