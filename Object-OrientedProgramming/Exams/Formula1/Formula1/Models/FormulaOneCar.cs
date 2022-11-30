using Formula1.Models.Contracts;

namespace Formula1.Models
{
    public static class FormulaOneCar : IFormulaOneCar
    {
        private string model;

        public string Model
        {
            get { return model; }
            set 
            {
                
            }
        }

        public int Horsepower => throw new System.NotImplementedException();

        public double EngineDisplacement => throw new System.NotImplementedException();

        public double RaceScoreCalculator(int laps)
        {
            throw new System.NotImplementedException();
        }
    }
}
