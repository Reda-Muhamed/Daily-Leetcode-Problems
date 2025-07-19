public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Array.Sort(folder);  
        List<string> result = new List<string>();
        
        foreach (var path in folder) {
            if (result.Count == 0 || !path.StartsWith(result[result.Count - 1] + "/")) {
                result.Add(path);
            }
        }
        
        return result;
    }
}
