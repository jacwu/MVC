using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public class ImagePrefixProvider : IImagePrefixProvider
    {
        public string BookImagePrefix()
        {
            return "http://images.localtest.me/images/books/";
        }

        public string TagImagePrefix()
        {
            return "http://images.localtest.me/images/tags/";
        }
    }
}
