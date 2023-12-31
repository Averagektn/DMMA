﻿namespace lab1
{
    public class Cluster
    {
        /// <summary>
        /// Clusters center
        /// </summary>
        public Point Center;

        /// <summary>
        /// Dots of the cluster
        /// </summary>
        public List<Dot> Dots = new();

        /// <summary>
        /// Cluster's unique color
        /// </summary>
        public readonly Color Color;

        /// <summary>
        /// Size of cluster center to be drawn
        /// </summary>
        private const int WIDTH = 20, HEIGHT = 20;

        /// <summary>
        /// Generates cluster with specified <see cref="System.Drawing.Color"/> and coordinates
        /// </summary>
        /// <param name="color"><see cref="Color"></param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Cluster(Color color, int x, int y)
        {
            Color = color;
            Center = new Point(x, y);
        }

        /// <summary>
        /// Draws all the point of the cluster
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> to draw on</param>
        public void DrawDots(Graphics g)
        {
            foreach (var dot in Dots)
            {
                dot.Draw(g);
            }
        }

        /// <summary>
        /// Draws cluster's center at <see cref="Center"/> with <see cref="WIDTH"/> and <see cref="HEIGHT"/> sizes
        /// </summary>
        /// <param name="g"><see cref="Graphics"/> to draw on</param>
        public void DrawCenter(Graphics g)
        {
            g.DrawEllipse(Pens.Black, Center.X, Center.Y, WIDTH, HEIGHT);
            g.FillEllipse(new SolidBrush(Color.Black), Center.X, Center.Y, WIDTH, HEIGHT);
        }
    }
}
