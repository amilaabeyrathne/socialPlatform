export interface IRegistrations {
    participantId: number;
    employeeId: string;
    employeeName: string;
    competitionsId: number;
    teamName: string;
    teamMembers: ITeams[];
    cegId: number;
    tierId: number;
    contact: string;
    isGroup: boolean;
    competitionName: string;
    teamPath: string;
    teamId: number;
}

export interface ICompetitions {
    id: number,
    name: string,
    type: string,
    eventCode: number,
    description: string,
    registrationEndDate: Date,
    editedOn: Date
}

export interface ICegs {
    id: number;
    name: string;
}

export interface ITiers {
    id: number;
    name: string;
}

export interface ITeams {
    id: string;
    name: string;
}

export interface IParticipants {
    teamId: number;
    employeeId: number;
    employeeName: string;
}




