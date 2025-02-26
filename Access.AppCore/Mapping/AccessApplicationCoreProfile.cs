using Access.AppCore.Entities;
using Access.AppCore.Models.Banque;
using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Models.Societe;
using Access.AppCore.Models.SocieteAgence;
using Access.AppCore.Models.Ville;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;

namespace Access.AppCore.Mappages
{
    internal class AccessApplicationCoreProfile : Profile
    {
        public AccessApplicationCoreProfile()
        {
            SocieteProfile();
            SocieteAgenceProfile();
            GouvernoratProfile();
            CiteProfile();
            VilleProfile();
            BanqueProfile();
        }

        internal void SocieteProfile()
        {
            CreateMap<SocieteModel, Societe>().ReverseMap();
        }

        internal void SocieteAgenceProfile()
        {
            CreateMap<SocieteAgenceModel, SocieteAgence>()
                .ReverseMap();
        }

        internal void GouvernoratProfile()
        {
            CreateMap<GouvernoratModel, Gouvernorat>().ReverseMap()
                .ReverseMap();
        }

        internal void VilleProfile()
        {
            CreateMap<VilleModel, Ville>()
                .ReverseMap();
        }

        internal void CiteProfile()
        {
            CreateMap<CiteModel, Cite>()
                .ReverseMap();
        }

        internal void BanqueProfile()
        {
            CreateMap<BanqueModel, Banque>()
                .ReverseMap();
        }

    }
}
