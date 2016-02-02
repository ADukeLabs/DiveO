using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DiveO.Services
{
    public class ImageProcessor
    {
        public byte[] ImageToByteArray(HttpPostedFileBase file)
        {
            byte[] result;
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                result = ms.GetBuffer();
            }
            return result;
        }

        //public object ByteToImage(byte[] img)
        //{
        //    var base64 = Convert.ToBase64String(img);
        //    var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
        //    return imgSrc;
        //}

        //public List<byte[]> ImageCollection(HttpPostedFileBase file)
        //{
        //    List<byte[]> images = null;
        //    byte[] image = new ImageProcessor().ImageToByteArray(file);
        //    if (image != null)
        //        images.Add(image);
        //    return images;
        //} 
    }
}