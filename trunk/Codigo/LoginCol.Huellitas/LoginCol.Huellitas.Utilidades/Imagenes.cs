using SoundInTheory.DynamicImage.Filters;
using SoundInTheory.DynamicImage.Fluent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Utilidades
{
    public class Imagenes
    {
        public static byte[] RedimensionarImagen(String path, int width, int height)
        {
            Bitmap imgIn = new Bitmap(path);
            double y = imgIn.Height;
            double x = imgIn.Width;

            double factor = 1;
            if (width > 0)
            {
                factor = width / x;
            }
            else if (height > 0)
            {
                factor = height / y;
            }
            System.IO.MemoryStream outStream = new System.IO.MemoryStream();
            Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

            // Set DPI of image (xDpi, yDpi)
            imgOut.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(imgOut);
            g.Clear(Color.White);
            g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)),
              new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            imgOut.Save(outStream, getImageFormat(path));
            return outStream.ToArray();
        }

        /// <summary>
        /// Redimensiona las imagenes
        /// </summary>
        /// <param name="rutaOriginal"></param>
        /// <param name="nuevaRuta"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        //public static bool RedimensionarImagen(String rutaOriginal, string nuevaRuta, int width, int height)
        //{
        //    try
        //    {
        //        //Si el archivo existe realiza el backup del archivo
        //        if (File.Exists(nuevaRuta))
        //        {
        //            Archivos.RealizarBackupArchivo(nuevaRuta);
        //        }

        //        ImageLayerBuilder image = LayerBuilder.Image
        //                     .SourceFile(rutaOriginal)
        //                     //.WithFilter(FilterBuilder.Resize.To(width, height, ResizeMode.Uniform));
        //                     .WithFilter(FilterBuilder.Resize.ToWidth(width));

        //        image.Source
        //            .GetBitmap().Save(nuevaRuta);

        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        LogErrores.RegistrarError(e);
        //        return false;
        //    }
        //}

        private static string getContentType(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return "Image/bmp";
                case ".gif": return "Image/gif";
                case ".jpg": return "Image/jpeg";
                case ".png": return "Image/png";
                default: break;
            }
            return "";
        }

        private static ImageFormat getImageFormat(String path)
        {
            switch (Path.GetExtension(path))
            {
                case ".bmp": return ImageFormat.Bmp;
                case ".gif": return ImageFormat.Gif;
                case ".jpg": return ImageFormat.Jpeg;
                case ".png": return ImageFormat.Png;
                default: break;
            }
            return ImageFormat.Jpeg;
        }
    }
}
