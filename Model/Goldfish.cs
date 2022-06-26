using System.IO;
using System.Drawing;

namespace Aquarium.Model
{
    public class Goldfish : FishModel
    {
        public Goldfish() : base()
        {
            this.GoingLeftImage = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\goldfish.png");
            this.GoingRightImage = new Bitmap(GoingLeftImage);
            this.GoingRightImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.DirectionImage = GoingLeftImage;
        }
    }
}
