import { RouterModule } from '@angular/router';
import { Events } from '../../Objects/Events';
import { HttpClient, HttpClientModule, HttpResponse, HttpHeaders, HttpParams, HttpRequest } from '@angular/common/http'
import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { map, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-NEDL',
  templateUrl: './NEDL.component.html',
  styleUrls: ['./NEDL.component.css']
})
export class NEDLComponent implements OnInit {
  public results: Events[] = [];
  public showResults: boolean
  public nextEvent: Events
  public theEvent: Events

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Events[]>(baseUrl + 'TheEvents').subscribe(result => {
      this.results = result;
    }, error => console.error(error));
    this.showResults = true;
  }


  ngOnInit(): void {

  }

  //location.origin

  addAnEvent() {
    this.http.get<Events[]>(location.origin + '/theEvents').subscribe(result => {
      this.results = result;
      let theID = this.getNextIDNumber(this.results);
      let theName = document.getElementById('theName') as HTMLInputElement;
      let theLocation = document.getElementById('theLocation') as HTMLInputElement;

      this.nextEvent = {
        id: theID,
        name: theName.value,
        location: theLocation.value
      };
      this.results.push(this.nextEvent);
      this.postEvent(this.nextEvent);

    }, error => console.error(error));
  }

  public postEvent(theEvent: Events) {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    let options = {
      headers: headers
    }

    this.http.post(location.origin + "/theEvents", theEvent, options).subscribe();

  }



  public deleteAnEvent() {
    this.http.get<Events[]>(location.origin + '/theEvents').subscribe(result => {
      this.results = result;
      this.theEvent = this.getEventByID(this.results);

      if (this.theEvent != null) {
        const options = {
          headers: new HttpHeaders({
            'Content-Type': 'application/json'
          }),
          body: this.theEvent
        }



        this.http.delete(location.origin + '/theEvents', options).subscribe(s => {
        })
        let theIndex = this.results.findIndex(i => i.id === this.theEvent.id);
        this.results.splice(theIndex, 1);
      }
      else {
        alert('ID not found. ');
      }
    }, error => console.error(error))

  }


  public getNextIDNumber(theArray: Events[]) {
    let nextId = 0;
    for (let i = 0; i < theArray.length; i++) {
      if (theArray[i].id > nextId) {
        nextId = theArray[i].id;
      }
    }

    return nextId+1;
  }


  public getEventByID(theArray: Events[]) {
    let theEvent;
    let theIDElement = document.getElementById('theID') as HTMLInputElement;
    for (let i = 0; i < theArray.length; i++) {
      if (theArray[i].id == parseFloat(theIDElement.value)) {
        theEvent = theArray[i];
      }
    }

    return theEvent;
  }


}
