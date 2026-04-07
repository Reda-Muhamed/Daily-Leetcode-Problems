public class Robot {
    int w, h;
    int pos = 0; 
    int perimeter; 
    bool hasMoved = false;

    public Robot(int width, int height) {
        w = width;
        h = height;
        perimeter = 2 * (w - 1) + 2 * (h - 1);
    }
    
    public void Step(int num) {
        hasMoved = true;
        pos = (pos + num) % perimeter;
    }
    
    public int[] GetPos() {
        if (pos <= w - 1) 
            return new int[] { pos, 0 }; 
            
        if (pos <= (w - 1) + (h - 1)) 
            return new int[] { w - 1, pos - (w - 1) }; 
            
        if (pos <= 2 * (w - 1) + (h - 1)) 
            return new int[] { (w - 1) - (pos - (w - 1) - (h - 1)), h - 1 }; 
            
        return new int[] { 0, (h - 1) - (pos - 2 * (w - 1) - (h - 1)) }; 
    }
    
    public string GetDir() {
        if (pos == 0) return hasMoved ? "South" : "East";
        
        if (pos <= w - 1) return "East";
        if (pos <= (w - 1) + (h - 1)) return "North";
        if (pos <= 2 * (w - 1) + (h - 1)) return "West";
        return "South";
    }
}