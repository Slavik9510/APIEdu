import { Photo } from "./photo.model"

export interface Member {
    id: number
    username: string
    photoUrl: string
    age: number
    dateOfBirth: string
    knownAs: string
    created: string
    lastActive: string
    gender: string
    introduction: string
    lookingFor: string
    interests: string
    country: string
    city: string
    photos: Photo[]
}

