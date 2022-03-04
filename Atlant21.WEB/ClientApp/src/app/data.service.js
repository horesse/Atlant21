var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Injectable } from '@angular/core';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.url1 = "/api/keepers";
        this.url2 = "/api/details";
    }
    getKeepers() {
        return this.http.get(this.url1);
    }
    getKeeper(id) {
        return this.http.get(this.url1 + '/' + id);
    }
    createKeeper(Keeper) {
        return this.http.post(this.url1, Keeper);
    }
    updateKeeper(Keeper) {
        return this.http.put(this.url1, Keeper);
    }
    deleteKeeper(id) {
        return this.http.delete(this.url1 + '/' + id);
    }
    getDetails() {
        return this.http.get(this.url2);
    }
    getDetail(id) {
        return this.http.get(this.url2 + '/' + id);
    }
    createDetail(Detail) {
        return this.http.post(this.url2, Detail);
    }
    updateDetail(Detail) {
        return this.http.put(this.url2, Detail);
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=data.service.js.map