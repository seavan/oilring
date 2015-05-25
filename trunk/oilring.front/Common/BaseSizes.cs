using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace Notamedia.Oilring
{
    public static class BaseSizes
    {
        static BaseSizes()
        {
            m_Sizes[ConstSizes.MID] = new Size(74, 74);
            m_Sizes[ConstSizes.SMALL] = new Size(50, 50);
            m_Sizes[ConstSizes.LARGE] = new Size(204, 204);
            m_Sizes[ConstSizes.ORIG] = new Size(-1, -1);
        }

        public static void DeleteAll(string _guid, string _path)
        {
            if (!string.IsNullOrEmpty(_guid))
            {
                foreach (var pair in m_Sizes)
                {
                    try
                    {
                        File.Delete(_path + _guid + "." + pair.Key + ".jpg");
                    }
                    catch { }
                }
            }
        }

        public static void SaveAll(string _guid, string _path, Stream _input)
        {
            _input.Seek(0, SeekOrigin.Begin);
            var image = Bitmap.FromStream(_input);

            foreach(var pair in m_Sizes)
            {
                var fname = _path + _guid + "." + pair.Key + ".jpg";

                if (pair.Value.Width < 0)
                {
                    image.Save(fname, ImageFormat.Jpeg);
                }
                else
                {
                    var targetBmp = new Bitmap(pair.Value.Width, pair.Value.Height);
                    Graphics dc = Graphics.FromImage(targetBmp);
                    dc.FillRectangle(Brushes.White, 0, 0, targetBmp.Width, targetBmp.Height);
                    float x = 0, y = 0, w = 0, h = 0;
                    if (image.Width >= image.Height)
                    {
                        x = 0;
                        w = targetBmp.Width;
                        h = image.Height * targetBmp.Width / image.Width;
                        y = (targetBmp.Height - h)/2;
                    }
                    else
                    {
                        y = 0;
                        h = targetBmp.Height;
                        w = image.Width * targetBmp.Height / image.Height;
                        x = (targetBmp.Width - w)/2;
                    }

                    dc.DrawImage(image, x, y, w, h);
                    dc.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    targetBmp.Save(fname, ImageFormat.Jpeg);
                }
            }
        }

        public static string SaveTemp(string _path, HttpPostedFileBase _input)
        {
            //var expansion = _input.FileName.Remove(0, _input.FileName.LastIndexOf(".") + 1);
            var expansion = "jpg";
            var targetFName = Guid.NewGuid().ToString() + "." + expansion;

            FileStream stream = new FileStream(_path + targetFName, FileMode.Create);
            Image image = Image.FromStream(_input.InputStream);
            int nw = 0, nh = 0;
            if( image.Width > image.Height )
            {
                nw = image.Width > PREPARE_SIZE ? PREPARE_SIZE : image.Width;
                nh = image.Height * nw / image.Width;
            }
            else
            {
                nh = image.Height > PREPARE_SIZE ? PREPARE_SIZE : image.Height;
                nw = image.Width * nh / image.Height;
            }
            Image tgImage = new Bitmap(nw, nh);

            Graphics dc = Graphics.FromImage(tgImage);
            dc.DrawImage(image, 0, 0, nw, nh);
            tgImage.Save(stream, ImageFormat.Jpeg);
            stream.Close();

            return targetFName;
        }

        public static string CropAndSave(int _X, int _Y, int _Width, int _Height, string _name, string _path)
        {
            //FileStream fs = new FileStream(_path+"log.txt", FileMode.Append, FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs);
            //sw.WriteLine(_X.ToString() + ", " + _Y.ToString() + ", " + _Width.ToString() + ", " + _Height.ToString() + ", " + _path);
            //sw.Close();
            //fs.Dispose();

            Rectangle cropSection = new Rectangle();
            cropSection.X = _X;
            cropSection.Y = _Y;
            cropSection.Width = _Width;
            cropSection.Height = _Height;

            Image image = Image.FromFile(_path + _name);
            Bitmap bmpSave = new Bitmap(cropSection.Width, cropSection.Height);
            bmpSave.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            Graphics g = Graphics.FromImage(bmpSave);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            var new_name = Guid.NewGuid().ToString() + ".jpg";
            g.DrawImage(image, 0, 0, cropSection, GraphicsUnit.Pixel);
            bmpSave.Save(_path + new_name, ImageFormat.Jpeg);
            g.Dispose();
            bmpSave.Dispose();
            image.Dispose();
            File.Delete(_path + _name);

            return new_name;
            
        }

        private static SortedList<string, Size> m_Sizes = new SortedList<string, Size>();
        public static string PATH = "~/Content/avatars/";
        public static string TEMPPATH = "~/Content/temp/";
        public const int PREPARE_SIZE = 1000;
    }

    public class ConstSizes
    {
        public const string MID = "mid";
        public const string SMALL = "small";
        public const string LARGE = "large";
        public const string ORIG = "orig";
    }
}