namespace lab4
{
    public sealed class ClassObject
    {
        public List<int> Distinctions;

        public ClassObject(List<int> distinctions)
        {
            Distinctions = distinctions;
        }

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

        public static int Get_Distance(List<int> firstObject, List<int> secondObject)
        {
            var diff = new List<int>(firstObject.Count);   

            for (int i = 0; i < firstObject.Count; i++)
            {
                diff[i] = firstObject[i] - secondObject[i];
                diff[i] *= diff[i];
            }

            return (int)Math.Sqrt(diff.Sum());
        }

    }
}
