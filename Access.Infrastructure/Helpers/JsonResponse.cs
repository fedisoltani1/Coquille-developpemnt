using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.Infrastructure.Helpers
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; } = string.Empty;

        public object? Data { get; set; } = null;
    }
}
