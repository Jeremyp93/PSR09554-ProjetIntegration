using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class CUtil
    {
        public static string GetValueBaseOnKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
