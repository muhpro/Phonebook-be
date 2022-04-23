using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook_be.Utilities
{
    public interface IAppSettings
    {
        string DevConnection { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string DevConnection { get; set; }
    }
}
