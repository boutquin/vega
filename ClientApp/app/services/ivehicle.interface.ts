import { IFeature } from "./imake.interface";

export interface IVehicle {
    id: number;
    name: string;
    isRegistered: boolean;
    contactName: string;
    contactPhone: string;
    contactEMail: string;
    makeId: string;
    modelId: string;
    features: IFeature[];
}