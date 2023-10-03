namespace lab4
{
    /// <summary>
    ///     Specifies class as center and container of objects around it
    /// </summary>
    public sealed class Class
    {
        /// <summary>
        ///     Central point of class
        /// </summary>
        public List<int> Center { get; set; }

        /// <summary>
        ///     Objects of the class
        /// </summary>
        public List<ClassObject> Objects { get; set; }

        /// <summary>
        ///     Creates new class by center and empty <see cref="Objects"/>
        /// </summary>
        /// <param name="center">
        ///     Central point specified class
        /// </param>
        public Class(List<int> center) 
        { 
            Center = center;
            Objects = new();
        }

        /// <summary>
        ///     Counts new class <see cref="Center"/><br/> 
        /// </summary>
        /// <param name="distinctionsNum">
        ///     Number of distinctions to iterate through
        /// </param>
        /// <returns>
        ///     New <see cref="Center"/>
        /// </returns>
        public List<int> Get_BestClassCenter(int distinctionsNum)
        {
            var bestCenter = new List<int>();

            for (int j = 0; j < distinctionsNum; j++)
            {
                if (Objects.Count != 0)
                {
                    bestCenter.Add((int)Objects.Average(obj => obj.Distinctions[j]));
                }
                else
                {
                    bestCenter.Add(Center[j]);
                }
            }

            var minDifferent = double.MaxValue;
            var minDifferentObject = Center;

            foreach (var centerCandidate in Objects)
            {
                var different = ClassObject.Get_Distance(bestCenter, centerCandidate.Distinctions);
                if (!(different < minDifferent))
                {
                    continue;
                }
                minDifferent = different;
                minDifferentObject = centerCandidate.Distinctions;
            }

            return minDifferentObject;
        }

    }
}
