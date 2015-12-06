using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiveO.Services
{
    public static class ByteToImage
    {
        public static object ConvertToImage(byte[] img)
        {
            var base64 = Convert.ToBase64String(img);
            var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
            return imgSrc;
        }
    }
}