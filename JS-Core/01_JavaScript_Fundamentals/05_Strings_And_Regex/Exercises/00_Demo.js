let lookAheadBehind = /(?<=\s)([A-Za-z]+)([\d]+)(?=\s)/;
let negative = /(?<!\s)\b([A-Za-z]+)([\d]+)\b(?=\s)/;
let caputreGroups = /([A-Za-z]+)([\d]+)(?:\s)/;