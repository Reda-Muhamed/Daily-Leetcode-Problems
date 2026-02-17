public class Solution {
    public IList<string> ReadBinaryWatch(int turnedOn) {
        var result = new List<string>();

        for (int hour = 0; hour < 12; hour++) {
            for (int minute = 0; minute < 60; minute++) {

                int bits = CountBits(hour) + CountBits(minute);

                if (bits == turnedOn) {
                    result.Add($"{hour}:{minute:D2}");
                }
            }
        }

        return result;
    }

    private int CountBits(int num) {
        int count = 0;
        while (num > 0) {
            count += num & 1;
            num >>= 1;
        }
        return count;
    }
}
