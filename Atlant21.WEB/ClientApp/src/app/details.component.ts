import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Details } from './details';
import { Keepers } from './keepers';

@Component({
    selector: 'details-app',
    templateUrl: './details.component.html',
    providers: [DataService]
})
export class DetailsComponent implements OnInit {

    Detail: Details = new Details();
    Details: Details[];
    Keepers: Keepers[];
    tableMode: boolean = true;

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadDetails();
        this.loadKeepers();
    }

    loadKeepers() {
        this.dataService.getKeepers()
            .subscribe((data: Keepers[]) => this.Keepers = data);
    }

    loadDetails() {
        this.dataService.getDetails()
            .subscribe((data: Details[]) => this.Details = data);
    }

    save() {
        if (this.Detail.id == null) {
            this.dataService.createDetail(this.Detail)
                .subscribe(data => this.loadDetails());
        } else {
            this.dataService.updateDetail(this.Detail)
                .subscribe(data => this.loadDetails());
        }


        this.cancel();
    }

    deleteDetail(p: Details) {
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
}