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
using System.Threading.Tasks;
using Aquarium.Model;

namespace Aquarium.View.UserControls
{
    public partial class FishUserControl : UserControl
    {
        private int FishID { get; set; }
        private Timer UpdateTimer { get; set; }
        public FishUserControl(int fishID)
        {
            InitializeComponent();
            this.FishID = fishID;
            this.Size = FishController.AllFish.Find(f => f.Id == FishID).DirectionImage.Size;
        }

        private void Update(object sender, EventArgs e)
        {
            var fish = FishController.AllFish.Find(f => f.Id == this.FishID);
            this.BeginInvoke(new Action(() =>
            {
                this.Location = fish.Location;
                this.BackgroundImage = fish.DirectionImage;
            }));

            if (fish.IsDead && fish.Location.Y < 0 - this.Height)
            {
                FishController.AllFish.Remove(fish);
                Parent.Controls.Remove(this);
                this.Dispose();
                UpdateTimer.Stop();

            }
        }
        private void FishUserControl_Load(object sender, EventArgs e)
        {
            UpdateTimer = new Timer();
            UpdateTimer.Tick += Update;
            UpdateTimer.Interval = 1;
            UpdateTimer.Start();
        }

    }
}
