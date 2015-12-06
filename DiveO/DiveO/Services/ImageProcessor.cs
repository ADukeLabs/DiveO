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
    }
}