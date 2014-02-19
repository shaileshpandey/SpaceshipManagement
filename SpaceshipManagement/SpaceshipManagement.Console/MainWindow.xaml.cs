using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SpaceshipManagement.Console.Dashboard;

namespace SpaceshipManagement.Console
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public HomePlanet HomePlanet { get; set; }
        public List<Asteroids> Asteroids { get; set; }
        public List<Star> Stars { get; set; }
        public List<OtherObject> ImaginaryObjects { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DrawBlocks();
            PlaceHomePlanet();
            PlaceAsteroids();
            PlaceStars();
            PlaceImaginaryObjects();
        }

        public void DrawBlocks()
        {
            for (int count = 0; count < 10; count++)
            {
                mainGrd.RowDefinitions.Add(new RowDefinition());
                mainGrd.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        public void PlaceHomePlanet()
        {
            HomePlanet = new HomePlanet(5,5);
            Grid.SetRow(HomePlanet, HomePlanet.MyLocation.X);
            Grid.SetColumn(HomePlanet, HomePlanet.MyLocation.Y);
            mainGrd.Children.Add(HomePlanet);
        }

        public void PlaceAsteroids()
        {
            Asteroids = new List<Console.Asteroids>();
            var control = new Asteroids(0,0);
            mainGrd.Children.Add(control);
            Asteroids.Add(control);

            control = new Asteroids(9,9);
            mainGrd.Children.Add(control);
            Asteroids.Add(control);

            control = new Asteroids(0,9);
            mainGrd.Children.Add(control);
            Asteroids.Add(control);

            control = new Asteroids(9,0);
            mainGrd.Children.Add(control);
            Asteroids.Add(control);

            control = new Asteroids(7,7);
            mainGrd.Children.Add(control);
            Asteroids.Add(control);
        }

        public void PlaceStars()
        {
            Stars = new List<Star>();
            for (int count = 0; count < 20; count++)
            {
                var location = CalculateRandomLocation();
                var control = new Star(location.X, location.Y);
                Stars.Add(control);
                mainGrd.Children.Add(control);
            }
        }

        public void PlaceImaginaryObjects()
        {
            ImaginaryObjects = new List<OtherObject>();
            for (int count = 0; count < 16; count++)
            {
                var location = CalculateRandomLocation();
                var control = new OtherObject(location.X, location.Y);
                ImaginaryObjects.Add(control);
                mainGrd.Children.Add(control);
            }
        }

        public Location CalculateRandomLocation()
        {
            var location = new Location(0, 0);
            Random random = new Random();
            var minValue = random.Next(0, 9);
            var maxValue = random.Next(0, 9);
            var newLocation = new Location(minValue, maxValue);
            while (CalculateOccupiedSpaces().Count(c => c.ExactlyEqual(newLocation)) > 0)
            {
                minValue = random.Next(0, 9);
                maxValue = random.Next(0, 9);
                newLocation = new Location(minValue, maxValue);
            }

            return newLocation;
        }

        public List<Location> CalculateOccupiedSpaces()
        {
            List<Location> occupied = new List<Location>();
            if(HomePlanet != null)
            occupied.Add(HomePlanet.MyLocation);

            if (Asteroids != null)
            occupied.AddRange(Asteroids.Select(c=>c.MyLocation).ToList());

            if (Stars != null)
            occupied.AddRange(Stars.Select(c => c.MyLocation).ToList());

            if (ImaginaryObjects != null)
                occupied.AddRange(ImaginaryObjects.Select(c => c.MyLocation).ToList());
            return occupied;
        }
    }
}
