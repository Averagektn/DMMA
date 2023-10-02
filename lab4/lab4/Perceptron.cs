using System.Text;

namespace lab4
{
    public sealed class Perceptron
    {
        private List<Class> Classes;
        private List<List<int>> WeightMatrices;

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
            Create_WeightMatrices();
        }

        private List<List<int>> Get_SepartingFunctions()
        {
            bool isAnotherUpdate = true;

            while(isAnotherUpdate)
            {
                isAnotherUpdate = Update_WeightMatrices();
            }

            return Create_SeparatingFunctions();
        }

        private void Create_WeightMatrices()
        {
            for (int i = 0; i < _classesNum; i++)
            {
                WeightMatrices.Add(new List<int>());
                for (int j = 0; j < _distinctionsNum; j++)
                {
                    WeightMatrices[i].Add(0);
                }
            }
        }

        private void Extend_Objects()
        {
            _distinctionsNum++;
            for (int i = 0; i < _classesNum; i++)
            {
                for (int j = 0; j < Classes[i].Objects.Count; j++)
                {
                    Classes[i].Objects[j].Distinctions.Add(1);
                }
            }
        }

        private bool Update_WeightMatrices()
        {
            throw new NotImplementedException();
        }

        private int Multiply_Vectors(List<int> vector_1, List<int> vector_2)
        {
            throw new NotImplementedException();
        }

        private List<List<int>> Create_SeparatingFunctions()
        {
            throw new NotImplementedException();
        }

        public string Get_Classes_String()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < _classesNum; i++)
            {
                sb.AppendLine($"Class " + (i + 1) + ":");

                for (int j = 0; j < Classes[i].Objects.Count; j++)
                {
                    sb.Append("\t{ ");
                    for (int k = 0; k < _distinctionsNum; k++)
                    {
                        sb.Append(Classes[i].Objects[j].Distinctions[k] + "; ");
                    }
                    sb.AppendLine(" }");
                }
            }

            return sb.ToString();
        }

        public string Get_SeparatingFunctions_String()
        {
            var separatingFunctions = Get_SepartingFunctions();
            var sb = new StringBuilder();

            for (int i = 0; i < _classesNum; i++)
            {
                sb.Append($"Function " + (i + 1) + ": ");

                for (int j = 0; j < _distinctionsNum; j++)
                {
                    sb.AppendLine(separatingFunctions[i][j] + "*x" + (j + 1) + " ");
                }
            }

            return sb.ToString();
        }

    }
}
