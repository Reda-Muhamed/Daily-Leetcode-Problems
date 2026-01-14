using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        var events = new List<Event>();

        foreach (var s in squares)
        {
            int x = s[0];
            int y = s[1];
            int l = s[2];

            events.Add(new Event(y, x, x + l, +1));     // start
            events.Add(new Event(y + l, x, x + l, -1)); // end
        }

        // sort events by y
        events.Sort((a, b) => a.Y.CompareTo(b.Y));

        var active = new List<Interval>();
        double totalArea = 0.0;

        //compute total area
        for (int i = 0; i < events.Count - 1; i++)
        {
            var e = events[i];
            UpdateActive(active, e);

            double currY = e.Y;
            double nextY = events[i + 1].Y;
            double height = nextY - currY;

            if (height > 0 && active.Count > 0)
            {
                double width = ComputeCoveredWidth(active);
                totalArea += width * height;
            }
        }

        double target = totalArea / 2.0;

        //sweep again to find answer y
        active.Clear();
        double currentArea = 0.0;

        for (int i = 0; i < events.Count - 1; i++)
        {
            var e = events[i];
            UpdateActive(active, e);

            double currY = e.Y;
            double nextY = events[i + 1].Y;
            double height = nextY - currY;

            if (height > 0 && active.Count > 0)
            {
                double width = ComputeCoveredWidth(active);
                double areaAdded = width * height;

                if (currentArea + areaAdded >= target)
                {
                    double remaining = target - currentArea;
                    double answerY = currY + (remaining / width);
                    return answerY;
                }

                currentArea += areaAdded;
            }
        }

        return 0.0;
    }

    // update active intervals based on event
    private void UpdateActive(List<Interval> active, Event e)
    {
        if (e.Type == +1)
        {
            active.Add(new Interval(e.X1, e.X2));
        }
        else
        {
            // remove matching interval
            for (int i = 0; i < active.Count; i++)
            {
                if (active[i].Start == e.X1 && active[i].End == e.X2)
                {
                    active.RemoveAt(i);
                    break;
                }
            }
        }
    }

    // merge intervals and compute total covered width
    private double ComputeCoveredWidth(List<Interval> intervals)
    {
        if (intervals.Count == 0) return 0.0;

        var list = intervals.OrderBy(i => i.Start).ToList();

        double total = 0.0;
        double curStart = list[0].Start;
        double curEnd = list[0].End;

        for (int i = 1; i < list.Count; i++)
        {
            if (list[i].Start > curEnd)
            {
                total += curEnd - curStart;
                curStart = list[i].Start;
                curEnd = list[i].End;
            }
            else
            {
                curEnd = Math.Max(curEnd, list[i].End);
            }
        }

        total += curEnd - curStart;
        return total;
    }

    class Event
    {
        public int Y;
        public int X1;
        public int X2;
        public int Type; // +1 start, -1 end

        public Event(int y, int x1, int x2, int type)
        {
            Y = y;
            X1 = x1;
            X2 = x2;
            Type = type;
        }
    }

    class Interval
    {
        public int Start;
        public int End;

        public Interval(int s, int e)
        {
            Start = s;
            End = e;
        }
    }
}
