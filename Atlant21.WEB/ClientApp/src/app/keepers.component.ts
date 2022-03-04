import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Keepers } from './keepers';

@Component({
    selector: 'app',
    templateUrl: './keepers.component.html',
    providers: [DataService]
})
export class KeeperComponent implements OnInit {

    Keeper: Keepers = new Keepers();
    Keepers: Keepers[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadKeepers();    // загрузка данных при старте компонента  
    }
    // получаем данные через сервис
    loadKeepers() {
        this.dataService.getKeepers()
            .subscribe((data: Keepers[]) => this.Keepers = data);
    }
    // сохранение данных
    save() {
        if (this.Keeper.id == null) {
            this.dataService.createKeeper(this.Keeper)
                .subscribe(data => this.loadKeepers());
        } else {
            this.dataService.updateKeeper(this.Keeper)
                .subscribe(data => this.loadKeepers());
        }
        this.cancel();
    }
    editKeeper(p: Keepers) {
        this.Keeper = p;
    }
    cancel() {
        this.Keeper = new Keepers();
        this.tableMode = true;
    }
    delete(p: Keepers) {
        this.dataService.deleteKeeper(p.id)
            .subscribe(data => this.loadKeepers());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
}