using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Drawing;
using Aquarium.Model;
using Aquarium.View.UserControls;

namespace Aquarium.Control
{
    public static class FishController
    {
        public static List<FishModel> AllFish { get; set; } = new List<FishModel>();

        public static void Initialize()
        {
            AllFish.Add(new RegularFish());
            AllFish.Add(new Goldfish());
            AllFish.Add(new Angler());


            System.Windows.Forms.Timer seekFood = new System.Windows.Forms.Timer();
            seekFood.Tick += SeekFood;
            seekFood.Interval = 1;
            seekFood.Start();

            System.Windows.Forms.Timer moveToFood = new System.Windows.Forms.Timer();
            moveToFood.Tick += MoveToFood;
            moveToFood.Interval = 1;
            moveToFood.Start();

            System.Windows.Forms.Timer getHungry = new System.Windows.Forms.Timer();
            getHungry.Tick += GetHungry;
            getHungry.Interval = 1000;
            getHungry.Start();

        }


        public static void GetHungry(object sender, EventArgs e)
        {
            foreach (var fish in AllFish)
            {
                fish.HungerCounter--;
                if (fish.HungerCounter == 0)
                {
                    AllFish.Find(f => f == fish).Die();
                    break;
                }
            }
        }

        public static void SeekFood(object sender, EventArgs e)
        {
            foreach (var fish in AllFish)
            {
                var foodlist = new List<FoodUserControl>(FoodController.FoodList);
                if (foodlist.Count == 0 || fish.HungerCounter > 26) continue; 

                int distance = Math.Abs(foodlist[0].Location.X - fish.Location.X);
                foreach (var food in foodlist)
                {
                    int newDistance = Math.Abs(food.Location.X - fish.Location.X);
                    if (newDistance <= distance && !fish.IsDead)
                    {
                        fish.CurrentTarget = food;
                        if (fish.CurrentTarget.Location.X < fish.Location.X) fish.DirectionImage = fish.GoingLeftImage;
                        else fish.DirectionImage = fish.GoingRightImage;
                        distance = newDistance;
                    }
                }
            }
        }
        public static void MoveToFood(object sender, EventArgs e)
        {
            foreach (var fish in AllFish)
            {
                if (fish.IsDead)
                {
                    fish.Location = new Point(fish.Location.X, fish.Location.Y - 1);
                    continue;
                }

                if (fish.CurrentTarget == null) continue;

                int x = fish.Location.X, y = fish.Location.Y;

                if (x < fish.CurrentTarget.Location.X) x++;
                else x--;

                if (y < fish.CurrentTarget.Location.Y) y++;
                else y--;

                fish.Location = new Point(x, y);

                EatFood(fish);
            }
        }

        public static void EatFood(FishModel fish)
        {
            Rectangle rect1 = new Rectangle(fish.Location.X, fish.Location.Y, fish.DirectionImage.Width, fish.DirectionImage.Height);
            Rectangle rect2 = new Rectangle(fish.CurrentTarget.Location.X, fish.CurrentTarget.Location.Y, fish.CurrentTarget.Width, fish.CurrentTarget.Height);

            if (rect1.IntersectsWith(rect2))
            {
                try
                {
                    FoodController.FoodList.Remove(fish.CurrentTarget);
                    FoodController.ForControlRemoval = fish.CurrentTarget;
                    foreach (var otherFish in AllFish)
                        if (fish != otherFish && otherFish.CurrentTarget == fish.CurrentTarget) otherFish.CurrentTarget = null;
                    fish.CurrentTarget = null;
                    fish.HungerCounter = 30;
                }
                catch { }
            }
        }
    }
}
