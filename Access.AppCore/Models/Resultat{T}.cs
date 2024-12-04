using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.AppCore.Models
{
    public class Resultat<T> : Resultat
    {
        protected Resultat(bool succes, T valeur, params Message[] messages)

             : base(succes, messages)
        {
            Valeur = valeur;
        }

        public T Valeur { get; }

        public static Resultat<T> Success(T valeur) => new (true, valeur);

        public static new Resultat<T> Fail(Message message) => new Resultat<T>(false, default!, message);

        public static new Resultat<T> Fail(string message) => new Resultat<T>(false, default!, new Message(message));

        public static new Resultat<T> Fail(string code, string message) => new Resultat<T>(false, default!, new Message(code, message));

        public static new Resultat<T> Fail(params Message[] messages) => new (false, default!, messages.ToArray());
    }
}