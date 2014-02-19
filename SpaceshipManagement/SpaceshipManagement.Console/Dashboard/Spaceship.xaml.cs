using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SpaceshipManagement.Console.Dashboard;

namespace SpaceshipManagement.Console
{
    public partial class Spaceship : UserControl
    {
        public Location MyLocation { get; set; }
        public Spaceship(int x, int y)
        {
            MyLocation = new Location(x, y);
            InitializeComponent();
        }
    }
}
