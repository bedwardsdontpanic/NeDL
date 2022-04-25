import { Component, OnInit, ViewChild } from '@angular/core';
import { Theme } from '@fullcalendar/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CountdownModule, CountdownComponent } from 'ngx-countdown';
import { HighScore } from 'src/app/Objects/HighScores';


@Component({
  selector: 'app-brain-game',
  templateUrl: './brain-game.component.html',
  styleUrls: ['./brain-game.component.css']
})
export class BrainGameComponent implements OnInit {
  Var1: number;
  Var2: number;
  trueAns: number;
  correct: boolean;
  ans1: number;
  ans2: number;
  ans3: number;
  ans4: number;
  showGame: boolean;
  showStart: boolean;
  questionsRemaing: number;
  numOfCorrectAns: number;
  showResults: boolean;
  showConfetti: boolean;
  timeData;
  nextResult: HighScore;
  results: HighScore[];
  @ViewChild('countdown') counter: CountdownComponent;

  constructor(private modalService: NgbModal) { }

  ngOnInit(): void {

    this.changeVars(this.Var1, this.Var2, this.trueAns, this.correct);
    this.showGame = false;
    this.showStart = true;
    this.showResults = false;
    this.numOfCorrectAns = 0;
    this.showConfetti = false;
    this.timeData = "0"
    this.nextResult = null;
    this.results = new Array<HighScore>(10);

  }

  startGame() {
    this.showResults = false;
    this.timeData = "60";
    this.counter.restart();
    this.numOfCorrectAns = 0;
    this.questionsRemaing = 10;
    console.log('game started');
    this.showGame = true;
    this.showStart = false;
    this.showConfetti = false;
    this.changeVars(this.Var1, this.Var2, this.trueAns, this.correct);

  }

  changeVars(Var1, Var2, ans, correct) {
    this.Var1 = Math.floor(Math.random() * 101);
    this.Var2 = 100 - this.Var1;
    this.trueAns = this.Var1 - this.Var2;
    let ansOrder = Math.floor(Math.random() * 11);
    if (ansOrder >= 0 && ansOrder <= 2) {
          this.ans1 = this.Var2;
          this.ans2 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
          this.ans3 = this.Var2 - Math.floor(Math.random() * (10 - 1) + 1);
          this.ans4 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
      } else if (ansOrder >= 3 && ansOrder <= 5) {
          this.ans2 = this.Var2;
          this.ans1 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
          this.ans3 = this.Var2 - Math.floor(Math.random() * (10 - 1) + 1);
          this.ans4 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
      } else if (ansOrder >= 6 && ansOrder <= 8) {
          this.ans3 = this.Var2;
          this.ans1 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
          this.ans2 = this.Var2 - Math.floor(Math.random() * (10 - 1) + 1);
          this.ans4 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
      } else if (ansOrder >= 9 && ansOrder <= 11) {
          this.ans4 = this.Var2;
          this.ans1 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
          this.ans2 = this.Var2 - Math.floor(Math.random() * (10 - 1) + 1);
          this.ans3 = this.Var2 + Math.floor(Math.random() * (10 - 1) + 1);
    }
  }

  correctorIncorrect(inputted: number) {
    if (inputted === this.Var2) {
        this.correct = true;
        console.log('right');
        this.changeVars(this.Var1, this.Var2, this.trueAns, this.correct);
        this.numOfCorrectAns ++;
        this.questionsRemaing --;
    } else {
      this.correct = false;
      console.log('wrong');
      this.changeVars(this.Var1, this.Var2, this.trueAns, this.correct);
      this.questionsRemaing --;
    }
    if (this.questionsRemaing === 0) {
      this.endGame();
    }
  }

  endGame() {
    this.nextResult = {
      theScore: this.counter.left + (this.numOfCorrectAns*100000),
      theDate: new Date().toTimeString(),
      theUser: 'User X'
    };
    
    console.log(this.nextResult.theDate);
    console.log(this.nextResult.theScore);
//    this.results.push(this.nextResult);

    for(let i = 0; i < this.results.length; i++){
      if(this.results[i] == null){
        this.results[i] = this.nextResult;
        break;
      }
    }

    this.showGame = false;
    this.showStart = false;
    this.showResults = true;
    this.showConfetti = true;
    this.counter.stop();
    console.log('Game Over');

  }

}
