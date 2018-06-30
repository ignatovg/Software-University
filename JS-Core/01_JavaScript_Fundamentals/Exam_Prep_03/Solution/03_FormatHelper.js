function formatHelper(inputStr) {
    let regex = new RegExp(`\\b${something}\\b`,'g');

    let text = inputStr[0];
    text = text
        .replace(/[.,!?:;]\s*/g,(match) => match.trim()+' ');
    text = text
        .replace(/\s+[.,!?:;]/g, (match) => match.trim());
    text = text
        .replace(/\.\s*\.\s*\.\s*\!/g, '...!');
    text = text
        .replace(/(\.\s+)(\d+)/g,
            (match, g1 ,g2) => g1.trim() + g2);
    text = text
        .replace(/\"(\s*[^"]+\s*)\"/g,
            (match,g1) => `"${g1.trim()}"`);
    console.log(text);
}

formatHelper([
    `Terribly formatted text . With chaotic spacings." Terrible quoting "! Also
this date is pretty confusing : 20 . 12. 16 .`
]);