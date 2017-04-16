import { Component } from "@angular/core";
import { Http } from "@angular/http";

import { IMake } from "../../services/imake.interface";

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