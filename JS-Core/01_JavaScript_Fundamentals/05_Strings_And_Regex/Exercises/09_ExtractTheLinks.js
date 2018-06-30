function extractLinks(text) {
    let pattern = /www\.[a-zA-Z0-9-]+(\.[a-z]+)+/g;
    let links = [];
    let match = pattern.exec(text);
    while (match) {
        links.push(match[0]);
        match =pattern.exec(text);
    }

    console.log(links.join('\n'));
}

extractLinks('Join WebStars now for free, at www.web-stars.com\n' +
    'You can also support our partners:\n' +
    'Internet - www.internet.com\n' +
    'WebSpiders - www.webspiders101.com\n' +
    'Sentinel - www.sentinel.-ko \n');