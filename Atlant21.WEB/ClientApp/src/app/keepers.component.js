var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Keepers } from './keepers';
let KeeperComponent = class KeeperComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.Keeper = new Keepers();
        this.tableMode = true;
    }
    ngOnInit() {
        this.loadKeepers(); // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadKeepers() {
        this.dataService.getKeepers()
            .subscribe((data) => this.Keepers = data);
    }
    // сохранение данных
    save() {
        if (this.Keeper.id == null) {
            this.dataService.createKeeper(this.Keeper)
                .subscribe(data => this.loadKeepers());
        }
        else {
            this.dataService.updateKeeper(this.Keeper)
                .subscribe(data => this.loadKeepers());
        }
        this.cancel();
    }
    editKeeper(p) {
        this.Keeper = p;
    }
    cancel() {
        this.Keeper = new Keepers();
        this.tableMode = true;
    }
    delete(p) {
        this.dataService.deleteKeeper(p.id)
            .subscribe(data => this.loadKeepers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
KeeperComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './keepers.component.html',
        providers: [DataService]
    })
], KeeperComponent);
export { KeeperComponent };
//# sourceMappingURL=keepers.component.js.map