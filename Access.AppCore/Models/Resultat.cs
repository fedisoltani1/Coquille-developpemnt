using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.AppCore.Models
{
    public class Resultat
    {
        private readonly List<Message> _messages = new();

        protected Resultat(bool succes, params Message[] messages)
        {
            Succes = succes;

            if (!Succes)
            {
                if (messages is null || !messages.Any())
                {
                    throw new ArgumentException("Un message est requis en cas d'échec.");
                }

                _messages.AddRange(messages);
            }
        }

        public bool Succes { get; }

        public bool Echec => !Succes;

        public IReadOnlyList<Message> Messages => _messages;

        public static Resultat Success() => new (true);

        public static Resultat Fail(Message message) => new (false, message);

        public static Resultat Fail(string message) => new (false, new Message(message));

        public static Resultat Fail(string code, string message) => new (false, new Message(code, message));

        public static Resultat Fail(params Message[] messages) => new (false, messages);
    }
}
