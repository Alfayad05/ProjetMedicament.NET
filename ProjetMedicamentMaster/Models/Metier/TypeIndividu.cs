using Microsoft.AspNetCore.Mvc;

namespace ProjetMedicamentMaster.Models.Metier
{
    public class TypeIndividu
    {
        private int id_type_individu;
        private string lib_type_individu;

        public int Id_type_individu
        {
            get => id_type_individu;
            set => id_type_individu = value;
        }

        public string Lib_type_individu
        {
            get => lib_type_individu;
            set => lib_type_individu = value;
        }
    }
}
