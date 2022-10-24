function solve() {
    let result = {};
   Array.from(arguments).forEach(x => {
       console.log(`${typeof x}: ${x}`);
        
       if (!result[typeof(x)]) {
           result[typeof(x)] = 0;
       }
       result[typeof(x)] ++;
   });

   Object.keys(result).sort((a,b) => result[b] - result[a]).forEach(x=> console.log(`${x} = ${result[x]}`));
}
solve('cat', 42, function () { console.log('Hello world!'); });