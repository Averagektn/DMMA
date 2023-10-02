namespace lab4
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ClassObject
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> Distinctions { get; set; }

        public ClassObject(List<int> distinctions)
        {
            Distinctions = distinctions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classes"></param>
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
        /// 
        /// </summary>
        /// <param name="firstObject"></param>
        /// <param name="secondObject"></param>
        /// <returns></returns>
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
