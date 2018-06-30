function HTMLEscaping(data) {
    String.prototype.htmlEscape = function() {
        return this.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
    let result = [];
    result.push('<ul>');
    for (let i = 0; i < data.length; i++) {
        result.push(`  <li>${data[i].htmlEscape()}</li>`);
    }
    result.push('</ul>');

    console.log(result.join('\n'));
}
HTMLEscaping(['<b>unescaped text</b>', 'normal text']);