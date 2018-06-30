function mySort(a, b) {
    let aLength = a[0].length;
    let bLength = b[0].length;

   let firstCriteria = aLength - bLength;
   if(firstCriteria !== 0){
       return firstCriteria;
   }else {
       return a[0].localeCompare(b[0]);  //alphabetical sort
   }
}