function scoreHtml(strArr) {
    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    };

    strArr = JSON.parse(strArr);
    let html = '<table>\n';
    html += '   <tr><th>name</th><th>score</th></tr>\n';
    for (let row of strArr) {
        html+= `   <tr><td>${row.name.htmlEscape()}</td><td>${row.score}</td></tr>\n`;
    }
    html+= '</table>';
    console.log(html);
}

scoreHtml('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');