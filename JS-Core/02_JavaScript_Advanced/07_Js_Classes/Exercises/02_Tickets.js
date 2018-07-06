function getTickets(dataArr, criteria) {
    class Ticket{
        constructor(destination,price,status){
            this.destination= destination;
            this.price = Number(price);
            this.status= status;
        }
    }
    let allTicketArray= [];
    for (let line of dataArr) {
        let [destination,price,status] = line.split('|');
        allTicketArray.push(new Ticket(destination,price,status));
    }
    let sortedTicket = allTicketArray.sort((a,b)=>{
        if(criteria === 'price'){
            return a[criteria]-b[criteria];
        }
        return a[criteria].localeCompare(b[criteria]);
    });

     return sortedTicket;
}

console.log(getTickets(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));