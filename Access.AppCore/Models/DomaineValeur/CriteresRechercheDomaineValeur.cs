using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.AppCore.Models.DomaineValeur
{
    public class CriteresRechercheDomaineValeur
    {
        public string Code { get; set; }

        public string DescriptionCourte { get; set; }

        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }
    }
}
