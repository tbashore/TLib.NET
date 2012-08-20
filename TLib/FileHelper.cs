using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcoSysTAASConfigurator
{
    public static class FileHelper
    {
        public static bool CanRead(string path)
        {
            try
            {
                using (var fs = System.IO.File.OpenRead(path))
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CanWrite(string path)
        {
            try
            {
                DateTime lastWriteTimeUtc = System.IO.File.GetLastWriteTimeUtc(path);
                System.IO.File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
