using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FindFunder.Core.Domain.Exceptions
{
    public class ErrorDeatils
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public override string ToString()=>JsonSerializer.Serialize(this);
    }
}
