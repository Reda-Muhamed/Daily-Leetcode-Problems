using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        var events = new List<Event>();
        double totalArea = 0.0;

        int id = 0;
        foreach (var s in squares)
        {
            int x = s[0];
            int y = s[1];
            int l = s[2];

            events.Add(new Event(y, x, x + l, +1, id));     // start
            events.Add(new Event(y + l, x, x + l, -1, id)); // end

            totalArea += (double)l * l;
            id++;
        }

        // sort events by y
        events.Sort((a, b) => a.Y.CompareTo(b.Y));

        var active = new List<Interval>();

        double target = totalArea / 2.0;
        double currentArea = 0.0;

        int i = 0;
        while (i < events.Count)
        {
            double currY = events[i].Y;

            while (i < events.Count && events[i].Y == currY)
            {
                UpdateActive(active, events[i]);
                i++;
            }

            if (i >= events.Count) break;

            double nextY = events[i].Y;
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
            active.Add(new Interval(e.X1, e.X2, e.Id));
        }
        else
        {
            for (int i = 0; i < active.Count; i++)
            {
                if (active[i].Id == e.Id)
                {
                    active.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private double ComputeCoveredWidth(List<Interval> intervals)
    {
        double total = 0.0;
        foreach (var it in intervals)
        {
            total += it.End - it.Start;
        }
        return total;
    }

    class Event
    {
        public int Y;
        public int X1;
        public int X2;
        public int Type; // +1 start, -1 end
        public int Id;

        public Event(int y, int x1, int x2, int type, int id)
        {
            Y = y;
            X1 = x1;
            X2 = x2;
            Type = type;
            Id = id;
        }
    }

    class Interval
    {
        public int Start;
        public int End;
        public int Id;

        public Interval(int s, int e, int id)
        {
            Start = s;
            End = e;
            Id = id;
        }
    }
}
