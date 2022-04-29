using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food.Entity
{
    public class Device
    {

        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public string deviceCountry { set; get; }
        public string deviceCompanyName { set; get; }
        public string deviceCity { set; get; }
        public string deviceState { set; get; }
        public string devicePostalCode { set; get; }
        public string devicePhoneNumber { set; get; }
        public string deviceAddress1 { set; get; }
        public string deviceAddress2 { set; get; }
        public List<CartsDevice> CartsDeviceD { get; set; }



    }
}
