using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistances;
using Access.AppCore.Interfaces.Persistances.Services;
using Access.AppCore.Interfaces.Persistence;
using Access.AppCore.Models;
using Access.AppCore.Models.DomaineValeur;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Access.AppCore.Services
{
    public class DomaineValeurService : IDomaineValeurService
    {
        private readonly IRepository<DomaineValeur, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DomaineValeurService(
           IRepository<DomaineValeur, int> domaineValeurRepository,
           IUnitOfWork unitOfWork,
           IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(nameof(domaineValeurRepository));
            ArgumentNullException.ThrowIfNull(nameof(unitOfWork));
            _repository = domaineValeurRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DomaineValeurModel>> ObtenirAsync()
        {
            var liste = await _repository.ToListAsync(x => x.Include(r => r.Elements.OrderBy(r => r.SequenceAffichage)));
            return _mapper.Map<List<DomaineValeur>, List<DomaineValeurModel>>(liste);
        }

        public async Task<Resultat<DomaineValeurModel>> ObtenirAsync(int id)
        {
            var entite = await _repository.FirstOrDefaultAsync(x => x.Id == id, x => x.Include(r => r.Elements.OrderBy(r => r.SequenceAffichage)));
            if (entite == null)
            {
                return Resultat<DomaineValeurModel>.Fail(new Message("L'enregistrement demandé n'existe pas."));
            }

            return Resultat<DomaineValeurModel>.Success(_mapper.Map<DomaineValeur, DomaineValeurModel>(entite));
        }

        public async Task<List<DomaineValeurModel>> ObtenirAsync(CriteresRechercheDomaineValeur criteresRecherche)
        {
            var entites = await _repository.ToListAsync(
                                                        e => (string.IsNullOrWhiteSpace(criteresRecherche.Code) || e.Code.StartsWith(criteresRecherche.Code, StringComparison.CurrentCultureIgnoreCase)) &&
                                                        (string.IsNullOrWhiteSpace(criteresRecherche.DescriptionCourte) || e.DescriptionCourte.StartsWith(criteresRecherche.DescriptionCourte, StringComparison.CurrentCultureIgnoreCase)) &&
                                                        (criteresRecherche.DateDebut == null || e.DateDebut == criteresRecherche.DateDebut) &&
                                                        (criteresRecherche.DateFin == null || e.DateFin == criteresRecherche.DateFin),
                                                        x => x.Include(r => r.Elements.OrderBy(r => r.SequenceAffichage)));

            return _mapper.Map<List<DomaineValeur>, List<DomaineValeurModel>>(entites);
        }

        public async Task<Resultat<DomaineValeurModel>> ObtenirAvecCodeAsync(string code)
        {
            var entite = await _repository.FirstOrDefaultAsync(x => x.Code == code, x => x.Include(r => r.Elements.OrderBy(r => r.SequenceAffichage)));
            if (entite == null)
            {
                return Resultat<DomaineValeurModel>.Fail(new Message("L'enregistrement demandé n'existe pas."));
            }

            return Resultat<DomaineValeurModel>.Success(_mapper.Map<DomaineValeur, DomaineValeurModel>(entite));
        }

        public async Task<Resultat> AjouterAsync(DomaineValeurModel domaineValeur)
        {
            ArgumentNullException.ThrowIfNull(nameof(domaineValeur));
            var resultat = Valider(domaineValeur);

            if (resultat.Echec)
            {
                return resultat;
            }

            var nomExiste = await _repository.ExistAsync(x => x.Code == domaineValeur.Code);
            if (nomExiste)
            {
                return Resultat.Fail(new Message("Le nom doit être unique"));
            }

            _repository.Creer(_mapper.Map<DomaineValeurModel, DomaineValeur>(domaineValeur));

            resultat = await _unitOfWork.SauvegarderResultatAsync();
            if (resultat.Echec)
            {
                return resultat;
            }

            return Resultat.Success();
        }

        public async Task<Resultat> ModifierAsync(DomaineValeurModel domaineValeur)
        {
            ArgumentNullException.ThrowIfNull(nameof(domaineValeur));

            var resultat = Valider(domaineValeur);

            if (resultat.Echec)
            {
                return resultat;
            }

            var domaineExistant = await _repository.FirstOrDefaultAsync(x => x.Id == domaineValeur.Id, x => x.Include(r => r.Elements));

            if (domaineExistant == null)
            {
                return Resultat.Fail(new Message("L'enregistrement demandé n'existe pas."));
            }

            domaineExistant.Elements
                .ToList()
                .ForEach(el => _unitOfWork.Detacher(el));

            domaineExistant.Elements
                .Where(x => !domaineValeur.Elements.ConvertAll(r => r.Id).Contains(x.Id))
                .ToList()
                .ForEach(element => _unitOfWork.InscrireSupprime(element));

            _repository.Modifier(_mapper.Map(domaineValeur, domaineExistant));
            resultat = await _unitOfWork.SauvegarderResultatAsync();

            if (resultat.Echec)
            {
                return resultat;
            }

            return Resultat.Success();
        }

        public async Task<Resultat> SupprimerAsync(int id)
        {
            var entiteRepo = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (entiteRepo == null)
            {
                return Resultat.Fail(new Message("L'enregistrement demandé n'existe pas."));
            }

            _repository.Supprimer(entiteRepo);
            var resultat = await _unitOfWork.SauvegarderResultatAsync();
            if (resultat.Echec)
            {
                return resultat;
            }

            return Resultat.Success();
        }

        private static Resultat Valider(DomaineValeurModel domaineValeur)
        {
            if (domaineValeur.DateFin < domaineValeur.DateDebut)
            {
                return Resultat.Fail(new Message("La date fin doit être supèrieure ou égale à la date début."));
            }

            if (domaineValeur.Elements.GroupBy(r => r.Code).Any(g => g.Count() > 1))
            {
                return Resultat.Fail(new Message("Le code des éléments doit être unique."));
            }

            if (domaineValeur.Elements.GroupBy(r => r.DescriptionCourte).Any(g => g.Count() > 1))
            {
                return Resultat.Fail(new Message("La description courte des éléments doit être unique."));
            }

            if (domaineValeur.Elements.GroupBy(r => r.SequenceAffichage).Any(g => g.Count() > 1))
            {
                return Resultat.Fail(new Message("L'ordre d'affichage des éléments doit être unique."));
            }

            if (!domaineValeur.Elements.Any())
            {
                return Resultat.Fail(new Message("Le domaine des valeurs doit avoir au moins un élément."));
            }

            if (domaineValeur.Elements.Any(r => r.DateFin > domaineValeur.DateFin))
            {
                return Resultat.Fail(new Message("La date de fin d'un élément ne peut pas être supérieure à la date fin du domaine."));
            }

            if (domaineValeur.Elements.Any(r => r.DateDebut > r.DateFin))
            {
                return Resultat.Fail(new Message("La date de fin d'un élément ne peut pas être inférieure à la date de début."));
            }

            return Resultat.Success();
        }
    }
}
