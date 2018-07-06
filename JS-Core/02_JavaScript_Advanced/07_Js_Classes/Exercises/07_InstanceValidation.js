class CheckingAccount {
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }
    get clientId(){return this._clientId;}
    set clientId (value){
        let pattern = /^\d{6}$/g;
        if(!pattern.test(value)){
            throw new TypeError('Client ID must be a 6-digit number')
        }
        this._clientId = value;
    }
    get email(){return this._email;}
    set email(value){
        let pattern  = /^[A-Za-z]+@[A-Za-z.]+$/g;
        if(!pattern.test(value)){
            throw new TypeError('Invalid e-mail');
        }
        this._email =value;
    }

    get firstName(){return this._firstName;}
    set firstName(value){
        this.firstLastNameLengthValidation(value,'First');
        this.firstLastNameCharacterValidation(value,'First');
        this._firstName = value;
    }

    get lastName(){return this._lastName;}
    set lastName(value){
        this.firstLastNameLengthValidation(value,'Last');
        this.firstLastNameCharacterValidation(value,'Last');
        this._lastName = value;
    }

    firstLastNameLengthValidation(value,name){
        let pattern =/^.{3,20}$/g;
        if(!pattern.test(value)){
            throw new TypeError(`${name} name must be between 3 and 20 characters long`)
        }
    }
    firstLastNameCharacterValidation(value,name){
        let pattern  =/^[A-Za-z]+$/g;
        if(!pattern.test(value)){
            throw new TypeError(`${name} name must contain only Latin characters`)
        }
    }
}

let acc = new CheckingAccount('131455', 'ivan@some.com', 'Ivan', 'P3trov')