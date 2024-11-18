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
            let jj =k
            for(let j = (i+1)%n ; ;j=(j+1)%n){
                if(jj>0)
                sum+=code[j]
                else break
                jj--;
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