namespace lab4
{
    public static class KAverage
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly List<Class> Classes = new();

        /// <summary>
        /// 
        /// </summary>
        private static readonly List<List<int>> PrevCenters = new();

        /// <summary>
        /// 
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        /// 
        /// </summary>
        private static readonly List<ClassObject> Objects = new();

        /// <summary>
        /// 
        /// </summary>
        private const int MAX_DIST = 100;

        /// <summary>
        /// 
        /// </summary>
        private static int _classesNum;

        /// <summary>
        /// 
        /// </summary>
        private static int _objectsNum;

        /// <summary>
        /// 
        /// </summary>
        private static int _distinctionsNum;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classesNum"></param>
        /// <param name="objectsNum"></param>
        /// <param name="distinctionsNum"></param>
        /// <returns></returns>
        public static List<Class> Get_DividedClasses(int classesNum, int objectsNum, int distinctionsNum)
        {
            bool isCounting = true;

            _classesNum = classesNum;
            _objectsNum = objectsNum;
            _distinctionsNum = distinctionsNum;

            Generate_Classes();
            Generate_Objects();

            for (int i = 0; i < Objects.Count; i++)
            {
                Objects[i].FindCluster(Classes);
            }

            while (isCounting)
            {
                isCounting = false;

                Update_PrevCenters();

                Update_Centers();

                for (int i = 0; i < Objects.Count; i++)
                {
                    Objects[i].FindCluster(Classes);
                }

                for (int i = 0; i < Classes.Count; i++)
                {
                    if (!Is_SameObject(Classes[i].Center, PrevCenters[i]))
                    {
                        isCounting = true;
                    }
                }
            }

            return Classes;
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Update_Centers()
        {
            for (int i = 0; i < Classes.Count; i++)
            {
                Classes[i].Center = Classes[i].Get_BestClassCenter(_distinctionsNum);
                Classes[i].Objects.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Update_PrevCenters()
        {
            PrevCenters.Clear();
            for (int i = 0; i < _classesNum; i++)
            {
                PrevCenters.Add(Classes[i].Center);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Generate_Classes()
        {
            for (int i = 0; i < _classesNum; i++)
            {
                var center = new List<int>();
                for (int j = 0; j < _distinctionsNum; j++)
                {
                    center.Add(Random.Next(MAX_DIST));
                }
                Classes.Add(new Class(center));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void Generate_Objects()
        {
            for (int i = 0; i < _objectsNum; i++)
            {
                var obj = new List<int>();

                for (int j = 0; j < _distinctionsNum; j++)
                {
                    obj.Add(Random.Next(MAX_DIST));
                }

                Objects.Add(new ClassObject(obj));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObject"></param>
        /// <returns></returns>
        private static bool Is_SameObject(List<int> firstObject, List<int> secondObject)
        {
            bool result = true;

            for (int i = 0; i < firstObject.Count && result; i++)
            {
                if (Math.Abs(firstObject[i] - secondObject[i]) > 5)
                {
                    result = false;
                }
            }

            return result;
        }

    }
}
