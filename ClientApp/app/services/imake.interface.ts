export interface IMake {
    id: number;
    name: string;
    models: IModel[];
}

export interface IModel {
    id: number;
    name: string;
    features: IFeature[];
}

export interface IFeature {
    id: number;
    name: string;
}