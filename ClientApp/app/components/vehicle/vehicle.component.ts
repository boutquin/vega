import { Component } from "@angular/core";
import { Http } from "@angular/http";

@Component({
    selector: "vehicles",
    templateUrl: "./vehicle.component.html"
})
export class VehicleComponent {
    public makes: IMake[];

    constructor(http: Http) {
        http.get("/api/makes").subscribe(result => {
            this.makes = result.json() as IMake[];
        });
    }
}

interface IMake {
    id: number;
    name: string;
    models: IModel[];
}

interface IModel {
    id: number;
    name: string;
}