using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aquarium.View.UserControls;
using Aquarium.Control;
using System.IO;

namespace Aquarium.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FoodController.Initialize();
            FishUserControl fish = new FishUserControl();
            fish.Location = new Point(this.Width / 2 - fish.Width, this.Height / 2 - fish.Height);
            this.Controls.Add(fish);
            Timer removeFood = new Timer();
            removeFood.Interval = 10;
            removeFood.Tick += (sender, e) =>
                this.Controls.Remove(fish.ForRemoval);
            removeFood.Start();

            this.DoubleBuffered = true;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            FoodUserControl newFood = new FoodUserControl(new Point(e.X - 25, e.Y - 15));
            FoodController.FoodList.Add(newFood);
            this.Controls.Add(newFood);
        }

        private void MainForm_ClientSizeChanged(object sender, EventArgs e)
        {
            foreach (var food in FoodController.FoodList)
            {
                if (food.Location.X + food.Width > this.ClientSize.Width) food.Location = new Point(this.ClientSize.Width - food.Width, food.Location.Y);
                if (food.Location.X < 0) food.Location = new Point(0, food.Height);

                if (food.Location.Y + food.Height > this.ClientSize.Height) food.Location = new Point(food.Location.X, this.ClientSize.Height - food.Height);
                if (food.Location.Y < 0) food.Location = new Point(food.Location.X, 0);
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\background.png"), 0, 0, this.ClientSize.Width, this.ClientSize.Height);
        }
    }
}
