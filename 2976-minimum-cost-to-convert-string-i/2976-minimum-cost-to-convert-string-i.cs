public class Solution
{
    public long MinimumCost(
        string source,
        string target,
        char[] original,
        char[] changed,
        int[] cost)
    {
        const long INF = (long)1e18;
        int N = 26;
        var graph = new List<(int,int)>[N];
        for (int i = 0; i < N; i++)
            graph[i] = new List<(int, int)>();
        int len = original.Length;
        for (int i = 0; i < len; i++)
        {
            int u = original[i] - 'a';
            int v = changed[i] - 'a';
            graph[u].Add((v, cost[i]));
        }

        Dictionary<int, long[]> shortest = new Dictionary<int, long[]>();

        long totalCost = 0;
        int len1 = source.Length;
        for (int i = 0; i <len1 ; i++)
        {
            int s = source[i] - 'a';
            int t = target[i] - 'a';

            if (s == t) continue;

            if (!shortest.ContainsKey(s))
                shortest[s] = Dijkstra(s, graph);

            long dist = shortest[s][t];
            if (dist == INF)
                return -1;

            totalCost += dist;
        }

        return totalCost;
    }

    private long[] Dijkstra(int start, List<(int to, int w)>[] graph)
    {
        const long INF = (long)1e18;
        int N = 26;

        long[] dist = new long[N];
        Array.Fill(dist, INF);
        dist[start] = 0;

        PriorityQueue<int, long> pq = new PriorityQueue<int, long>();
        pq.Enqueue(start, 0);

        while (pq.Count > 0)
        {
            pq.TryDequeue(out int u, out long d);
            if (d > dist[u]) continue;

            foreach (var (v, w) in graph[u])
            {
                long nd = d + w;
                if (nd < dist[v])
                {
                    dist[v] = nd;
                    pq.Enqueue(v, nd);
                }
            }
        }

        return dist;
    }
}
