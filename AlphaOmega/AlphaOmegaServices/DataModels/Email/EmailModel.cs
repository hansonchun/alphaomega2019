using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlphaOmegaServices.DataModels.Email
{
    public class EmailModel
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string Message { get; set; }
    }
}