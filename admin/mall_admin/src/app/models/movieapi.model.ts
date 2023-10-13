import { Time } from "@angular/common";

export class MovieAPI{
    id: number;
    name: string;
    photo: string;
    description: string;
    timeLast: Time;
    dateExpect: Date;
    genre: string;
    language: string;
    status: boolean;
}