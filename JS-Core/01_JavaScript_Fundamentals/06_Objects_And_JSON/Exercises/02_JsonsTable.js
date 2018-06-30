function parseJSON(strArr) {
    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    };

    let html = '<table>\n';

    for (let row of strArr) {
        let obj = JSON.parse(row);
        html += '   <tr>\n';
        html += `        <td>${(obj.name).htmlEscape()}</td>\n`;
        html += `        <td>${(obj.position).htmlEscape()}</td>\n`;
        html += `        <td>${(obj.salary).toString().htmlEscape()}</td>\n`;
        html += '<tr>\n';
    }

    html += '</table>';
    console.log(html);
}

parseJSON([
    '{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}',
]);

