import { Component, OnInit } from "@angular/core";

import { IMake, IModel, IFeature } from "../../services/imake.interface";
import { IVehicle } from  "../../services/ivehicle.interface";
import { MakeService } from "./../../services/make.service";

@Component({
    selector: "app-vehicle-form",
    templateUrl: "./vehicle-form.component.html",
    styleUrls: ["./vehicle-form.component.css"]
})
export class VehicleFormComponent implements OnInit {
    makes: IMake[];
    models: IModel[];
    features : IFeature[];
    vehicle: IVehicle = {
        id: null,
        name: null,
        isRegistered: null,
        contactName: null,
        contactPhone: null,
        contactEMail: null,
        makeId: null,
        modelId: null,
        features: null,
    };

    constructor(
        private makeService: MakeService) { }

    ngOnInit() {
        this.makeService.getMakes().subscribe(result => {
            this.makes = result as IMake[];
            // console.log("MAKES:", this.makes);
        });
    }

    onMakeChange() {
        // console.log("MAKE VEHICLE:", this.vehicle);

        if (this.vehicle.makeId === null) {
            this.models = [];
        } else {
            const selectedMake = this.makes.find(m => m.id.toString() === this.vehicle.makeId);

            if (selectedMake === undefined || selectedMake === null) {
                this.models = [];
                this.vehicle.makeId = null;
            } else {            
                this.models = selectedMake.models;
            }
        }

        this.vehicle.modelId = null;
        this.features = [];            
    }

    onModelChange() {
        // console.log("MODEL VEHICLE:", this.vehicle);

        if (this.vehicle.modelId === null) {
            this.features = [];
        } else {
            const selectedModel = this.models.find(m => m.id.toString() === this.vehicle.modelId);

            this.features = selectedModel ? selectedModel.features : [];
        }
    }
}
