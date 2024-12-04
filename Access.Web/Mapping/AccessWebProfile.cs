using Access.AppCore.Entities;
using Access.AppCore.Models.DomaineValeur;
using Access.Web.Modeles.DomaineValeur;
using AutoMapper;

namespace Access.Web.Mapping
{
    public class AccessWebProfile : Profile
    {
        public AccessWebProfile()
        {
            DomaineValeursProfile();
        }

        internal void DomaineValeursProfile()
        {
            // DomaineValeurModel to DomaineValeur
            CreateMap<DomaineValeurModel, DomaineValeur>().ReverseMap();

            // DomaineValeurElementModel to DomaineValeurElement
            CreateMap<DomaineValeurElementModel, DomaineValeurElement>().ReverseMap();

            // DomaineValeurModel to DomaineValeurViewModel
            CreateMap<DomaineValeurModel, DomaineValeurViewModel>()
            .ForMember(dest => dest.NombreElement, opt => opt.MapFrom(src => src.Elements.Count)).ReverseMap();

            // DomaineValeurElementModel to DomaineValeurElementViewModel
            CreateMap<DomaineValeurElementModel, DomaineValeurElementViewModel>().ReverseMap();

            // CriteresRechercheDomaineValeur to CriteresRechercheDomaineValeurViewModel
            CreateMap<CriteresRechercheDomaineValeur, CriteresRechercheDomaineValeurViewModel>().ReverseMap();
        }
    }
}
