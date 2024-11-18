/**
 * @param {number[]} code
 * @param {number} k
 * @return {number[]}
 */
var decrypt = function(code, k) {
    let n = code.length 
    let res=[]
    if(!k){
       return res= code.map((el)=>0)
    }else if(k>0){
        for(let i = 0;i<n;i++){
            let sum = 0;
            for(let j = 1 ;j<=k ;j++){
                sum+=code[(j+i+n)%n]
            
            }
            res.push(sum)
        }
    }else{
      for(let i = 0;i<n;i++){
                    let sum = 0;
         for (let j = 1; j <= -k; j++) {
                sum += code[(i - j + n) % n];
            }
            res.push(sum)
        }
    }
    return res
};