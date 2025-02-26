using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models.Cite;
using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Models.Ville;
using Access.Infrastructure.Helpers;
using Access.Web.Modeles.Cite;
using Access.Web.Modeles.Gouvernorat;
using Access.Web.Modeles.Localisation;
using Access.Web.Modeles.Ville;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace Access.Web.Controllers
{
    public class LocalisationController(IGouvernoratService gouvernoratService, ICiteService citeService, IVilleService villeService, IMapper mapper, ILogger<LocalisationController> logger) : Controller
    {

        [BindProperty]
        public GouvernoratViewModel Gouvernorat { get; set; }

        public async Task<IActionResult> Index()
        {

            try
            {
                var gouvernorats = await gouvernoratService.ObtenirTousLesGouvernorats();

                if (gouvernorats == null)
                {
                    gouvernorats = new List<GouvernoratModel>();
                }

                var villes = await villeService.ObtenirToutesLesVilles();
                if (villes == null)
                {
                    villes = new List<VilleModel>();
                }

                var cites = await citeService.ObtenirToutesLesCites();
                if (cites == null)
                {
                    cites = new List<CiteModel>();
                }


                ViewData["Gouvernorats"] = new SelectList(gouvernorats, "Id", "Intitule");
                ViewData["Villes"] = new SelectList(villes, "Id", "Intitule");
                var viewModel = new LocalisationViewModel
                {
                    Gouvernorats = mapper.Map<List<GouvernoratViewModel>>(gouvernorats) ?? new List<GouvernoratViewModel>(),
                    Villes = mapper.Map<List<VilleViewModel>>(villes) ?? new List<VilleViewModel>(),
                    Cites = mapper.Map<List<CiteViewModel>>(cites) ?? new List<CiteViewModel>(),
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors du chargement des localisations.");
                return View("Error");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AjouterGouvernorat(GouvernoratViewModel gouvernoratViewModel)
        {
            if (gouvernoratViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var gouvernoratModel = mapper.Map<GouvernoratModel>(gouvernoratViewModel);

                var resultat = await gouvernoratService.AjouterGouvernorat(gouvernoratModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Gouvernorat ajouté avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de l'ajout du Gouvernorat.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ModifierGouvernorat(GouvernoratViewModel gouvernoratViewModel)
        {
            if (gouvernoratViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var gouvernoratModel = mapper.Map<GouvernoratModel>(gouvernoratViewModel);
                var resultat = await gouvernoratService.ModifierGouvernorat(gouvernoratModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Gouvernorat modifié avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la modification du Gouvernorat.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerGouvernorat(int id)
        {
            if (id <= 0)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Gouvernorat n'existe pas.",
                });
            }

            try
            {
                var resultat = await gouvernoratService.SupprimerGouvernorat(id);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Gouvernorat supprimé avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression du Gouvernorat.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreerVille()
        {
            var gouvernorats = await gouvernoratService.ObtenirTousLesGouvernorats();

            if (gouvernorats == null || !gouvernorats.Any())
            {
                return View(); 
            }

            ViewData["Gouvernorats"] = new SelectList(gouvernorats, "Id", "Intitule");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AjouterVille(VilleViewModel villeViewModel)
        {
            if (villeViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var villeModel = mapper.Map<VilleModel>(villeViewModel);
                var resultat = await villeService.CreerVille(villeModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Ville ajoutée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de l'ajout de la Ville.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ModifierVille(VilleViewModel villeViewModel)
        {
            if (villeViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var villeModel = mapper.Map<VilleModel>(villeViewModel);
                var resultat = await villeService.ModifierVille(villeModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Ville modifiée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la modification de la ville.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerVille(int id)
        {
            if (id <= 0)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Ville n'existe pas.",
                });
            }

            try
            {
                var resultat = await villeService.SupprimerVille(id);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Ville supprimé avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression du ville.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AjouterCite(CiteViewModel citeViewModel)
        {
            if (citeViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var citeModel = mapper.Map<CiteModel>(citeViewModel);

                var resultat = await citeService.AjouterCite(citeModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Cite ajoutée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de l'ajout de la cite.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ModifierCite(CiteViewModel citeViewModel)
        {
            if (citeViewModel == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Les données envoyées sont nulles.",
                });
            }

            if (!ModelState.IsValid)
            {
                var erreurs = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", erreurs),
                });
            }

            try
            {
                var citeModel = mapper.Map<CiteModel>(citeViewModel);
                var resultat = await citeService.ModifierCite(citeModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "Cité modifiée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la modification de la cité avec l'ID {Id}.", citeViewModel.Id);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SupprimerCite(int id)
        {
            if (id <= 0)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "cité n'existe pas.",
                });
            }

            try
            {
                var resultat = await citeService.SupprimerCite(id);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse
                {
                    IsSuccess = true,
                    Message = "cité supprimé avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression du cité.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }


    }
}
