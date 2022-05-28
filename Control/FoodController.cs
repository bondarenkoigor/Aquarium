using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aquarium.View.UserControls;
using System.Drawing;
using System.Windows.Forms;


namespace Aquarium.Control
{
    public static class FoodController
    {
        public static List<FoodUserControl> FoodList { get; set; }

        public static Timer MoveFoodDown = new Timer();

        public static void Initialize()
        {
            FoodList = new List<FoodUserControl>();
            MoveFoodDown.Tick += MoveFoodDown_Tick;
            MoveFoodDown.Interval = 500;
            MoveFoodDown.Start();
        }

        private static void MoveFoodDown_Tick(object sender, EventArgs e)
        {
            foreach (FoodUserControl food in FoodList)
            {
                if (food.Location.Y <= FoodList[0].Parent.ClientSize.Height - food.Size.Height) food.ChangeLocation(new Point(food.Location.X, food.Location.Y + 10));
            }
        }
    }
}
