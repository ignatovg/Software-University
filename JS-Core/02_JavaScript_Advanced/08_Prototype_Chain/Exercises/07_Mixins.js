class Device {
    constructor(manufacturer) {
        if (new.target === Device) {
            throw new Error('Abstract class cannot be instantiated directly.');
        }
        this.manufacturer = manufacturer;
    }
}

class Keyboard extends Device {
    constructor(manufacturer, responseTime) {
        super(manufacturer);
        this.responseTime = Number(responseTime);
    }
}

class Monitor extends Device {
    constructor(manufacturer, width, height) {
        super(manufacturer);
        this.width = Number(width);
        this.height = Number(height);
    }
}

class Battery extends Device {
    constructor(manufacturer, expectedLife) {
        super(manufacturer);
        this.expectedLife = Number(expectedLife);
    }
}

class Computer extends Device {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
        if (new.target === Computer) {
            throw new Error('Abstract class cannot be instantiated directly.');
        }
        super(manufacturer);
        this.processorSpeed = Number(processorSpeed);
        this.ram = Number(ram);
        this.hardDiskSpace = Number(hardDiskSpace);
    }
}

class Laptop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
        super(manufacturer, processorSpeed, ram, hardDiskSpace);
        this.weight = Number(weight);
        this.color = color;
        this.battery = battery;
    }

    get battery() {
        return this._battery;
    }

    set battery(value) {
        if (value instanceof Battery) {
            this._battery = value;
        } else {
            throw new TypeError('Value is not an instance of Battery');
        }
    }
}

class Desktop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
        super(manufacturer, processorSpeed, ram, hardDiskSpace);
        this.keyboard = keyboard;
        this.monitor = monitor;
    }

    get keyboard() {
        return this._keyboard;
    }

    set keyboard(value) {
        if (value instanceof Keyboard) {
            this._keyboard = value;
        } else {
            throw new TypeError('Value is not an instance of Keyboard');
        }
    }

    get monitor() {
        return this._monitor;
    }

    set monitor(value) {
        if (value instanceof Monitor) {
            this._monitor = value;
        } else {
            throw new TypeError('Value is not an instance of Monitor');
        }
    }
}

function createMixins() {
    function computerQualityMixin(classToExtend) {
        classToExtend.prototype.getQuality = function () {
            return (this.processorSpeed + this.ram + this.hardDiskSpace) / 3
        };
        classToExtend.prototype.isFast = function () {
            return this.processorSpeed > (this.ram / 4)
        };
        classToExtend.prototype.isRoomy = function () {
            return this.hardDiskSpace > Math.floor(this.ram * this.processorSpeed)
        }
    }

    function styleMixin(classToExtend) {
        classToExtend.prototype.isFullSet = function () {
            return this.manufacturer === this.keyboard.manufacturer  && this.monitor.manufacturer
        };
        classToExtend.prototype.isClassy = function () {
        return this.battery.expectedLife >= 3
            && (this.color === 'Silver' || this.color === 'Black')
            && this.weight < 3;
        }
    }

    return {
        computerQualityMixin,
        styleMixin
    }
}

createMixins().computerQualityMixin(Laptop);
createMixins().styleMixin(Laptop);
let battery = new Battery('Nakov', 5);
let laptop = new Laptop('Kiirl', 3, 8, 500, 2.2, 'Silver', battery);
console.log(Laptop.prototype);

