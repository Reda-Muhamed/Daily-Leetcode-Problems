class Solution {

    /**
     * @param Integer $n
     * @return Integer
     */
    function bitwiseComplement($n) {
        $binary = decbin($n);
        $flipped = '';

        for ($i = 0; $i < strlen($binary); $i++) {
            $flipped .= $binary[$i] == '0' ? '1' : '0';
        }

        return bindec($flipped);
    }
}