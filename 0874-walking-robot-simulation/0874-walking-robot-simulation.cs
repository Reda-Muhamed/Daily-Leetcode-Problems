public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        // obstacles = [
        //     [2,4],
        //     [5,6]
        // ]
        HashSet<(int, int)> obsSet = new HashSet<(int, int)>();
        foreach (var ob in obstacles) {
            obsSet.Add((ob[0], ob[1]));
        }
        int x = 0,y=0;
        int maxres = 0;
        string dir = "+y";
        foreach(var comand in commands){
            if(comand == -2){
                 switch(dir){
                    case "+y":
                        dir = "-x";
                        break;
                    case "+x":
                        dir = "+y";
                        break;
                    case "-y":
                        dir = "+x";
                        break;
                    case "-x":
                        dir = "-y";
                        break;
                 }
                  
            }
            else if(comand == -1){

                 switch(dir){
                    case "+y":
                        dir = "+x";
                        break;
                    case "+x":
                        dir = "-y";
                        break;
                    case "-y":
                        dir = "-x";
                        break;
                    case "-x":
                        dir = "+y";
                        break;
                 }
            }
            else {
                int val = comand;
                while(val>0){
                    val--;
                    if(dir == "+y"){
                        y++;
                        if (obsSet.Contains((x, y))) {
                            y--;
                             break; 
                        }
                    }
                    else if(dir == "+x"){
                        x++;
                        if (obsSet.Contains((x, y))) {
                            x--;
                             break; 
                        }
                    }
                    else if(dir == "-y"){
                        y--;
                        if (obsSet.Contains((x, y))) {
                            y++;
                             break; 
                        }
                    }
                    else if(dir == "-x"){
                        x--;
                       if (obsSet.Contains((x, y))) {
                            x++;
                             break; 
                        }
                    }
                }
            maxres = Math.Max(((x*x) + (y*y)),maxres );


            }
        }
        return maxres;
    }
    
}