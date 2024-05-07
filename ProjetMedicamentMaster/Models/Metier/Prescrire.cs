using Microsoft.AspNetCore.Mvc;

namespace ProjetMedicamentMaster.Models.Metier
{
    public class Prescrire
    {
        private int id_dosage;
        private int id_medicament;
        private int id_type_individu;
        private string posologie;

        public int Id_dosage
        {
            get => id_dosage;
            set => id_dosage = value;
        }

        public int Id_medicament
        {
            get => id_medicament;
            set => id_medicament = value;
        }

        public int Id_type_individu
        {
            get => id_type_individu;
            set => id_type_individu = value;
        }

        public string Posologie
        {
            get => posologie;
            set => posologie = value;
        }
    }
}
