using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaOmegaServices.DataModels.Email
{
    public class EmailResult
    {
        public bool Success { get; set; }
        public string Exception { get; set; }
    }
}