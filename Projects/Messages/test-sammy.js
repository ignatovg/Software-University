$(()=>{
  
    const app = Sammy('#main', function(){
        this.use('Handlebars', 'hbs')

        this.get('index.html',function(){
            this.name = 'peshsso';
            this.partial('./templates/greeting.hbs');
        })
    })
    app.run();
});