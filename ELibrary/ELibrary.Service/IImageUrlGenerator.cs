using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IImageUrlGenerator
    {
        string CreateTagImageUrl(string prefix, string imageName);
        string CreateBookImageUrl(string prefix, string imageName);
    }
}
