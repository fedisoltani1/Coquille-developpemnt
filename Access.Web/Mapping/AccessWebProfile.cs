using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Models.Societe;
using Access.AppCore.Models.SocieteAgence;
using Access.AppCore.Models.Ville;
using Access.AppCore.Services;
using Access.Web.Modeles.Cite;
using Access.Web.Modeles.Gouvernorat;
using Access.Web.Modeles.Societe;
using Access.Web.Modeles.SocieteAgence;
using Access.Web.Modeles.Ville;
using AutoMapper;

namespace Access.Web.Mapping
{
    public class AccessWebProfile : Profile
    {
        public AccessWebProfile()
        {
            SocieteProfile();
            SocieteAgenceProfile();
            GouvernoratProfile();
            VilleProfile();
            CiteProfile();
        }

        internal void SocieteProfile()
        {
            CreateMap<SocieteModel, SocieteViewModel>().ReverseMap();
        }

        internal void SocieteAgenceProfile()
        {
            CreateMap<SocieteAgenceModel, SocieteAgenceViewModel>().ReverseMap();
        }

        internal void GouvernoratProfile()
        {
            CreateMap<GouvernoratModel, GouvernoratViewModel>()
               .ReverseMap();
        }

        internal void CiteProfile()
        {
            CreateMap<CiteModel, CiteViewModel>()
                .ReverseMap();
        }

        internal void VilleProfile()
        {
            CreateMap<VilleModel, VilleViewModel>()
                .ReverseMap();
        }
    }
}
