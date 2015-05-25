using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Notamedia.Oilring.Community.Common
{
    public class PercentageDrawImage
    {
        static private HttpContext Ctx = HttpContext.Current;

        public static Bitmap RenderImage(string percentageString)
        {
            return GenerateImagePrivate(percentageString);
        }

        private static Bitmap GenerateImagePrivate(string percentageString)
        {
            //percentageString = "24";
            int percentagInt = int.Parse(percentageString);
            Image fonImg = Image.FromFile(Ctx.Server.MapPath("~/Content/i/") + "bpPercentage.jpg");

            Bitmap bmp = new Bitmap(77, 77, PixelFormat.Format32bppRgb);
            
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                Rectangle rectChar = new Rectangle(0, 0, 77, 77);

                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.Clear(Color.BlanchedAlmond);

                gr.DrawImage(fonImg, 0, 0, 77, 77);

                if (percentagInt <= 25)
                {
                    gr.FillPie(new SolidBrush(Color.FromArgb(226, 226, 226)), rectChar, 270 + (percentagInt / 5) * 18, 90 - (percentagInt / 5) * 18);
                    gr.FillPie(new SolidBrush(Color.FromArgb(226, 226, 226)), rectChar, 0f, 270f);
                }
                else
                {
                    gr.FillPie(new SolidBrush(Color.FromArgb(226, 226, 226)), rectChar, 0 + (percentagInt / 5) * 18 - 90, 360 - (percentagInt / 5) * 18);
                }

                

                gr.FillEllipse(new SolidBrush(Color.White), 8, 8, 60, 60);
                
                
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                GraphicsPath gp = new GraphicsPath();
                
                Font f = new Font("Georgia", Convert.ToInt32(25 * 0.95), FontStyle.Regular);

                //int charOffset = 0;
                //int charWidth = 15;
                //int percentOffsetX = 0;
                //int percentOffsetY = 0;

                //foreach (char c in percentageString)
                //{
                //    percentOffsetX += charWidth;
                //    if (percentageString.Length == 1) percentOffsetX += 30 - charWidth/2;
                //    if (percentageString.Length == 2) percentOffsetX += 20 - charWidth/2;

                //    percentOffsetY += ((charOffset + 1) * 3);

                //    rectChar = new Rectangle(Convert.ToInt32(charOffset * charWidth), Convert.ToInt32(charOffset * 3), charWidth, 50);
                //    if (percentageString.Length == 1) rectChar.X += 30 - charWidth / 2;
                //    if (percentageString.Length == 2) rectChar.X += 20 - charWidth / 2;

                //    gp.AddString(c.ToString(), f.FontFamily, (int)f.Style, f.Size, rectChar, sf);
                //    charOffset += 1;

                //    if (charWidth != 15) charWidth = 15;
                //    if (c == '1') { charWidth = 13; percentOffsetX -= 2; }
                //    if (c == '0') { charWidth = 16; percentOffsetX += 2; }
                //}
                //percentOffsetY = percentOffsetY - percentageString.Length;

                //rectChar = new Rectangle(percentOffsetX + 8, percentOffsetY + 8, 18, 18);

                //gp.AddString("%", f.FontFamily, (int)f.Style, 17, rectChar, sf);
                gp.AddString(percentageString + "%", f.FontFamily, (int)f.Style, f.Size, rectChar, sf);
                //gp.AddString("%", f.FontFamily, (int)f.Style, 17, rectChar, sf);

                using (Brush br = new SolidBrush(Color.Black))
                {
                    gr.FillPath(br, gp);
                }
                gp.Dispose();
                fonImg.Dispose();

            }

            return bmp;
        }
    }
}