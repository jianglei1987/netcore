﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostingOption
{
    public interface IMetricsDeliverer 
    {
       Task DeliverAsync(PerformanceMetrics counter);
    }
}
