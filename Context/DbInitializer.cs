using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using gateway_devices.Model;
using System.Collections.Generic;

namespace gateway_devices.Context
{
    public class DbInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<GatewayDbContext>();
                context.Database.EnsureCreated();
                // Look for any gateways.
                if (context.Gateways != null && context.Gateways.Any())
                {
                    return; // DB has been seeded 
                }

                var gateways = new List<Gateway>() {
                    new Gateway{SerialNumber="G01HNOF1DEV", Name="Gateway1", IPAddress="10.1.4.1",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" }
                    }},
                    new Gateway{SerialNumber="G02HNOF2DEV", Name="Gateway2", IPAddress="10.1.4.2",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                    new Gateway{SerialNumber="G03HNOF3DEV", Name="Gateway3", IPAddress="10.1.4.3",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                    new Gateway{SerialNumber="G04HNOF4DEV", Name="Gateway4", IPAddress="10.1.4.4",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Offline" }
                    }},
                    new Gateway{SerialNumber="G05HNOF5DEV", Name="Gateway5", IPAddress="10.1.4.5",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Offline" }
                    }},
                    new Gateway{SerialNumber="G06HNOF6DEV", Name="Gateway6", IPAddress="10.1.4.6",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                    new Gateway{SerialNumber="G07HNOF7DEV", Name="Gateway7", IPAddress="10.1.4.7",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                     new Gateway{SerialNumber="G08HNOF8DEV", Name="Gateway8", IPAddress="10.1.4.8",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                    new Gateway{SerialNumber="G09HNOF9DEV", Name="Gateway9", IPAddress="10.1.4.9",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" }
                    }},
                     new Gateway{SerialNumber="G010HNOF10DEV", Name="Gateway10", IPAddress="10.1.4.10",
                    Devices = new List<Device>()
                    {
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Lenovo", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" },
                        new Device { Vendor="At&t", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Samsung", CreatedDate=System.DateTime.Now, Status="Online" },
                        new Device { Vendor="Apple", CreatedDate=System.DateTime.Now, Status="Offline" }
                    }}
                };


                context.Gateways.AddRange(gateways);
                context.SaveChanges();
            }
        }
    }
}