export class User {
    constructor(private _token: string, private _expiration:string){}

    get token() {
        return this._token;
    }
}
