function jsonToHtml(strArr) {
    String.prototype.htmlEscape = function () {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    };

    strArr = JSON.parse(strArr);

    let html = '<table>\n';
    html += '   <tr>';
    for (let key of Object.keys(strArr[0])) {
        html += `<th>${key.htmlEscape()}</th>`;
    }
    html += '</tr>\n';
    for (let obj of strArr) {
        html+='   <tr>';
        for (let key of Object.keys(obj)) {
            html+=`<td>${(obj[key]).toString().htmlEscape()}</td>`;
        }
        html+='</tr>\n';
    }
    html += '</table>';
    console.log(html);
}

jsonToHtml('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');