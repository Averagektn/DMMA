namespace lab7
{
    /// <summary>
    /// 
    /// </summary>
    public class Classifier
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenceClass">
        /// 
        /// </param>
        /// <param name="candidate">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        /// <exception cref="NullReferenceException">
        /// 
        /// </exception>
        public static bool IsSameClass(Node referenceClass, List<Point> candidate)
        { 
            bool equals = false;

            if (candidate.Count == 1)
            {
                return true;
            }

            for (int i = 0; i < candidate.Count && !equals; i++)
            {
                for (int j = i + 1; j < candidate.Count && !equals; j++)
                {
                    if (referenceClass.Equals(candidate[i], candidate[j]))
                    {
                        referenceClass = referenceClass.Next ?? throw new NullReferenceException();
                        candidate.RemoveAt(i);
                        equals = true;
                    }
                }
            }

            if (equals)
            {
                equals = IsSameClass(referenceClass, candidate);
            }

            return equals;
        }

    }

}
