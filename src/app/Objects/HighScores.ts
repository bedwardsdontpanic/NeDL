import { User } from "./User";

export interface HighScore {
    theScore: number;
//    theUser: User;
    theDate: string;
    theUser: string;
}


function HighScore(theScore, theDate, theUser) {
    this.theScore = theScore;
//    this.theUser = theUser;
    this.theDate = theDate;
    this.theUser = theUser;
}