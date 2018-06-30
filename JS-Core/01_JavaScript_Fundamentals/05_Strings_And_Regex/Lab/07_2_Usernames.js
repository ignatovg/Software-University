let printUsernames = arr => console.log(arr.map(e => {
    let atSeparated = e.split('@');
    return atSeparated[0] + '.' + atSeparated[1]
        .split('.')
        .map(a => a[0])
        .join('')
})
    .join(', '));

function extactUsernames(inputEmails) {
    let resuts = [];
    for(let email of inputEmails){
        let [alias,domain] = email.split('@');
        let usernames = alias + '.';
        let domainParts = domain.split('.');
        domainParts.forEach(p=>usernames += p[0]);
    }
    console.log(resuts.join(', '))
}