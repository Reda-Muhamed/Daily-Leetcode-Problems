class Solution {

    /**
     * @param String $n
     * @return Integer
     */
    function minPartitions($n) {
        $temp  = 0;
        for($i = 0;$i<strlen($n);$i++){
            $temp = max($temp,+$n[$i]);
        }
        return $temp;

    }
}