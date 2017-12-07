using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.ApiModels
{
    public class UserRequest
    {
        public int year { get; set; }
        public int month { get; set; }
        public int startYear { get; set; }
        public int startMonth { get; set; }
        public int endYear { get; set; }
        public int endMonth { get; set; }

    }
}