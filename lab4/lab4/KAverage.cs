namespace lab4
{
    public static class KAverage
    {
        private static Random Random = new();
        private static List<ClassObject> Objects = new();
        private static readonly List<Class> Classes = new();
        private static readonly List<List<int>> PrevCenters = new();

        private static int _classesNum;
        private static int _objectsNum;
        private static int _distinctionsNum;

        public static List<Class> Get_DividedClasses(int classesNum, int objectsNum, int distinctionsNum)
        {
            bool isCounting = true;

            _classesNum = classesNum;
            _objectsNum = objectsNum;
            _distinctionsNum = distinctionsNum;

            Generate_Classes();
            Generate_Objects();

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

        private static void Update_Centers()
        {
            for (int i = 0; i < Classes.Count; i++)
            {
                Classes[i].Center = Classes[i].Get_BestClassCenter();
                Classes[i].Objects.Clear();
            }
        }

        private static void Update_PrevCenters()
        {
            PrevCenters.Clear();
            for (int i = 0; i < _classesNum; i++)
            {
                PrevCenters.Add(Classes[i].Center);
            }
        }

        private static void Generate_Classes()
        {
            for (int i = 0; i < _classesNum; i++)
            {
                var center = new List<int>();
                for (int j = 0; j < _distinctionsNum; j++)
                {
                    center.Add(Random.Next());
                }
                Classes.Add(new Class(center));
            }
        }

        private static void Generate_Objects()
        {
            for (int i = 0; i < _objectsNum; i++)
            {
                var obj = new List<int>();

                for (int j = 0; j < _distinctionsNum; j++)
                {
                    obj.Add(Random.Next());
                }

                Objects.Add(new ClassObject(obj));
            }
        }

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
