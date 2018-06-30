function printTable(n) {
    let html = `<table border="1">\n`;

    html += `<tr><th>x</th>`;
    for (let i = 1; i <= n; i++) {
        html += `<th>${i}</th>`
    }
    html += `</tr>\n`;


    for (let row = 1; row <= n; row++) {
        let count = row;
        html += `<tr><th>${row}</th><td>${row}</td>`;
        for (let col = 2; col <= n; col++) {
            html += `<td>${count+=row}</td>`
        }
        html += `</tr>\n`;
    }

    html+=`</table>\n`;
    console.log(html);
}

printTable(5);