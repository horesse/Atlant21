var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Details } from './details';
let DetailsComponent = class DetailsComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.Detail = new Details();
        this.tableMode = true;
    }
    ngOnInit() {
        this.loadDetails();
        this.loadKeepers();
    }
    loadKeepers() {
        this.dataService.getKeepers()
            .subscribe((data) => this.Keepers = data);
    }
    loadDetails() {
        this.dataService.getDetails()
            .subscribe((data) => this.Details = data);
    }
    save() {
        if (this.Detail.id == null) {
            this.dataService.createDetail(this.Detail)
                .subscribe(data => this.loadDetails());
        }
        else {
            this.dataService.updateDetail(this.Detail)
                .subscribe(data => this.loadDetails());
        }
        this.cancel();
    }
    deleteDetail(p) {
        this.Detail = p;
        this.save();
    }
    cancel() {
        this.Detail = new Details();
        this.tableMode = true;
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
DetailsComponent = __decorate([
    Component({
        selector: 'details-app',
        templateUrl: './details.component.html',
        providers: [DataService]
    })
], DetailsComponent);
export { DetailsComponent };
//# sourceMappingURL=details.component.js.map