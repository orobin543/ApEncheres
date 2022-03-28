using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ApEnchere.Interfaces
{
    interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();

    }
}
