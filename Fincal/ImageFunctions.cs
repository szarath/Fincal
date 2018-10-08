using Google.Apis.Auth.OAuth2;
using Google.Apis.Http;
using Google.Apis.Services;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Fincal
{
    public abstract class ImageFunctions
    {
        public static string validateImage(byte[] imageByteArray)
        {
            byte[] newCompressedImage = null;
            if (IsValidImage(imageByteArray))
            {
                newCompressedImage = CompressImage(imageByteArray);
                return Convert.ToBase64String(newCompressedImage);
            }
            else
            {
                return " ";
            }
        }

        private static bool IsValidImage(byte[] bytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                    System.Drawing.Image.FromStream(ms);
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }


        private static byte[] CompressImage(byte[] image)
        {
            MemoryStream ms = new MemoryStream(image);
            MemoryStream tempMS = new MemoryStream();

            long size = ms.ToArray().Length;

            try
            {
                if (size > 512000)
                {
                    Bitmap bmp = (Bitmap)System.Drawing.Image.FromStream(ms);
                    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(Encoder.Quality, 50L);
                    myEncoderParameters.Param[0] = myEncoderParameter;
                    bmp.Save(tempMS, jpgEncoder, myEncoderParameters);
                    size = tempMS.ToArray().Length;
                }
                else
                {
                    return ms.ToArray();
                }
            }

            catch (ObjectDisposedException e)
            { }
            catch (Exception ex) { }
            finally
            {
                ms.Dispose();
            }
            return tempMS.ToArray();
        }
        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

       
    }
}