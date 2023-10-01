namespace lab4
{
    public class KAverage
    {
        public int[] Cores;

        public int[][] Elements;


        public KAverage()
        {

        }


        public int[][] Get_DividedClasses()
        {
            throw new NotImplementedException();
        }

        public int[][] Get_BestClusterCore()
        {
/*            var bestCenter = new Point((int)Dots.Average(x => x.TopLeft.X), (int)Dots.Average(x => x.TopLeft.Y));
            var minDifferent = double.MaxValue;
            var minDifferentPoint = new Point();

            foreach (var centerCandidate in Dots)
            {
                var different = GetDotsDistance(bestCenter, centerCandidate.TopLeft);
                if (!(different < minDifferent))
                {
                    continue;
                }
                minDifferent = different;
                minDifferentPoint = centerCandidate.TopLeft;
            }

            return minDifferentPoint;*/
            throw new NotImplementedException();
        }

        protected static double Get_ElementsDistance(int firstElement, int secondElement)
        {/*
            var xDifferent = firstDot.X - secondDot.X;
            var yDifferent = firstDot.Y - secondDot.Y;
            return Math.Sqrt(xDifferent * xDifferent + yDifferent * yDifferent);*/
            throw new NotImplementedException();
        }

        public static void FindCluster()
        {
            /*            int ind = 0;
                        int minDistance = CountDistance(TopLeft, clusters[ind].Center);
                        for (int i = 1; i < clusters.Count; i++)
                        {
                            int currentDistance = CountDistance(TopLeft, clusters[i].Center);
                            if (minDistance > currentDistance)
                            {
                                minDistance = currentDistance;
                                ind = i;
                            }
                        }

                        Pen.Color = clusters[ind].Color;

                        clusters[ind].Dots.Add(this);*/
            throw new NotImplementedException();
        }

        private static int CountDistance(Point p1, Point p2)
        {
            /*            var a = Math.Pow((p1.X - p2.X + WIDTH / 2), 2);
                        var b = Math.Pow((p1.Y - p2.Y + HEIGHT / 2), 2);
                        int res = (int)Math.Sqrt(a + b);
                        return res;*/
            throw new NotImplementedException();
        }
    }
}
