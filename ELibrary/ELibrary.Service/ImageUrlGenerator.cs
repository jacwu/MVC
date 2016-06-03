using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public class ImageUrlGenerator : IImageUrlGenerator
    {
        public string CreateBookImageUrl(string prefix, string imageName)
        {
            return prefix + imageName;
        }

        public string CreateTagImageUrl(string prefix, string imageName)
        {
            return prefix + imageName;
        }
    }
}
