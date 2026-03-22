class Solution
{

    /**
     * @param Integer[][] $mat
     * @param Integer[][] $target
     * @return Boolean
     */
    function findRotation($mat, $target)
    {
        if ($mat == $target) return true;
         $rotations = count($mat)+1;
        while ($rotations--) {
            $mat = $this->rotate($mat);
            if ($mat == $target) return true;
        }
        return false;
    }
    function rotate($mat)
    {
        $n = count($mat);

        $rotated = array();
        for ($i = 0; $i < $n; $i++) {
            for ($j = 0; $j < $n; $j++) {
                $rotated[$j][$n - 1 - $i] = $mat[$i][$j];
            }
        }
        return $rotated;
    }
}
