function splitExpression(text) {
   return text.split(/[\s().,;]+/)
    .filter(e=> e!== '')
        .join('\n');
}

splitExpression('let sum = 4 * 4,b = "wow";');