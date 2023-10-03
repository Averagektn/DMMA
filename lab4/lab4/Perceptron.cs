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
        private int _weightMatricesNum;

        public Perceptron(int classesNum, int objectsNum, int distinctionsNum)
        {
            _classesNum = classesNum;
            _weightMatricesNum = classesNum;
            _objectsNum = objectsNum;
            _distinctionsNum = distinctionsNum;

            WeightMatrices = new();

            //Classes = KAverage.Get_DividedClasses(classesNum, objectsNum, distinctionsNum);
            Classes = new List<Class>();

            var center_1 = new List<int> { 0, 0 };
            var class_1 = new Class(center_1);
            Classes.Add(class_1);

            var center_2 = new List<int> { 1, 1 };
            var class_2 = new Class(center_2);
            Classes.Add(class_2);

            var center_3 = new List<int> { -1, 1 };
            var class_3 = new Class(center_3);
            Classes.Add(class_3);

            Classes[0].Objects.Add(new ClassObject(center_1));
            Classes[1].Objects.Add(new ClassObject(center_2));
            Classes[2].Objects.Add(new ClassObject(center_3));

            Extend_Objects();
            Create_WeightMatrices();
        }

        private List<List<int>> Create_SeparatingFunctions()
        {
            bool isCounting = true;
            int objInd = 0;

            while (isCounting)
            {
                isCounting = Update_WeightMatrices(objInd);
                objInd++;
                objInd %= _objectsNum;
            }

            return WeightMatrices;
        }

        private bool Update_WeightMatrices(int currObjInd)
        {
            bool isError = false;
            var currObj = Get_Object(Get_ClassNum(currObjInd), Get_ObjInd(currObjInd));
            var vector_D = Get_VectorD(currObj);

            for (int i = 1; i < _weightMatricesNum; i++)
            {
                if (vector_D[(i + currObjInd) % _classesNum] >= vector_D[Get_ClassNum(currObjInd)])
                {
                    isError = true;
                    WeightMatrices[(i + currObjInd) % _classesNum] =
                        Subtract_Matrices(WeightMatrices[(i + currObjInd) % _classesNum], currObj);
                }
            }

            if (isError)
            {
                WeightMatrices[Get_ClassNum(currObjInd)] = 
                    Add_Matrices(WeightMatrices[Get_ClassNum(currObjInd)], currObj);
            }

            return isError;
        }

        private int Get_ObjInd(int objPos)
        {
            int ind = 0;

            while (ind < _classesNum && objPos - Classes[ind].Objects.Count >= 0)
            {
                objPos -= Classes[ind].Objects.Count;
                ind++;
            }

            return objPos;
        }

        private int Get_ClassNum(int objNum)
        {
            int res = 0;

            while (res < _classesNum && objNum - Classes[res].Objects.Count >= 0)
            {
                objNum -= Classes[res].Objects.Count;
                res++;
            }

            return res;
        }

        private List<int> Add_Matrices(List<int> matrix_1, List<int> matrix_2)
        {
            var res = new List<int>();

            for (int i = 0; i < matrix_1.Count; i++)
            {
                res.Add(matrix_1[i] + matrix_2[i]);
            }

            return res;
        }

        private List<int> Subtract_Matrices(List<int> matrix_1, List<int> matrix_2)
        {
            var res = new List<int>();

            for (int i = 0; i < matrix_1.Count; i++)
            {
                res.Add(matrix_1[i] - matrix_2[i]);
            }

            return res;
        }

        private List<int> Get_Object(int classInd, int objInd)
        {
            return Classes[classInd].Objects[objInd].Distinctions;
        }

        private List<int> Get_VectorD(List<int> obj)
        {
            var res = new List<int>();

            for (int i = 0; i < _classesNum; i++)
            {
                res.Add(Multiply_Vectors(WeightMatrices[i], obj));
            }

            return res;
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

        private int Multiply_Vectors(List<int> vector_1, List<int> vector_2)
        {
            int res = 0;

            for (int i = 0; i < vector_1.Count; i++)
            {
                res += vector_1[i] * vector_2[i];
            }

            return res;
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
            var separatingFunctions = Create_SeparatingFunctions();
            var sb = new StringBuilder();

            for (int i = 0; i < _classesNum; i++)
            {
                sb.Append($"Function " + (i + 1) + ": ");
                for (int j = 0; j < _distinctionsNum - 1; j++)
                {
                    sb.Append(Math.Abs(separatingFunctions[i][j]) + "*x" + (j + 1));
                    if (separatingFunctions[i][j + 1] >= 0)
                    {
                        sb.Append(" + ");
                    }
                    else
                    {
                        sb.Append(" - ");
                    }

                }

                sb.AppendLine(Math.Abs(separatingFunctions[i][^1]).ToString());
            }

            return sb.ToString();
        }

    }
}
