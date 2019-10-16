using System.Threading;
using Poolgramming.Data;

namespace Poolgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var image = ImageSource.GetImage();

                Thread.Sleep(1000);
            }
        }
    }
}
