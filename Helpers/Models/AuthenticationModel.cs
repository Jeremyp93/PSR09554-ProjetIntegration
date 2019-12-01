using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpers.Models
{
    public class AuthenticationModel
    {
        public string id { get; set; }

        public string username { get; set; }

        public string hash { get; set; }
        public string role { get; set; }
    }
}