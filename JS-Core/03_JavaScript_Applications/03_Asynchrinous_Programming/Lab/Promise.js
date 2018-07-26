class Promise {
    constructor(executor) {
        this._resolve = function (data) {};
        this._reject = function (reason) {};
        this.resolve = this.resolve.bind(this);
        this.reject = this.reject.bind(this);
        try {
            executor(this.resolve, this.reject);
        }catch (e) {
            this.reject(e);
        }
    }

    resolve(data) {
        this._resolve(data);
    }

    reject(reason) {
        this._reject(reason)
    }

    then(func) {
        this._resolve = func;
        return this;
    }

    catch(funk) {
        this._reject = funk;
    }
}