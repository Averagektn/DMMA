namespace lab7
{
    /// <summary>
    ///     Classifies candidates points
    /// </summary>
    public class Classifier
    {
        /// <summary>
        ///     Check if potential points are included in the class
        /// </summary>
        /// <param name="referenceClass">
        ///     Calss template
        /// </param>
        /// <param name="candidate">
        ///     Candidate points
        /// </param>
        /// <returns>
        ///     <see langword="true"/> if the points belong to the class, otherwise <see langword="false"/>
        /// </returns>
        /// <exception cref="NullReferenceException">
        ///     Candidate list length must be equal to reference class length
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
