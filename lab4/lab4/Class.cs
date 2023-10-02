namespace lab4
{
    public sealed class Class
    {
        public List<int> Center;
        public List<ClassObject> Objects;

        public Class(List<int> center) 
        { 
            Center = center;
            Objects = new();
        }

        public List<int> Get_BestClassCenter(int distinctionsNum)
        {
            var bestCenter = new List<int>();

            for (int j = 0; j < distinctionsNum; j++)
            {
                bestCenter.Add((int)Objects.Average(obj => obj.Distinctions[j]));
            }

            var minDifferent = double.MaxValue;
            var minDifferentObject = new List<int>();

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
