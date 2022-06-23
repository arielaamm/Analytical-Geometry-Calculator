using System;
using System.IO;
using DAL_BL.DO.PARAMS;
using Actions2 = DAL_BL.DO.PARAMS.methods;
using Action = DAL_BL.DO.Simple_Stractures.Action;
using System.Collections.Generic;
using DAL_BL.DO.Simple_Stractures;
using System.Drawing;
using System.Drawing.Imaging;


namespace Drawing
{
    public static class Drawing
    {
        public static List<Line> ZeroPointsInGraph(List<Line> lines, List<DAL_BL.DO.Simple_Stractures.Point> points)
        {
            List<Line> RetList = new List<Line>();
            for(int i = 0; i < lines.Count; i ++)
            {
                bool HavePoint = false;
                for(int j = 0; j < points.Count; j ++)
                {
                    if (points[j].on(lines[i]))
                        HavePoint = true;
                }
                if (HavePoint)
                {
                    RetList.Add(lines[i]);
                }
            }
            return RetList;
        }
        public static int scale(List<Line> lines, List<DAL_BL.DO.Simple_Stractures.Point> points)
        {
            double maxXY = 0;
            for (int i = 0; i < points.Count; i++)
            {
                if (Math.Abs(points[i].X) > maxXY)
                    maxXY = Math.Abs(points[i].X);
                if(Math.Abs(points[i].Y) > maxXY)
                    maxXY=Math.Abs(points[i].Y);
            }
            List<Line> ZeroPointsInGraphic = ZeroPointsInGraph(lines, points);
            if (ZeroPointsInGraphic.Count == 0)
            {
                return (int)maxXY + 1;
            }
            else
            {
                double maxD = 0;
                for(int i = 0; i < ZeroPointsInGraphic.Count; i++)
                {
                    DAL_BL.DO.Simple_Stractures.Point p = new DAL_BL.DO.Simple_Stractures.Point();
                    p.X = 0; p.Y = 0;
                    if (Action.Distance(p, ZeroPointsInGraphic[i]) > maxD)
                        maxD = Action.Distance(p, ZeroPointsInGraphic[i]);
                }
                if (maxD > maxXY)
                    return (int)maxD + 1;
                else
                    return (int)maxXY + 2;
            }
        }
        public static void GetCoordinateSystem(Image image,List<Line> lines, List<DAL_BL.DO.Simple_Stractures.Point> points)
        {
            var graphic = Graphics.FromImage(image);
            Pen BlackPen = new Pen(Color.Black);
            int scale_to_calc = scale(lines, points);
            //add coordinate
            graphic.DrawLine(BlackPen, 0, (int)image.Height / 2, image.Width, (int)image.Height / 2);
            graphic.DrawLine(BlackPen, (int)image.Width / 2, 0, (int)image.Width / 2, image.Height);
            //take all the points and lines  to [-1,1]*[-1,1]
            List<DAL_BL.DO.Simple_Stractures.Point> ScaledPoints = new List<DAL_BL.DO.Simple_Stractures.Point>();
            for(int i = 0; i < points.Count; i++)
            {
                DAL_BL.DO.Simple_Stractures.Point p = new DAL_BL.DO.Simple_Stractures.Point();
                p.X = points[i].X/scale_to_calc;
                p.Y = points[i].Y/scale_to_calc;
                p.Name = points[i].Name;
                ScaledPoints.Add(p);
            }
            List<Line> ScaledLines = new List<Line>();

            for (int i = 0; i < lines.Count; i++)
            {
                Line l = lines[i];
                double end = 1;
                if(l.YEqualK(1).X < 1)
                {
                    end = l.YEqualK(1).X;   
                }
                double start = -1;
                if(l.YEqualK(-1).X > -1)
                    start = l.YEqualK(-1).X;
                 var start_l = l.XEqualK(start);
                 var end_l = l.XEqualK(end);
                ScaledLines.Add(new Line(start_l, end_l));
            }
            //draw the lines and points on the coordinate system
            for(int i = 0; i < ScaledLines.Count; i ++)
            {
                graphic.DrawLine(BlackPen, (int)((ScaledLines[i].StartPoint.X + 1) * image.Width/2),image.Height- (int)((ScaledLines[i].StartPoint.Y+1) * image.Height/2), (int)((ScaledLines[i].EndPoint.X + 1) * image.Width/2),image.Height- (int)((ScaledLines[i].EndPoint.Y+1) * image.Height/2));
            }
            for (int i = 0; i < ScaledPoints.Count; i++)
            {
                graphic.DrawEllipse(BlackPen, (int)((ScaledPoints[i].X + 1) * image.Width/2)-4,image.Height - (int)((ScaledPoints[i].Y+1) * image.Height/2)-4, 8, 8);
            }
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            image.Save(projectDirectory + "\\pp.jpg");
   
        }

    }
}