namespace ProjetMedicament.Models.Metier
{
    public class Medicament
    {
        private int id_medicament;
        private int id_famille;
        private string depot_legal;
        private string nom_commercial;
        private string effets;
        private string contre_indication;
        private double prix_echantillon;

        public int Id_medicament { get => id_medicament; set => id_medicament = value; }
        public int Id_famille { get => id_famille; set => id_famille = value; }
        public string Depot_legal { get => depot_legal; set => depot_legal = value; }
        public string Nom_commercial { get => nom_commercial; set => nom_commercial = value; }
        public string Effets { get => effets; set => effets = value; }
        public string Contre_indication { get => contre_indication; set => contre_indication = value; }
        public double Prix_echantillon { get => prix_echantillon; set => prix_echantillon = value; }

    }

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
