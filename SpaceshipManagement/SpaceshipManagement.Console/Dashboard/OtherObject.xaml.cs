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

namespace SpaceshipManagement.Console.Dashboard
{
    /// <summary>
    /// Interaction logic for OtherObject.xaml
    /// </summary>
    public partial class OtherObject : UserControl
    {
        public Location MyLocation { get; set; }
        public OtherObject(int x, int y)
        {
            MyLocation = new Location(x, y);
            Grid.SetRow(this, x);
            Grid.SetColumn(this, y);
            InitializeComponent();
        }
    }
}
