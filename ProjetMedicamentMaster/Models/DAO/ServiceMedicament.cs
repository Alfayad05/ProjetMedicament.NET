using Microsoft.AspNetCore.Mvc;
using System.Data;
using ProjetMedicament.Models.MesExceptions;
using ProjetMedicament.Models.Persistance;
using System;
using ProjetMedicament.Models.Metier;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjetMedicament.Models.DAO
{
    public class ServiceMedicament : Controller
    {
        public static DataTable GetListeMedicament()
        {
            DataTable mesMedicaments;
            Serreurs er = new Serreurs("Erreur sur lecture des Medicaments.", "Medicament.getListeMedicament()");
            try
            {
                string mysql = "SELECT medicament.id_medicament, medicament.id_famille ,famille.lib_famille, medicament.nom_commercial, type_individu.lib_type_individu, dosage.qte_dosage, dosage.unite_dosage, prescrire.posologie "
                    + " FROM medicament "
                    + " JOIN famille ON medicament.id_famille = famille.id_famille "
                    + " JOIN prescrire ON medicament.id_medicament = prescrire.id_medicament "
                    + " JOIN dosage ON prescrire.id_dosage = dosage.id_dosage "
                    + " JOIN type_individu ON prescrire.id_type_individu = type_individu.id_type_individu";



                mesMedicaments = DBInterface.Lecture(mysql, er);

                return mesMedicaments;
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }

        public static Prescrire GetunMedicament(string id)
        {
            DataTable dt = null;
            Prescrire unePrescription = null;
            Serreurs er = new Serreurs("Erreur sur lecture des Mangas", "ServiceManga-getUnManga()");
            try
            {
                // Récupérer les informations du médicament
                string mysql = "SELECT id_dosage, id_medicament, id_type_individu, posologie ";
                mysql += "FROM prescrire ";
                mysql += "WHERE id_medicament = " + id;

                dt = DBInterface.Lecture(mysql, er);

                if (dt != null && dt.Rows.Count > 0)
                {
                    unePrescription = new Prescrire();
                    DataRow dataRow = dt.Rows[0];
                    unePrescription.Id_dosage = int.Parse(dataRow[0].ToString());
                    unePrescription.Id_medicament = int.Parse(dataRow[1].ToString());
                    unePrescription.Id_type_individu = int.Parse(dataRow[2].ToString());
                    unePrescription.Posologie = dataRow[3].ToString();

                    return unePrescription;
                }
                else
                {
                    return null;
                }
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }

        public static void UpdatePrescrire(Prescrire unP)
        {
            Serreurs er = new Serreurs("Erreur sur la mise à jour d'une prescription.", "Prescrire.update()");
            string requete = "UPDATE prescrire " +
                             "SET id_dosage = " + unP.Id_dosage + ", " +
                                 "id_type_individu = " + unP.Id_type_individu + ", " +
                                 "posologie = '" + unP.Posologie + "' " +
                             "WHERE id_medicament = " + unP.Id_medicament;

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }


        public static void InsertMedicament(Prescrire unP)
        {
            Serreurs er = new Serreurs("Erreur sur l'insertion d'un Medicament.", "Medicament.insert()");
            string requete = "INSERT INTO prescrire (id_dosage, id_medicament, id_type_individu, posologie) " +
                             "VALUES (" + unP.Id_dosage + ", '" +
                                 unP.Id_medicament + "', " +
                                 unP.Id_type_individu + ", '" +
                                 unP.Posologie +
                                  "')";

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }


        public static void DeleteMedicament(Prescrire unP)
        {
            Serreurs er = new Serreurs("Erreur sur la suppression d'un Medicament.", "Medicament.delete()");
            string requete = "DELETE FROM prescrire " +
                             "WHERE id_medicament = " + unP.Id_medicament;

            try
            {
                DBInterface.Execute_Transaction(requete);
            }
            catch (MonException erreur)
            {
                throw erreur;
            }
        }

        public static SelectList GetNomsCommerciaux()
        {
            Serreurs er = new Serreurs("Erreur sur lecture des noms commerciaux.", "ServiceMedicament.GetNomsCommerciaux()");
            try
            {
                string mysql = "SELECT id_medicament, nom_commercial FROM medicament";
                DataTable mesMedicaments = DBInterface.Lecture(mysql, er);

                return new SelectList(mesMedicaments.AsEnumerable(), "id_medicament", "nom_commercial");
            }
            catch (MonException e)
            {
                throw new MonException(er.MessageUtilisateur(), er.MessageApplication(), e.Message);
            }
        }
    }
}