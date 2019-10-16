using System.Net;

namespace Poolgramming.Data
{
    public class ImageSource
    {
        private static string _imageUrl = "http://cam35.spiralsoft.local/axis-cgi/jpg/image.cgi";

        public static byte[] GetImage()
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData(_imageUrl);
            }
        }
    }
}
