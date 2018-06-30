let maria = {
    name: 'maria',
    hello: function (thing) {
        console.log(this.name +  ' says hello ' + thing);
    }
};

maria.hello('world');

let ivan = {name: 'ivan'};
let helloIvan = maria.hello.bind(ivan);

helloIvan('from me');
maria.hello.call(ivan, 'now');
maria.hello.apply(ivan, ['again']);
