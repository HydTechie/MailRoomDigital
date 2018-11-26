﻿ 
using MailRoom.Repository.Interfaces;
using MailRoom.Model;
using ChartJSCore.Models;
using ChartJSCore.Models.Bar;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MailRoom.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Error()
        //{
        //    return View("~/Views/Shared/Error.cshtml");
        //}

        [HttpGet("[controller]")]
        [ActionName("Index")]
        public IActionResult Index()
        {
            Chart barChart = GenerateBarChart();
            Chart lineChart = GenerateLineChart();
            //Chart lineScatterChart = GenerateLineScatterChart();
            //Chart radarChart = GenerateRadarChart();
            //Chart polarChart = GeneratePolarChart();
            //Chart pieChart = GeneratePieChart();
            //Chart nestedDoughnutChart = GenerateNestedDoughnutChart();

            ViewData["BarChart"] = barChart;
            ViewData["LineChart"] = lineChart;
            //ViewData["LineScatterChart"] = lineScatterChart;
            //ViewData["RadarChart"] = radarChart;
            //ViewData["PolarChart"] = polarChart;
            //ViewData["PieChart"] = pieChart;
            //ViewData["NestedDoughnutChart"] = nestedDoughnutChart;

            return View("~/Views/Home/Index.cshtml");
            //return View();
        }

        //[ActionName("GetRandomData")]
        private int[] GetRandomData(int id)
        {
            List<int> data = new List<int>();
            var rdm = new Random((int)DateTime.Now.Ticks);

            for (int i = 0; i < id; i++)
            {
                data.Add(rdm.Next(0, 100));
            }

            return data.ToArray();
        }

        private static Chart GenerateBarChart()
        {
            Chart chart = new Chart();
            chart.Type = "bar";

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

            BarDataset dataset = new BarDataset()
            {
                Label = "# of Votes",
                Data = new List<double>() { 12, 19, 3, 5, 2, 3 },
                BackgroundColor = new List<string>()
                {
                "rgba(255, 99, 132, 0.2)",
                "rgba(54, 162, 235, 0.2)",
                "rgba(255, 206, 86, 0.2)",
                "rgba(75, 192, 192, 0.2)",
                "rgba(153, 102, 255, 0.2)",
                "rgba(255, 159, 64, 0.2)"
                },
                BorderColor = new List<string>()
                {
                "rgba(255,99,132,1)",
                "rgba(54, 162, 235, 1)",
                "rgba(255, 206, 86, 1)",
                "rgba(75, 192, 192, 1)",
                "rgba(153, 102, 255, 1)",
                "rgba(255, 159, 64, 1)"
                },
                BorderWidth = new List<int>() { 1 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            BarOptions options = new BarOptions()
            {
                Scales = new Scales(),
                BarPercentage = 0.7
            };

            Scales scales = new Scales()
            {
                YAxes = new List<Scale>()
                {
                    new CartesianScale()
                    {
                        Ticks = new CartesianLinearTick()
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            chart.Options.Layout = new Layout()
            {
                Padding = new Padding()
                {
                    PaddingObject = new PaddingObject()
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        private static Chart GenerateLineChart()
        {
            Chart chart = new Chart();
            chart.Type = "line";

            Data data = new Data();
            data.Labels = new List<string>() { "January", "February", "March", "April", "May", "June", "July" };

            LineDataset dataset = new LineDataset()
            {
                Label = "My First dataset",
                Data = new List<double>() { 65, 59, 80, 81, 56, 55, 40 },
                Fill = "false",
                LineTension = 0.1,
                BackgroundColor = "rgba(75, 192, 192, 0.4)",
                BorderColor = "rgba(75,192,192,1)",
                BorderCapStyle = "butt",
                BorderDash = new List<int> { },
                BorderDashOffset = 0.0,
                BorderJoinStyle = "miter",
                PointBorderColor = new List<string>() { "rgba(75,192,192,1)" },
                PointBackgroundColor = new List<string>() { "#fff" },
                PointBorderWidth = new List<int> { 1 },
                PointHoverRadius = new List<int> { 5 },
                PointHoverBackgroundColor = new List<string>() { "rgba(75,192,192,1)" },
                PointHoverBorderColor = new List<string>() { "rgba(220,220,220,1)" },
                PointHoverBorderWidth = new List<int> { 2 },
                PointRadius = new List<int> { 1 },
                PointHitRadius = new List<int> { 10 },
                SpanGaps = false
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            Options options = new Options()
            {
                Scales = new Scales()
            };

            Scales scales = new Scales()
            {
                YAxes = new List<Scale>()
                {
                    new CartesianScale()
                }
            };

            CartesianScale yAxes = new CartesianScale()
            {
                Ticks = new Tick()
            };

            Tick tick = new Tick()
            {
                Callback = "function(value, index, values) {return '$' + value;}"
            };

            yAxes.Ticks = tick;
            scales.YAxes = new List<Scale>() { yAxes };
            options.Scales = scales;
            chart.Options = options;

            chart.Data = data;

            return chart;
        }

        private static Chart GenerateLineScatterChart()
        {
            Chart chart = new Chart();
            chart.Type = "line";

            Data data = new Data();

            LineScatterDataset dataset = new LineScatterDataset()
            {
                Label = "Scatter Dataset",
                Data = new List<LineScatterData>()
            };

            LineScatterData scatterData1 = new LineScatterData();
            LineScatterData scatterData2 = new LineScatterData();
            LineScatterData scatterData3 = new LineScatterData();

            scatterData1.x = "-10";
            scatterData1.y = "0";
            dataset.Data.Add(scatterData1);

            scatterData2.x = "0";
            scatterData2.y = "10";
            dataset.Data.Add(scatterData2);

            scatterData3.x = "10";
            scatterData3.y = "5";
            dataset.Data.Add(scatterData3);

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            Options options = new Options()
            {
                Scales = new Scales()
            };

            Scales scales = new Scales()
            {
                XAxes = new List<Scale>()
                {
                    new CartesianScale()
                    {
                        Type = "linear",
                        Position = "bottom",
                        Ticks = new CartesianLinearTick()
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            return chart;
        }

        private static Chart GenerateRadarChart()
        {
            Chart chart = new Chart();
            chart.Type = "radar";

            Data data = new Data();
            data.Labels = new List<string>() { "Eating", "Drinking", "Sleeping", "Designing", "Coding", "Cycling", "Running" };

            RadarDataset dataset1 = new RadarDataset()
            {
                Label = "My First dataset",
                BackgroundColor = "rgba(179,181,198,0.2)",
                BorderColor = "rgba(179,181,198,1)",
                PointBackgroundColor = new List<string>() { "rgba(179,181,198,1)" },
                PointBorderColor = new List<string>() { "#fff" },
                PointHoverBackgroundColor = new List<string>() { "#fff" },
                PointHoverBorderColor = new List<string>() { "rgba(179,181,198,1)" },
                Data = new List<double>() { 65, 59, 80, 81, 56, 55, 40 }
            };

            RadarDataset dataset2 = new RadarDataset()
            {
                Label = "My Second dataset",
                BackgroundColor = "rgba(255,99,132,0.2)",
                BorderColor = "rgba(255,99,132,1)",
                PointBackgroundColor = new List<string>() { "rgba(255,99,132,1)" },
                PointBorderColor = new List<string>() { "#fff" },
                PointHoverBackgroundColor = new List<string>() { "#fff" },
                PointHoverBorderColor = new List<string>() { "rgba(255,99,132,1)" },
                Data = new List<double>() { 28, 48, 40, 19, 96, 27, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset1);
            data.Datasets.Add(dataset2);

            chart.Data = data;

            return chart;
        }

        private static Chart GeneratePolarChart()
        {
            Chart chart = new Chart();
            chart.Type = "polarArea";

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Green", "Yellow", "Grey", "Blue" };

            PolarDataset dataset = new PolarDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<string>() { "#FF6384", "#4BC0C0", "#FFCE56", "#E7E9ED", "#36A2EB" },
                Data = new List<double>() { 11, 16, 7, 3, 14 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

        private static Chart GeneratePieChart()
        {
            Chart chart = new Chart();
            chart.Type = "pie";

            Data data = new Data();
            data.Labels = new List<string>() { "Red", "Blue", "Yellow" };

            PieDataset dataset = new PieDataset()
            {
                Label = "My dataset",
                BackgroundColor = new List<string>() { "#FF6384", "#36A2EB", "#FFCE56" },
                HoverBackgroundColor = new List<string>() { "#FF6384", "#36A2EB", "#FFCE56" },
                Data = new List<double>() { 300, 50, 100 }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(dataset);

            chart.Data = data;

            return chart;
        }

        private static Chart GenerateNestedDoughnutChart()
        {
            Chart chart = new Chart();
            chart.Type = "doughnut";

            Data data = new Data();
            data.Labels = new List<string>() {
                "resource-group-1",
                "resource-group-2",
                "Data Services - Basic Database Days",
                "Data Services - Basic Database Days",
                "Azure App Service - Basic Small App Service Hours",
                "resource-group-2 - Other"
            };

            PieDataset outerDataset = new PieDataset()
            {
                BackgroundColor = new List<string>() {
                    "#3366CC",
                    "#DC3912",
                    "#FF9900",
                    "#109618",
                    "#990099",
                    "#3B3EAC"
                },
                HoverBackgroundColor = new List<string>() {
                    "#3366CC",
                    "#DC3912",
                    "#FF9900",
                    "#109618",
                    "#990099",
                    "#3B3EAC"
                },
                Data = new List<double>() {
                    0.0,
                    0.0,
                    8.31,
                    10.43,
                    84.69,
                    0.84
                }
            };

            PieDataset innerDataset = new PieDataset()
            {
                BackgroundColor = new List<string>() {
                    "#3366CC",
                    "#DC3912",
                    "#FF9900",
                    "#109618",
                    "#990099",
                    "#3B3EAC"
                },
                HoverBackgroundColor = new List<string>() {
                    "#3366CC",
                    "#DC3912",
                    "#FF9900",
                    "#109618",
                    "#990099",
                    "#3B3EAC"
                },
                Data = new List<double>() {
                    8.31,
                    95.96
                }
            };

            data.Datasets = new List<Dataset>();
            data.Datasets.Add(outerDataset);
            data.Datasets.Add(innerDataset);

            chart.Data = data;

            return chart;
        }
    }
}
