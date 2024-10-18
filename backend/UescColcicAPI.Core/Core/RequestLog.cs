public class RequestLog
{
    public int Id { get; set; }
    public string ClientIp { get; set; }
    public bool HasJwtToken { get; set; }
    public DateTime RequestTime { get; set; }
    public string RequestMethod { get; set; }
    public string RequestUrl { get; set; }
    public long TotalProcessingTime { get; set; }
}
