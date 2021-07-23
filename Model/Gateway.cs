using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace gateway_devices.Model
{
    public class Gateway
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }

        [MaxLength(10)]
        public List<Device> Devices { get; set; }
    }
}