using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetMedicament.Models.DAO;
using ProjetMedicament.Models.MesExceptions;
using ProjetMedicament.Models.Metier;

namespace ProjetMedicament.Controllers
{
    public class MedicamentController : Controller
    {
        public IActionResult Index()
        {
            System.Data.DataTable mesMedicament = null;

            try
            {
                mesMedicament = ServiceMedicament.GetListeMedicament();
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la récupération des medicaments : " + e.Message);
            }
            return View(mesMedicament);
        }

        public IActionResult Ajouter()
        {
            var prescrire = new Prescrire(); // Initialisez un nouvel objet Resultat
            ViewBag.NomsCommerciaux = ServiceMedicament.GetNomsCommerciaux();
            

            
            return View(prescrire); // Passez le modèle à la vue
        }


        [HttpPost]
        public IActionResult Ajouter(Prescrire unR)
        {
            try
            {
                ServiceMedicament.InsertMedicament(unR);
                return RedirectToAction("Index");
            }
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de l'ajout du médicament : " + e.Message);
                return View(unR);
            }
        }

        public IActionResult Modifier(string id)
        {
            Prescrire infosMedicament = null;
            try
            {
                infosMedicament = ServiceMedicament.GetunMedicament(id);
                if (infosMedicament == null)
                {
                    return NotFound();
                }
                return View(infosMedicament);
            }
            catch (MonException e)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Modifier(Prescrire unP)
        {
            try
            {
                ServiceMedicament.UpdatePrescrire(unP);
                return RedirectToAction("Index");
            }             
            catch (MonException e)
            {
                ModelState.AddModelError("Erreur", "Erreur lors de la modification du médicament : " + e.Message);
                return View(unP);
            }
        }
    }

}
