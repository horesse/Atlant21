import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { KeeperComponent } from './keepers.component';
import { DetailsComponent } from './details.component';
import { AppComponent } from './app.component';

const appRoutes: Routes = [
    { path: 'details', component: DetailsComponent },
    { path: 'keepers', component: KeeperComponent }
];

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, KeeperComponent, DetailsComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }