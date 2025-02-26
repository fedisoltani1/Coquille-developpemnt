using Access.AppCore.Entities;
using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models.SocieteAgence;
using Access.Infrastructure.Helpers;
using Access.Web.Modeles.Gouvernorat;
using Access.Web.Modeles.SocieteAgence;
using Access.Web.Modeles.Ville;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Access.Web.Controllers
{
    public class SocieteAgenceController(ISocieteAgenceService societeAgenceService, IMapper mapper, ILogger<SocieteAgenceController> logger) : Controller
    {
        [BindProperty]
        public SocieteAgenceViewModel SocieteAgence { get; set; }

        public async Task<IActionResult> Index()
        {
            var societeAgence = await societeAgenceService.ObtenirTousLesSocieteAgence();

            if (societeAgence == null || !societeAgence.Any())
            {
                return View(new List<SocieteAgenceViewModel>());
            }

            var societeAgences = mapper.Map<List<SocieteAgenceModel>, List<SocieteAgenceViewModel>>(societeAgence);

            return View(societeAgences);
        }

        public async Task<IActionResult> Update(int id)
        {
            var agence = await societeAgenceService.ObtenirSocieteAgence(id);

            if (agence == null)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "L'agence n'existe pas.",
                });
            }

            var societeAgenceViewModel = mapper.Map<SocieteAgenceViewModel>(agence.Valeur);

            return View(societeAgenceViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocieteAgenceViewModel societeAgenceViewModel)
        {
            if (societeAgenceViewModel == null)
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
                var societeAgenceModel = mapper.Map<SocieteAgenceModel>(societeAgenceViewModel);
                var resultat = await societeAgenceService.AjouterSocieteAgence(societeAgenceModel);

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
                    Message = "Agence ajoutée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la création de l'agence.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(SocieteAgenceViewModel societeAgenceViewModel)
        {
            if (societeAgenceViewModel == null)
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
                var societeAgenceModel = mapper.Map<SocieteAgenceModel>(societeAgenceViewModel);
                var resultat = await societeAgenceService.ModifierSocieteAgence(societeAgenceModel);

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
                    Message = "Agence modifiée avec succès.",
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la modification de l'agence.");
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur inattendue s'est produite. Veuillez réessayer.",
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var agence = await societeAgenceService.ObtenirSocieteAgence(id);
                if (agence == null)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = "Cette agence n'existe pas.",
                    });
                }

                var result = await societeAgenceService.SupprimerSocieteAgence(id);
                if (result.Succes)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = true,
                        Message = "Agence supprimée avec succès.",
                    });
                }
                else
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = "Une erreur s'est produite lors de la suppression de l'agence.",
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la suppression de l'agence avec ID {Id}", id);

                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur interne s'est produite. Veuillez réessayer plus tard.",
                });
            }
        }
    }
}
