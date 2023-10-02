namespace lab4
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class Class
    {
        /// <summary>
        /// 
        /// </summary>
        public List<int> Center { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ClassObject> Objects { get; set; }

        public Class(List<int> center) 
        { 
            Center = center;
            Objects = new();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="distinctionsNum"></param>
        /// <returns></returns>
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
