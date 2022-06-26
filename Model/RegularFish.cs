using System.Drawing;
using System.IO;

namespace Aquarium.Model
{
    public class RegularFish : FishModel
    {
        public RegularFish() : base()
        {
            this.GoingLeftImage = new Bitmap(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\fish.png");
            this.GoingRightImage = new Bitmap(GoingLeftImage);
            this.GoingRightImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            this.DirectionImage = GoingLeftImage;
        }
    }
}
