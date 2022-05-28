using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.Control;
using System.IO;

namespace Aquarium.View.UserControls
{
    public partial class FishUserControl : UserControl
    {
        public FoodUserControl CurrentTarget { get; set; }
        public FoodUserControl ForRemoval { get; set; }

        public Image GoingRightImage { get; set; }
        public Image GoingLeftImage { get; set; }
        public FishUserControl()
        {
            InitializeComponent();

            GoingLeftImage = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\fish.png");
            GoingRightImage =  new Bitmap(GoingLeftImage);
            GoingRightImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            Timer seekFood = new Timer();
            seekFood.Interval = 1;
            seekFood.Tick += SeekFood_Tick;
            seekFood.Start();

            Timer move = new Timer();
            move.Interval = 1;
            move.Tick += Move_Tick;
            move.Start();
        }

        private void Move_Tick(object sender, EventArgs e)
        {
            if (CurrentTarget == null) return;

            int x = this.Location.X, y = this.Location.Y;
            if (x < CurrentTarget.Location.X)
            {
                x++;
                this.BackgroundImage = GoingRightImage;
            }
            else
            {
                x--;
                this.BackgroundImage = GoingLeftImage;
            }
            if (y < CurrentTarget.Location.Y) y++;
            else y--;
            this.Location = new Point(x, y);


            Rectangle rect1 = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rect2 = new Rectangle(CurrentTarget.Location.X, CurrentTarget.Location.Y, CurrentTarget.Width, CurrentTarget.Height);

            if (rect1.IntersectsWith(rect2))
            {
                FoodController.FoodList.Remove(CurrentTarget);
                ForRemoval = CurrentTarget;
                CurrentTarget = null;
            }
        }

        private void SeekFood_Tick(object sender, EventArgs e)
        {
            if (FoodController.FoodList.Count == 0) return;


            int distance = Math.Abs(FoodController.FoodList[0].Location.X - this.Location.X);
            foreach (var food in FoodController.FoodList)
            {
                int newDistance = Math.Abs(food.Location.X - this.Location.X);
                if (newDistance <= distance)
                {
                    CurrentTarget = food;
                    distance = newDistance;
                }
            }
        }

    }
}
