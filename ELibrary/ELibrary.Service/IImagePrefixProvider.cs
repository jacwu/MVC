using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Service
{
    public interface IImagePrefixProvider
    {
        string TagImagePrefix();
        string BookImagePrefix();
    }
}
