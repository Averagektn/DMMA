namespace lab5
{
    public sealed class PolynomGenerator
    {
        private readonly List<Point> Class_1 = new();
        private readonly List<Point> Class_2 = new();

        private readonly List<Point> Objects = new();

        private readonly List<int> SeparatingPolynom = new() { 0, 0, 0, 0 };

        private readonly Random Random = new();

        private readonly int _classSize;

        private const int SEP_POL_SIZE = 4;

        public PolynomGenerator(int size)
        {
            _classSize = size;
            Class_1 = Create_Class();
            Class_2 = Create_Class();
        }

        public PolynomGenerator()
        {
            Class_1.Add(new Point(-1, 0));
            Class_1.Add(new Point(1, 1));
            Class_2.Add(new Point(2, 0));
            Class_2.Add(new Point(1, -2));

            Objects = new() { Class_1[0], Class_1[1], Class_2[0], Class_2[1] };
        }

        private List<Point> Create_Class()
        {
            var newClass = new List<Point>();
            
            for (int i = 0; i < _classSize; i++)
            {
                newClass.Add(new Point(Random.Next(), Random.Next()));
            }

            return newClass;
        }

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

        private void Set_InitialSeparatingPolynom()
        {
            Add_ToSeparatingPolynom(Get_CurrentPolynom(0));
        }

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

        private List<int> Get_CurrentPolynom(int ind) => new() 
        { 
            1, 
            4 * Objects[ind].X, 
            4 * Objects[ind].Y, 
            16 * Objects[ind].X * Objects[ind].Y 
        };

        private int Get_SeparatingFuncValue(int objInd) =>
            SeparatingPolynom[0] +
            SeparatingPolynom[1] * Objects[objInd].X +
            SeparatingPolynom[2] * Objects[objInd].Y +
            SeparatingPolynom[3] * Objects[objInd].X * Objects[objInd].Y;
        

        private void Add_ToSeparatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] += polynom[i];
            }
        }

        private void Sub_FromSepatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] -= polynom[i];
            }
        }

    }

}
