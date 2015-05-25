using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace Common.ContentProcessing
{
    public class DefaultImageProcessor : IImageProcessor
    {
        public DefaultImageProcessor()
        {
            Add("orig", new ProcessElement()
            {
                IsOriginalSize = true
            });

        }


        public string TargetExtension = "png";
        public ImageFormat ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
        public SortedList<string, ProcessElement> Sizes = new SortedList<string, ProcessElement>();

        public void Add(string _code, ProcessElement _element)
        {
            Sizes.Add(_code, _element);
        }

        public void ProcessTo(Stream _imageStream, Guid _guid, string[] _targetDirectories, string _userPath, out Size _originalSize, out Size _resultSize, out Size _thumbSize)
        {
            Func<Image, int, int, Image> sizeAdjustModeler = (srcImage, sizeX, sizeY)
                                                             =>
            {
                int nw = 0, nh = 0;
                float coeffX = (float)sizeX / srcImage.Width;
                float coeffY = (float)sizeY / srcImage.Height;
                if (srcImage.Width > srcImage.Height )
                {
                    nw = srcImage.Width > sizeX ? sizeX : srcImage.Width;
                    nh = srcImage.Height * nw / srcImage.Width;
                }
                else
                {
                    nh = srcImage.Height > sizeY ? sizeY : srcImage.Height;
                    nw = srcImage.Width * nh / srcImage.Height;
                }
                Image tgImage = new Bitmap(nw, nh);

                using (Graphics dc = Graphics.FromImage(tgImage))
                {
                    dc.CompositingQuality = CompositingQuality.HighQuality;
                    dc.SmoothingMode = SmoothingMode.HighQuality;
                    dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    dc.DrawImage(srcImage, 0, 0, nw, nh);
                }
                return tgImage;
            };

            Func<Image, int, int, CropAction, CropMode, Image> cropAdjustModeler =
                (srcImage, sizeX, sizeY, cropAction, cropMode)
                =>
                {
                    int nw = 0, nh = 0, srcX = 0, srcY = 0;
                    float coeff = (float)sizeX / sizeY;
                    float coeffX = (float)sizeX / srcImage.Width;
                    float coeffY = (float)sizeY / srcImage.Height;

                    switch (cropAction)
                    {
                        case CropAction.Proportional:
                            if (srcImage.Width < srcImage.Height)
                            {
                                nw = srcImage.Width;
                                nh = (int)(nw / coeff);
                            }
                            else
                            {
                                nh = srcImage.Height;
                                nw = (int)(nh * coeff);
                            };
                            break;
                        case CropAction.Exact:
                            nw = sizeX;
                            nh = sizeY;
                            break;
                    }

                    switch (cropMode)
                    {
                        case CropMode.Center:
                            srcX = (srcImage.Width - nw) / 2;
                            srcY = (srcImage.Height - nh) / 2;
                            break;
                    }

                    Image tgImage = new Bitmap(nw, nh);
                    using (Graphics dc = Graphics.FromImage(tgImage))
                    {
                        dc.CompositingQuality = CompositingQuality.HighQuality;
                        dc.SmoothingMode = SmoothingMode.HighQuality;
                        dc.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        dc.DrawImage(srcImage, new Rectangle(0, 0, nw, nh), new Rectangle(srcX, srcY, nw, nh), GraphicsUnit.Pixel);
                       

                    }
                    return tgImage;
                };

            Image image = Image.FromStream(_imageStream, false);
            _originalSize = new Size(image.Width, image.Height);
            _resultSize = new Size();
            _thumbSize = new Size();
            
            foreach (var item in Sizes)
            {
                var targetFName = String.Format("{0}.{1}.{2}", _guid.ToString(), item.Key, TargetExtension);



                Image resultImage = image;


                if ((item.Value.CropX > 0) || (item.Value.CropY > 0))
                {
                    resultImage = cropAdjustModeler(resultImage, item.Value.CropX, item.Value.CropX, item.Value.CropActionField, item.Value.CropModeField);
                }

                if ((item.Value.AdjustX > 0) || (item.Value.AdjustX > 0))
                {
                    resultImage = sizeAdjustModeler(resultImage, item.Value.AdjustX, item.Value.AdjustX);
                }

                // store resulting sizes
                if( item.Value.IsOriginalSize )
                {
                    _resultSize = new Size(resultImage.Width, resultImage.Height);
                }

                if (item.Value.IsThumb)
                {
                    _thumbSize = _resultSize;
                }

                foreach (var dir in _targetDirectories)
                {
                    var tgDirName = Path.Combine(dir, _userPath);
                    if (!Directory.Exists(tgDirName))
                    {
                        Directory.CreateDirectory(tgDirName);
                    }

                    var tgFileName = Path.Combine(tgDirName, targetFName);
                    FileStream stream = new FileStream(tgFileName, FileMode.Create);
                    resultImage.Save(stream, ImageFormat);
                    stream.Close();
                }
            }
        }


        public string GetImageFormat()
        {
            return TargetExtension;
        }
    }
}