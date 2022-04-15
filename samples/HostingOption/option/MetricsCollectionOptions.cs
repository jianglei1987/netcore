using HostingOption;
using System.Net;
public class MetricsCollectionOptions
{
    public TimeSpan CaptureInterval { set; get; }

    public TransportType TransportType { set; get; }

    public Endpoint Endpoint { set; get; }
}