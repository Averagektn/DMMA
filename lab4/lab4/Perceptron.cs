namespace lab4
{
    public sealed class Perceptron
    {
        private List<List<int>> WeightMatrices;
        private List<Class> Classes;

        private int _classesNum;
        private int _objectsNum;
        private int _distinctionsNum;

        public Perceptron(int classesNum, int objectsNum, int distinctionsNum)
        {
            _classesNum = classesNum;
            _objectsNum = objectsNum;
            _distinctionsNum = distinctionsNum;

            WeightMatrices = new();
            for (int i = 0; i < classesNum; i++)
            {
                WeightMatrices.Add(new List<int>());
            }
            Classes = KAverage.Get_DividedClasses(classesNum, objectsNum, distinctionsNum);
            Extend_Objects();
            Generate_WeightMatrices();
        }

        public List<List<int>> Get_SepartingFunctions()
        {
            bool isAnotherUpdate = true;
            while(isAnotherUpdate)
            {
                isAnotherUpdate = Update_WeightMatrices();
            }

            return Generate_SeparatingFunctions();
        }

        private void Generate_WeightMatrices()
        {
            throw new NotImplementedException();
        }

        private void Extend_Objects()
        {
            _distinctionsNum++;
            throw new NotImplementedException();
        }

        private bool Update_WeightMatrices()
        {
            throw new NotImplementedException();
        }

        private List<List<int>> Generate_SeparatingFunctions()
        {
            throw new NotImplementedException();
        }

    }
}
