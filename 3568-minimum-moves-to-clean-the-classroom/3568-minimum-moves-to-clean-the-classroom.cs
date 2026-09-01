public class Solution
{
    public int MinMoves(string[] classroom, int energy)
    {
        int rows = classroom.Length;
        int cols = classroom[0].Length;

        int startR = -1;
        int startC = -1;

        int litterCount = 0;

        // Give every litter an ID
        int[,] litterId = new int[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                litterId[r, c] = -1;

                if (classroom[r][c] == 'S')
                {
                    startR = r;
                    startC = c;
                }
                else if (classroom[r][c] == 'L')
                {
                    litterId[r, c] = litterCount++;
                }
            }
        }

        // No litter
        if (litterCount == 0)
            return 0;

        int allCollected = (1 << litterCount) - 1;

        // visited[r,c,mask] = maximum energy we've had
        // for this position and collected-litter state.
        int[,,] visited = new int[rows, cols, 1 << litterCount];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                for (int mask = 0; mask <= allCollected; mask++)
                {
                    visited[r, c, mask] = -1;
                }
            }
        }

        Queue<State> queue = new Queue<State>();

        queue.Enqueue(new State(startR, startC, energy, 0));
        visited[startR, startC, 0] = energy;

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        int moves = 0;

        while (queue.Count > 0)
        {
            int size = queue.Count;

            for (int x = 0; x < size; x++)
            {
                State current = queue.Dequeue();

                int r = current.R;
                int c = current.C;
                int currentEnergy = current.Energy;
                int mask = current.Mask;

                if (mask == allCollected)
                    return moves;

                for (int d = 0; d < 4; d++)
                {
                    int nr = r + dr[d];
                    int nc = c + dc[d];

                    // Outside classroom
                    if (nr < 0 || nr >= rows ||
                        nc < 0 || nc >= cols)
                        continue;

                    // Wall
                    if (classroom[nr][nc] == 'X')
                        continue;

                    // Need energy to make the move
                    if (currentEnergy == 0)
                        continue;

                    int newEnergy = currentEnergy - 1;
                    int newMask = mask;

                    // Collect litter
                    if (classroom[nr][nc] == 'L')
                    {
                        int id = litterId[nr, nc];
                        newMask |= (1 << id);
                    }

                    // Recharge
                    if (classroom[nr][nc] == 'R')
                    {
                        newEnergy = energy;
                    }

                    // If we've already reached this exact
                    // position + mask with MORE energy,
                    // this state is useless.
                    if (visited[nr, nc, newMask] >= newEnergy)
                        continue;

                    visited[nr, nc, newMask] = newEnergy;

                    queue.Enqueue(
                        new State(nr, nc, newEnergy, newMask)
                    );
                }
            }

            moves++;
        }

        return -1;
    }

    private class State
    {
        public int R;
        public int C;
        public int Energy;
        public int Mask;

        public State(int r, int c, int energy, int mask)
        {
            R = r;
            C = c;
            Energy = energy;
            Mask = mask;
        }
    }
}