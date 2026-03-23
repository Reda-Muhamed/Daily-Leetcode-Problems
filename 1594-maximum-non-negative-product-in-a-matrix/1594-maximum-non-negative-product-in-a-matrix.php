class Solution
{

    /**
     * @param Integer[][] $grid
     * @return Integer
     */
    function maxProductPath($grid)
    {
        $m = count($grid);
        $n = count($grid[0]);

        $maxDp = $minDp = array_fill(0, $m, array_fill(0, $n, 0));

        $maxDp[0][0] = $minDp[0][0] = $grid[0][0];

        // first row
        for ($j = 1; $j < $n; $j++) {
            $maxDp[0][$j] = $minDp[0][$j] = $minDp[0][$j - 1] * $grid[0][$j];
        }

        // first column
        for ($i = 1; $i < $m; $i++) {
            $maxDp[$i][0] = $minDp[$i][0] = $minDp[$i - 1][0] * $grid[$i][0];
        }
        for ($i = 1; $i < $m; $i++) {
            for ($j = 1; $j < $n; $j++) {
                $maxDp[$i][$j] = max(
                    $maxDp[$i - 1][$j] * $grid[$i][$j],
                    $maxDp[$i][$j - 1] * $grid[$i][$j],
                    $minDp[$i - 1][$j] * $grid[$i][$j],
                    $minDp[$i][$j - 1] * $grid[$i][$j]
                );

                $minDp[$i][$j] = min(
                    $maxDp[$i - 1][$j] * $grid[$i][$j],
                    $maxDp[$i][$j - 1] * $grid[$i][$j],
                    $minDp[$i - 1][$j] * $grid[$i][$j],
                    $minDp[$i][$j - 1] * $grid[$i][$j]
                );
            }
        }

        return $maxDp[$m - 1][$n - 1] < 0 ?-1 : $maxDp[$m - 1][$n - 1]%(1000000007) ;
    }
}
