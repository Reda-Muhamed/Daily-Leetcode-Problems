public class Solution {
   public string AddBinary(string a, string b)
{
    int i = a.Length - 1;
    int j = b.Length - 1;
    int carry = 0;
    var res = new StringBuilder();

    while (i >= 0 || j >= 0 || carry > 0)
    {
        int sum = carry;
        if (i >= 0) sum += a[i--] - '0';
        if (j >= 0) sum += b[j--] - '0';

        res.Append(sum % 2);
        carry = sum / 2;
    }

    char[] arr = res.ToString().ToCharArray();
    Array.Reverse(arr);
    return new string(arr);
}

}