using System;
using System.Drawing;
using Aquarium.View.UserControls;

namespace Aquarium.Model
{
    public abstract class FishModel
    {
        public static Random random = new Random();
        public FoodUserControl CurrentTarget { get; set; }
        public FoodUserControl ForRemoval { get; set; }
        public Image GoingRightImage { get; set; }
        public Image GoingLeftImage { get; set; }
        public Image DirectionImage { get; set; }
        public int HungerCounter { get; set; } = 30;
        public Point Location { get; set; }
        public bool IsDead { get; set; } = false;
        private static int idCounter { get; set; } = 0;
        public int Id { get; set; }


        public FishModel()
        {
            idCounter++;
            this.Id = idCounter;
            this.Location = new Point(random.Next(0, 800), random.Next(0, 400));
        }

        public void Die()
        {
            this.IsDead = true;
            this.DirectionImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
        }
    }
}
