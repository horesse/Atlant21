import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Keepers } from './keepers';
import { Details } from './details';

@Injectable()
export class DataService {

    private url1 = "/api/keepers";
    private url2 = "/api/details";

    constructor(private http: HttpClient) {
    }

    getKeepers() {
        return this.http.get(this.url1);
    }

    getKeeper(id: number) {
        return this.http.get(this.url1 + '/' + id);
    }

    createKeeper(Keeper: Keepers) {
        return this.http.post(this.url1, Keeper);
    }
    updateKeeper(Keeper: Keepers) {

        return this.http.put(this.url1, Keeper);
    }
    deleteKeeper(id: number) {
        return this.http.delete(this.url1 + '/' + id);
    }

    getDetails() {
        return this.http.get(this.url2);
    }



    getDetail(id: number) {
        return this.http.get(this.url2 + '/' + id);
    }

    createDetail(Detail: Details) {
        return this.http.post(this.url2, Detail);
    }
    updateDetail(Detail: Details) {
        return this.http.put(this.url2, Detail);
    }
}