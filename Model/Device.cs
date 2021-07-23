using System;

namespace gateway_devices.Model
{
    public class Device
    {
        public long Id { get; set; }
        public string Vendor { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }
    }
}