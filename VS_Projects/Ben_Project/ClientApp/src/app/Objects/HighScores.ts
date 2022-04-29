import { User } from "./User";

export interface HighScore {
  score: number;
  name: string;
}


function HighScore(score, name) {
    this.score = score;
    this.name = name;
}
