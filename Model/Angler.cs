using System.IO;
using System.Drawing;

namespace Aquarium.Model
{
    internal class Angler : FishModel
    {
        public Angler() : base()
        {
            this.GoingLeftImage = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\angler.png");
            this.GoingRightImage = new Bitmap(GoingLeftImage);
            this.GoingRightImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.DirectionImage = GoingLeftImage;
        }
    }
}
