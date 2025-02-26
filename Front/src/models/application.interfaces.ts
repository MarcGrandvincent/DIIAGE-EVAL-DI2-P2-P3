export interface IApplicationResponse {
  id: string,
  name: string,
  applicationType: ApplicationType
}

export enum ApplicationType {
  Public = 1,
  Professional
}
