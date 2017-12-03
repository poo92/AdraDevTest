using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AccountBalance
    {
        public int year { get; set; }
        public int month { get; set; }
        public float rnd { get; set; }
        public float canteen { get; set; }
        public float ceoCar { get; set; }
        public float marketing { get; set; }
        public float parking { get; set; }
        public int uId { get; set; }
    }
}