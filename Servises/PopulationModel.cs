namespace Services
{
    public class PopulationModel
    {
        public string CountryName { get; set; }
        public int Population { get; set; }
        public string YearlyChange { get; set; }

        public int NetChange { get; set; }
        public int Density { get; set; }
        public int LandArea { get; set; }
        public double FertRate { get; set; }
        public int MedAge { get; set; }
        public string UrbanPop { get; set; }
        public string WorldShare { get; set; }
    }
}
