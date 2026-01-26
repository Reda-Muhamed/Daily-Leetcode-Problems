public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        int len = arr.Length;
        int min=100000000;
        Array.Sort(arr);
        for(int i = 0;i<len-1;i++){
            min= Math.Min(min,Math.Abs(arr[i+1]-arr[i]));
        }
          List<List<int>> result=new List<List<int>>();

        for(int i = 0;i<len-1;i++){
              if(Math.Abs(arr[i+1]-arr[i])==min){
                result.Add([arr[i],arr[i+1]]);
              }
        }
        IList<IList<int>> result1 = result
            .Select(inner => (IList<int>)inner)
            .ToList();

        return  result1;


    }
}