using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.AppCore.Models
{
    public sealed class Message
    {
        public Message(string code, string message)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(message));
            Code = code;
            Contenu = message;
        }

        public Message(string message)
            : this(default!, message)
        {
        }

        public string Code { get; }

        public string Contenu { get; }
    }
}
