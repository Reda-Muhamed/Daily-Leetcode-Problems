public class Solution {
    public int MinCost(int n, int[][] edges) {

        var g = new List<(int,int)>[n];
        for(int i =0;i< n;i++){
            g[i]=new List<(int ,int)>();
        }
        foreach(var e in edges){
            int u = e[0];
            int v = e[1];
            int w = e[2];
            g[u].Add((v,w));
            g[v].Add((u,2*w));
        }
        //dijkstra
        var dist = new long[n];
        Array.Fill(dist,long.MaxValue);
        dist[0]=0;
        var pr =new PriorityQueue<int ,long>();
        pr.Enqueue(0,0);
        while(pr.Count>0){
            pr.TryDequeue(out int node, out long currDist);

            if (currDist > dist[node])
                continue;

            if (node == n - 1)
                return (int)currDist;

            foreach(var(next,cost) in g[node]){
                 long newDist = currDist + cost;
                if (newDist < dist[next])
                {
                    dist[next] = newDist;
                    pr.Enqueue(next, newDist);
                }
            }

        }
        return -1;
    }
}