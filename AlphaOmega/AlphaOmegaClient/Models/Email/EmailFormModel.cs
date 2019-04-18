using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlphaOmegaClient.Models.Email
{
    public class EmailFormModel
    {
        [Required]
        public string FromName { get; set; }
        [Required]
        public string FromEmail { get; set; }
        [Required]
        public string Message { get; set; }
    }
}