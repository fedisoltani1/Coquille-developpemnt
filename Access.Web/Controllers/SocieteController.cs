using Access.AppCore.Interfaces.Persistence.Services;
using Access.AppCore.Models.Societe;
using Access.Infrastructure.Helpers;
using Access.Web.Modeles.Societe;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Access.Web.Controllers
{
    public class SocieteController(ISocieteService societeService, IMapper mapper, ILogger<SocieteController> logger) : Controller
    {
        [BindProperty]
        public SocieteViewModel Societe { get; set; }

        public async Task<IActionResult> Index()
        {
            var societeCourante = await societeService.ObtenirSocieteCourante();

            if (societeCourante == null)
            {
                return NotFound();
            }

            Societe = mapper.Map<SocieteModel, SocieteViewModel>(societeCourante);
            return View(Societe);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SocieteViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)),
                });
            }

            try
            {
                var societeModel = mapper.Map<SocieteViewModel, SocieteModel>(item);
                var resultat = await societeService.ModifierSociete(societeModel);

                if (resultat.Echec)
                {
                    return Json(new JsonResponse
                    {
                        IsSuccess = false,
                        Message = string.Join(" ", resultat.Messages.Select(m => m.Contenu)),
                    });
                }

                return Json(new JsonResponse { IsSuccess = true, Message = "Société modifiée avec succès." });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erreur lors de la mise à jour de la société avec ID {Id}.", item.Id);
                return Json(new JsonResponse
                {
                    IsSuccess = false,
                    Message = "Une erreur s'est produite lors de la sauvegarde des données.",
                });
            }
        }
    }
}
