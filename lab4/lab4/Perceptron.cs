using System.Text;

namespace lab4
{
    /// <summary>
    ///     Perceptron for separating functions generation
    /// </summary>
    public sealed class Perceptron
    {
        /// <summary>
        ///     Same as <see cref="KAverage.Classes"/>
        /// </summary>
        private readonly List<Class> Classes;

        /// <summary>
        ///     Wight matrices to calculate separation functions<br/>
        ///     On last iteration contains separating functions<br/>
        ///     First dimension size is <see cref="_weightMatricesNum"/>, same as <see cref="_classesNum"/>
        ///     Second dimension size is <see cref="_distinctionsNum"/>
        /// </summary>
        private readonly List<List<int>> WeightMatrices;

        /// <summary>
        ///     Size of classes list
        /// </summary>
        private readonly int _classesNum;

        /// <summary>
        ///     Size of objects list
        /// </summary>
        private readonly int _objectsNum;

        /// <summary>
        ///     Size of distinctions of objects list
        /// </summary>
        private int _distinctionsNum;

        /// <summary>
        ///     Size of weight matrices<br/> 
        ///     <see cref="WeightMatrices"/>
        /// </summary>
        private readonly int _weightMatricesNum;

        /// <summary>
        ///     Initializes classes and their objects<br/>
        ///     Divides objects between classes<br/>
        ///     Creates weight matrices<br/>
        ///     Extends object with additional 1 value to add free coefficient of separating function
        /// </summary>
        /// <param name="classesNum"></param>
        /// <param name="objectsNum"></param>
        /// <param name="distinctionsNum"></param>
        public Perceptron(int classesNum, int objectsNum, int distinctionsNum)
        {
            _classesNum = classesNum;
            _weightMatricesNum = classesNum;
            _objectsNum = objectsNum;
            _distinctionsNum = distinctionsNum;

            WeightMatrices = new();

            // Uncomment for stable work
            //Classes = KAverage.Get_DividedClasses(classesNum, objectsNum, distinctionsNum);

            // Uncomment for test values
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

        /// <summary>
        ///     Calculates seaprating functions by weight matrix update
        /// </summary>
        /// <returns>
        ///     New weight matrix
        /// </returns>
        public List<List<int>> Create_SeparatingFunctions()
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

        /// <summary>
        ///     Converts <see cref="Classes"/> to string
        /// </summary>
        /// <returns>
        ///     New string of <see cref="Classes"/>
        /// </returns>
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

        /// <summary>
        ///     Converts <see cref="WeightMatrices"/> to string
        /// </summary>
        /// <returns>
        ///     New string of <see cref="WeightMatrices"/>
        /// </returns>
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

        /// <summary>
        ///     Keeps updating wight matrices untill it becomes separation function array
        /// </summary>
        /// <param name="currObjInd">
        ///     Index of selected object
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if an error occured another update required
        /// </returns>
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
                        Subtract_Vectors(WeightMatrices[(i + currObjInd) % _classesNum], currObj);
                }
            }

            if (isError)
            {
                WeightMatrices[Get_ClassNum(currObjInd)] =
                    Add_Vectors(WeightMatrices[Get_ClassNum(currObjInd)], currObj);
            }

            return isError;
        }

        /// <summary>
        ///     Calculates object index by it's sequence number in class
        /// </summary>
        /// <param name="objPos">
        ///     Current position of object counter
        /// </param>
        /// <returns>
        ///     Index of object in class
        /// </returns>
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

        /// <summary>
        ///     Claculates class index by object sequence number
        /// </summary>
        /// <param name="objNum">
        ///     Current position of object counter
        /// </param>
        /// <returns>
        ///     Index of class
        /// </returns>
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

        /// <summary>
        ///     Adds two vectors
        /// </summary>
        /// <param name="matrix_1"></param>
        /// <param name="matrix_2"></param>
        /// <returns>
        ///     Addition result as 1x1 matrix
        /// </returns>
        private static List<int> Add_Vectors(List<int> matrix_1, List<int> matrix_2)
        {
            var res = new List<int>();

            for (int i = 0; i < matrix_1.Count; i++)
            {
                res.Add(matrix_1[i] + matrix_2[i]);
            }

            return res;
        }

        /// <summary>
        ///     Subtracts two vectors
        /// </summary>
        /// <param name="matrix_1"></param>
        /// <param name="matrix_2"></param>
        /// <returns>
        ///     Subtraction result as 1x1 matrix
        /// </returns>
        private static List<int> Subtract_Vectors(List<int> matrix_1, List<int> matrix_2)
        {
            var res = new List<int>();

            for (int i = 0; i < matrix_1.Count; i++)
            {
                res.Add(matrix_1[i] - matrix_2[i]);
            }

            return res;
        }

        /// <summary>
        ///     Returns object by it's position
        /// </summary>
        /// <param name="classInd">
        ///     Class position
        /// </param>
        /// <param name="objInd">
        ///     Object position
        /// </param>
        /// <returns>
        ///     Object
        /// </returns>
        private List<int> Get_Object(int classInd, int objInd)
        {
            return Classes[classInd].Objects[objInd].Distinctions;
        }

        /// <summary>
        ///     Counts new D list
        /// </summary>
        /// <param name="obj">
        ///     Object to multiply weight matrix on
        /// </param>
        /// <returns>
        ///     New D list
        /// </returns>
        private List<int> Get_VectorD(List<int> obj)
        {
            var res = new List<int>();

            for (int i = 0; i < _classesNum; i++)
            {
                res.Add(Multiply_Vectors(WeightMatrices[i], obj));
            }

            return res;
        }

        /// <summary>
        ///     Initialize <see cref="WeightMatrices"/>
        /// </summary>
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

        /// <summary>
        ///     Extends every <see cref="Class.Objects"> with additional 1 value to get free members of separating functions
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector_1">
        /// 
        /// </param>
        /// <param name="vector_2">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        private int Multiply_Vectors(List<int> vector_1, List<int> vector_2)
        {
            int res = 0;

            for (int i = 0; i < vector_1.Count; i++)
            {
                res += vector_1[i] * vector_2[i];
            }

            return res;
        }

    }
}
