import { User } from "./user";
export interface Device {
    deviceID: number;
    name: string;
    manufacturer: string;
    type: string;
    operatingSystem: string;
    osVersion: string;
    processor: string;
    ramAmount: number;
    description: string | null;
    assignedUser: User | null;
}
