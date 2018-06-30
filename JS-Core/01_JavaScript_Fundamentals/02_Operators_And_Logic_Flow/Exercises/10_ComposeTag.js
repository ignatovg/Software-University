function composeImgTag(inputArr) {
    let location = inputArr[0];
    let text = inputArr[1];

    let htmlTag = `<img src="${location}" alt="${text}">`;
    console.log(htmlTag);
}