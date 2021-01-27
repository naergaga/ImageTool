using ImageTool.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageTool.Services
{
    public class ImageService
    {

        public void Rotate(List<ImageItem> list,RotateDegree degree)
        {
            RotateFlipType type ;
            switch (degree)
            {
                case RotateDegree.D90:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
                case RotateDegree.D180:
                    type = RotateFlipType.Rotate180FlipNone;
                    break;
                case RotateDegree.D270:
                    type = RotateFlipType.Rotate270FlipNone;
                    break;
                default:
                    type = RotateFlipType.Rotate90FlipNone;
                    break;
            }

            foreach (var item in list)
            {
                var image = new Bitmap(item.Name);
                image.RotateFlip(type);
                image.Save(item.NewName, image.RawFormat);
            }
        }
    }
}
