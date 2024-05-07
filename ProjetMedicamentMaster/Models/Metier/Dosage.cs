using Microsoft.AspNetCore.Mvc;

namespace ProjetMedicamentMaster.Models.Metier
{
    public class Dosage
    {
        private int id_dosage;
        private int qte_dosage;
        private string unite_dosage;

        public int Id_dosage
        {
            get => id_dosage;
            set => id_dosage = value;
        }

        public int Qte_dosage
        {
            get => qte_dosage;
            set => qte_dosage = value;
        }

        public string Unite_dosage
        {
            get => unite_dosage;
            set => unite_dosage = value;
        }
    }
}
