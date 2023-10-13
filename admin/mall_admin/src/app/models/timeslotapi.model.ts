import { Time } from "@angular/common";

export class TimeSlotAPI {
    id: number;
    name: string;
    startTime: Time;
    endTime: Time;
    status: boolean;
}