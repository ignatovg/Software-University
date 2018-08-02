$(()=>{
   const main = $('#main');
    getTemplate();

   async function getTemplate() {
       let template = await $.get('greeting.html');
      main[0].innerHTML+=(parse(template, 'World'));
       main[0].innerHTML+=(parse(template, 'Pesho'));
   }

   function parse(htmlAssString ,name) {
      return htmlAssString.replace(/{{name}}/g, name);
   }
});