function checkString(text,check) {
   let checkLength = check.length;
   let isStartedWith = text.slice(0,checkLength) === check? true : false;
    console.log(isStartedWith);
}

function startWith(text,check){
   return text.startsWith(check);
}

checkString('how are you ', 'How');