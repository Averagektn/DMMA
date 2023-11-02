namespace lab4
{
    /// <summary>
    ///     K average algorithm realization
    /// </summary>
    public static class KAverage
    {
        /// <summary>
        ///     Classes to process
        /// </summary>
        private static readonly List<Class> Classes = new();

        /// <summary>
        ///     Previous centers coordinates
        /// </summary>
        private static readonly List<List<int>> PrevCenters = new();

        /// <summary>
        ///     Number randomization
        /// </summary>
        private static readonly Random Random = new();

        /// <summary>
        ///     Objects to find better class between <see cref="Classes"/>
        /// </summary>
        private static readonly List<ClassObject> Objects = new();

        /// <summary>
        ///     Maximum value for number generation <see cref="Random"/>
        /// </summary>
        private const int MAX_DIST = 100;

        /// <summary>
        ///     Size of <see cref="Classes"/>
        /// </summary>
        private static int _classesNum;

        /// <summary>
        ///     Size of <see cref="Objects"/>
        /// </summary>
        private static int _objectsNum;

        /// <summary>
        ///     Size of <see cref="ClassObject.Distinctions">
        /// </summary>
        private static int _distinctionsNum;

        /// <summary>
        ///     Divides <see cref="Objects"/> into <see cref="Classes"/>
        /// </summary>
        /// <param name="classesNum">
        ///     <see cref="_classesNum"/>
        /// </param>
        /// <param name="objectsNum">
        ///     <see cref="_objectsNum"/>
        /// </param>
        /// <param name="distinctionsNum">
        ///     <see cref="_distinctionsNum"/>
        /// </param>
        /// <returns>
        ///     <see cref="List{T}"/> of <see cref="Class"/>, whose points are divided according to k-average algorithm
        /// </returns>
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
        ///     Recalculates <see cref="Class.Center"/>
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
        ///     Updates <see cref="PrevCenters"/>, sets them as <see cref="Class.Center"> list on previos iteration
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
        ///     Initializaton: sets centers of <see cref="Class.Center"/>
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
        ///     Generates <see cref="ClassObject"/> to be distributed betwee classes
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
        ///     Points comparisson
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObject"></param>
        /// <returns>
        ///     <see langword="true"/> if objects are equal
        /// </returns>
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
