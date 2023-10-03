namespace lab4
{
    /// <summary>
    ///     Specifies elements of <see cref="Class"/>
    /// </summary>
    public sealed class ClassObject
    {
        /// <summary>
        ///     Number of coordinates for comparisson
        /// </summary>
        public List<int> Distinctions { get; set; }

        /// <summary>
        ///     Creates object with spedifies distinctions number
        /// </summary>
        /// <param name="distinctions">
        ///     <see cref="Distinctions"/>
        /// </param>
        public ClassObject(List<int> distinctions)
        {
            Distinctions = distinctions;
        }

        /// <summary>
        ///     Finds best class among given
        /// </summary>
        /// <param name="classes">
        ///     Given classes <see cref="Class"/>
        /// </param>
        public void FindCluster(List<Class> classes)
        {
            int ind = 0;
            int minDistance = Get_Distance(Distinctions, classes[ind].Center);

            for (int i = 1; i < classes.Count; i++)
            {
                int currentDistance = Get_Distance(Distinctions, classes[i].Center);
                if (minDistance > currentDistance)
                {
                    minDistance = currentDistance;
                    ind = i;
                }
            }

            classes[ind].Objects.Add(this);
        }

        /// <summary>
        ///     Calculates distance between two objects
        /// </summary>
        /// <param name="firstObject">
        ///     <see cref="Distinctions">
        /// </param>
        /// <param name="secondObject">
        ///     <see cref="Distinctions">
        /// </param>
        /// <returns>
        ///     Distance as root of square difference sums
        /// </returns>
        public static int Get_Distance(List<int> firstObject, List<int> secondObject)
        {
            var diff = new List<int>(firstObject.Count);   

            for (int i = 0; i < firstObject.Count; i++)
            {
                diff.Add(firstObject[i] - secondObject[i]);
                diff[i] *= diff[i];
            }

            return (int)Math.Sqrt(diff.Sum());
        }

    }
}
