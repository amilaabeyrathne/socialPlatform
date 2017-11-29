export interface IAttendance {
    id: number,
    employeeId: string,
    employeeName: string,
    sessionId: number,
    competitionId: number,
    dateCreated: string,
    createdBy: string,
    isDelete: boolean
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

export interface ISessions {
    id: number,
    sessionName: string,
    trainer: string,
    sessionDate: string
}