using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aquarium.View.UserControls
{
    public partial class FoodUserControl : UserControl
    {
        public FoodUserControl(Point location)
        {
            InitializeComponent();
            this.Location = location;
        }

        private void FoodUserControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkRed, new Rectangle(0, 0, this.Width, this.Height)); 
        }

        public void ChangeLocation(Point newLocation)
        {
            this.Location = newLocation;
        }
    }
}
