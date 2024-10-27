

using System.Net;
using System.Text.Json;

namespace Core.Entities;

public class ReturnModel <TData>
{
    public TData Data { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public int Status { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
