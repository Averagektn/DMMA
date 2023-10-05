namespace lab5
{
    /// <summary>
    ///     Creates polynom to separate points
    /// </summary>
    public sealed class PolynomGenerator
    {
        /// <summary>
        ///     Points of the first class
        /// </summary>
        private readonly List<Point> Class_1 = new();

        /// <summary>
        ///     Points of the second class
        /// </summary>
        private readonly List<Point> Class_2 = new();

        /// <summary>
        ///     Points for separating polynom generation
        /// </summary>
        private readonly List<Point> Objects = new();

        /// <summary>
        ///     Result of generation
        /// </summary>
        private readonly List<int> SeparatingPolynom = new() { 0, 0, 0, 0 };

        /// <summary>
        ///     Random values generator
        /// </summary>
        private readonly Random Random = new();

        /// <summary>
        ///     Number of class elements
        /// </summary>
        private readonly int _classSize;

        /// <summary>
        ///     Separeting polynom length
        /// </summary>
        private const int SEP_POL_SIZE = 4;

        /// <summary>
        ///     Autogeneration of classes with points
        /// </summary>
        /// <param name="size">
        ///     Number of points in class
        /// </param>
        public PolynomGenerator(int size)
        {
            _classSize = size;
            Class_1 = Create_Class();
            Class_2 = Create_Class();
        }

        /// <summary>
        ///     Creates 2 classes:<br/>
        ///     * Class 1: (-1, 0), (1, 1)<br/>
        ///     * Class 2: (2, 0), (1, -2)<br/>
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
        ///     Random points generation of <see cref="_classSize"/> size
        /// </summary>
        /// <returns>
        ///     Class as points list
        /// </returns>
        private List<Point> Create_Class()
        {
            var newClass = new List<Point>();
            
            for (int i = 0; i < _classSize; i++)
            {
                newClass.Add(new Point(Random.Next(), Random.Next()));
                Objects.Add(newClass[^1]);
            }

            return newClass;
        }

        /// <summary>
        ///     Return separating polynom to divide points between 2 classes
        /// </summary>
        /// <returns>
        ///     List of "a" multiplyers a0 + a1*x + a2*y + a3*x*y
        /// </returns>
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
        ///     Initializes polynom
        /// </summary>
        private void Set_InitialSeparatingPolynom()
        {
            Add_ToSeparatingPolynom(Get_CurrentPolynom(0));
        }

        /// <summary>
        ///     Updates polynom as adding or subtracting current object polynom
        /// </summary>
        /// <param name="currObjPos">
        ///     Current object position in <see cref="Objects"/>
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if another update required
        /// </returns>
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
        ///     Gets polynom like: 1 + 4*x + 4*y + 16*x*y 
        /// </summary>
        /// <param name="ind">
        ///     Object number from <see cref="Objects"/>
        /// </param>
        /// <returns>
        ///     Polynom for specified object
        /// </returns>
        private List<int> Get_CurrentPolynom(int ind) => new() 
        { 
            1, 
            4 * Objects[ind].X, 
            4 * Objects[ind].Y, 
            16 * Objects[ind].X * Objects[ind].Y 
        };

        /// <summary>
        ///     Counts value for object in separating function
        /// </summary>
        /// <param name="objInd">
        ///     Object number from <see cref="Objects"/>
        /// </param>
        /// <returns>
        ///     Value of K(<see cref="Objects"/>[objInd])
        /// </returns>
        private int Get_SeparatingFuncValue(int objInd) =>
            SeparatingPolynom[0] +
            SeparatingPolynom[1] * Objects[objInd].X +
            SeparatingPolynom[2] * Objects[objInd].Y +
            SeparatingPolynom[3] * Objects[objInd].X * Objects[objInd].Y;
        
        /// <summary>
        ///     Addition: <see cref="SeparatingPolynom"/> += polynom
        /// </summary>
        /// <param name="polynom">
        ///     Polynom to add to <see cref="SeparatingPolynom"/>
        /// </param>
        private void Add_ToSeparatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] += polynom[i];
            }
        }

        /// <summary>
        ///     Subtraction: <see cref="SeparatingPolynom"/> -= polynom
        /// </summary>
        /// <param name="polynom">
        ///     Polynom to subtract from <see cref="SeparatingPolynom"/>
        /// </param>
        private void Sub_FromSepatingPolynom(List<int> polynom)
        {
            for (int i = 0; i < SEP_POL_SIZE; i++)
            {
                SeparatingPolynom[i] -= polynom[i];
            }
        }

    }

}
