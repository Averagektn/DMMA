namespace lab4
{
    public sealed class Perceptron
    {
        // к образу добавить в конец 1
        private List<List<int>> WeightMatrices;
        private List<Class> Classes;

        public Perceptron(int classesNum, int objectsNum, int distinctionsNum)
        {
            WeightMatrices = new();
            for (int i = 0; i < classesNum; i++)
            {
                WeightMatrices.Add(new List<int>());
            }
            Classes = KAverage.Get_DividedClasses(classesNum, objectsNum, distinctionsNum);
            Console.WriteLine();
        }

        public int[][] Get_SepartingFunctions()
        {
            throw new NotImplementedException();
        }

        private int[][] Generate_Sample()
        {
            throw new NotImplementedException();
        }

        private void Initialize_Classes()
        {
            throw new NotImplementedException ();
        }

        private void Update_WeightMatrices()
        {
            throw new NotImplementedException();
        }
       
    }
}
