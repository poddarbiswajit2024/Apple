using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;

namespace Apple_Bss.CodeFile
{
    public class ImageManage
    {
        public static string ResizeAndSaveImage(String pStrImageFileName, String pStrSuffix, Int32 width, String strPath)
        {
           // bool statusResized = true;
            string newfilename =String.Empty;
            try
            {
                String fileNamePart = pStrImageFileName.Substring(0, pStrImageFileName.IndexOf('.')) + pStrSuffix;
                String fileExtension = pStrImageFileName.Substring(pStrImageFileName.IndexOf('.') + 1, (pStrImageFileName.Length - 1) - (pStrImageFileName.Substring(0, pStrImageFileName.IndexOf('.')).Length));


                //String newfilename = fileNamePart + "." + fileExtension;
                newfilename = fileNamePart + "." + fileExtension;
                Page newserver = new Page();
                Bitmap img = (Bitmap)Bitmap.FromFile(newserver.Server.MapPath(strPath + pStrImageFileName));
                ImageFormat imageFormat = img.RawFormat;

                //TRYING TO GET THE ASPECT RATIO RIGHT
                Double aRatio = Convert.ToDouble(width) / Convert.ToDouble(img.Width);
                Double nHeight = aRatio * img.Height;
                //BELOW HEIGHT has been replaced with nHeight

                Size newSize = new Size(width, (Int32)nHeight);             
                Bitmap outputimg = new Bitmap(img, newSize.Width, newSize.Height);

                Graphics resizer = null;
                resizer = Graphics.FromImage(outputimg);
                resizer.InterpolationMode = InterpolationMode.HighQualityBicubic;
                resizer.DrawImage(img, 0, 0, newSize.Width, newSize.Height);
                outputimg.Save(newserver.Server.MapPath((strPath + newfilename)), imageFormat);
               
            }

            catch (Exception)
            {
                //statusResized = false;
                //newfilename = null;
            }
            return newfilename;
        }
    }
}
