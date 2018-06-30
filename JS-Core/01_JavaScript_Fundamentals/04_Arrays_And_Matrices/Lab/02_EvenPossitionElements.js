let elements = params => params.filter((e,i)=> i % 2 ==0).join(' ');

console.log(elements(['20', '30', '40']));;