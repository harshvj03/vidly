using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {

        public byte Id { get; set; }
        public short signUpFee { get; set; }
        public byte durationInMonth { get; set; }
        public byte  discountRate { get; set; }

        public String Name { get; set; }
    }
}