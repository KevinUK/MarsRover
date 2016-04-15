﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MarsRover.Models
{
    public class HomePageViewModel
    {
        public HomePageViewModel()
        {
            MarsRover = new List<MarsRoverModel>
            {
                new MarsRoverModel()
                {
                    CurrentPosition = new CurrentPositionModel()
                },
                new MarsRoverModel()
                {
                    CurrentPosition = new CurrentPositionModel()
                }
            };
        }

        public List<MarsRoverModel> MarsRover { get; set; }
        public int UpperRightXCoOrdinate { get; set; }
        public int UpperRightYCoOrdinate { get; set; }
    }

    public class MarsRoverModel
    {
        public CurrentPositionModel CurrentPosition { get; set; }
        public string MoveOrders { get; set; }
        public string FinalPosition { get; set; }
    }

    public class CurrentPositionModel
    {
        public CurrentPositionModel()
        {
            var directions = new List<SelectListItem>();

            directions.Add(new SelectListItem { Text = "North", Value = "N" });
            directions.Add(new SelectListItem { Text = "East", Value = "E" });
            directions.Add(new SelectListItem { Text = "South", Value = "S" });
            directions.Add(new SelectListItem { Text = "West", Value = "W" });

            Directions = directions;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public string SelectedDirection { get; set; }
        public List<SelectListItem> Directions { get; set; }
    }
}
