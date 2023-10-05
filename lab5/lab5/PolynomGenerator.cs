namespace lab5
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PolynomGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point> Class_1 = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point> Class_2 = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly List<Point> Objects = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly List<int> SeparatingPolynom = new() { 0, 0, 0, 0 };

        /// <summary>
        /// 
        /// </summary>
        private readonly Random Random = new();

        /// <summary>
        /// 
        /// </summary>
        private readonly int _classSize;

        /// <summary>
        /// 
        /// </summary>
        private const int SEP_POL_SIZE = 4;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        public PolynomGenerator(int size)
        {
            _classSize = size;
            Class_1 = Create_Class();
            Class_2 = Create_Class();
        }

        /// <summary>
        /// 
        /// </summary>
        public PolynomGenerator()
        {
            Class_1.Add(new Point(-1, 0));
            Class_1.Add(new Point(1, 1));
            Class_2.Add(new Point(2, 0));
            Class_2.Add(new Point(1, -2));

            Objects = new() { Class_1[0], Class_1[1], Class_2[0], Class_2[1] };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Point> Create_Class()
        {
            var newClass = new List<Point>();
            
            for (int i = 0; i < _classSize; i++)
            {
                newClass.Add(new Point(Random.Next(), Random.Next()));
            }

            return newClass;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<int> Get_SeparatingPolynom()
        {
            int currObjInd = 1;

            Set_InitialSeparatingPolynom();

            while (Update_Polynom(currObjInd)) 
            {
                currObjInd++;
                currObjInd %= Objects.Count;
            }

            return SeparatingPolynom;
        }

        /// <summary>
        /// 
        /// </summary>
        private void Set_InitialSeparatingPolynom()
        {
            Add_ToSeparatingPolynom(Get_CurrentPolynom(0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currObjPos"></param>
        /// <returns></returns>
        private bool Update_Polynom(int currObjPos)
        {
            var currentPolynom = Get_CurrentPolynom(currObjPos);
            bool isUpdateRequired;
            int sepFunValue;

            sepFunValue = Get_SeparatingFuncValue(currObjPos);
            if (Class_1.Contains(Objects[currObjPos]))
            {
                isUpdateRequired = sepFunValue < 0;
                if (isUpdateRequired)
                {
                    Add_ToSeparatingPolynom(currentPolynom);
                }
            }
            else
            {
                isUpdateRequired = sepFunValue >= 0;
                if (isUpdateRequired)
                {
                    Sub_FromSepatingPolynom(currentPolynom);
                }
            }

            return isUpdateRequired;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        private List<int> Get_CurrentPolynom(int ind) => new() 
        { 
            1, 
            4 * Objects[ind].X, 
            4 * Objects[ind].Y, 
            16 * Objects[ind].X * Objects[ind].Y 
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objInd"></param>
        /// <returns></returns>
        private int Get_SeparatingFuncValue(int objInd) =>
            SeparatingPolynom[0] +
            SeparatingPolynom[1] * Objects[objInd].X +
            SeparatingPolynom[2] * Objects[objInd].Y +
            SeparatingPolynom[3] * Objects[objInd].X * Objects[objInd].Y;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="polynom"></param>
        private void Add_ToSeparatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] += polynom[i];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polynom"></param>
        private void Sub_FromSepatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] -= polynom[i];
            }
        }

    }

}
