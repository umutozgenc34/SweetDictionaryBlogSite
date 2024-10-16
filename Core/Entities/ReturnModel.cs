

using System.Net;

namespace Core.Entities;

public class ReturnModel <TData>
{
    public TData Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public int Status { get; set; }
}
