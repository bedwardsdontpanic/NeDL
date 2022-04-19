import { Component, OnInit, HostListener } from '@angular/core';
import { UserService } from '../../Services/user.service';
import { Router } from '@angular/router';
import { SessionService } from '../../Services/session.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  arr: string[] = [];

  ngOnInit() {
    if (this.vals.drFillerStopper < 1) {

    if (this.vals.doctors = []) {
      this.setDoc.getAllIns().subscribe(
        (data: any) => {
          this.vals.insurance = data;
        }
      );
      this.setDoc.getAllDocs().subscribe(
        (data: any): => {

          data.forEach((element: any) => {
            this.vals.insurance.forEach((ele: any) => {
              if (ele.ins_npi === element.doc_npi) {
                element.Insurance = ele.ins_name;
              }

            });
            // tslint:disable-next-line: no-string-literal
            this.vals.spec = element['spec'];
            // tslint:disable-next-line: no-string-literal
            this.vals.cond = element['cond'];
            this.vals.cond.forEach((el: any) => {
              this.arr.push(el.cond_name);
            });
            this.vals.doctors.push({
              doc_npi: element.doc_npi,
              about_me: element.about_me,
              address: element.address,
              city: element.city,
              doc_email: element.doc_email,
              doc_exp: element.doc_exp,
              doc_name: element.doc_name,
              doc_password: element.doc_password,
              doc_phone_number: element.doc_phone_number,
              num_of_followers: element.num_of_followers,
              Specialty: this.vals.spec.specialtyname,
              Condition: this.arr,
              Rating: element.Rating,
              Insurance: element.Insurance
            });
            this.arr = [];

          });

        });

    }
    this.vals.drFillerStopper++;
  }
}

  @HostListener('window:popstate', ['$event'])
  onPopState(event: any) {
    this.routerMod.navigate(['#']);
  }


  constructor(private rev: UserService, private routerMod: Router, private setDoc: DoctorService,
  private ses: SessionService) { }
  
  RevLoggin(email: string, password: string) {
    // tslint:disable-next-line: no-conditional-assignment
    if (this.vals.doctors = []) {
      this.setDoc.getAllIns().subscribe(
        data => {
          this.vals.insurance = data;
        }
      );
      this.setDoc.getAllDocs().subscribe(
        data => {
          data.forEach(element => {
            this.vals.insurance.forEach(ele => {
              if (ele.ins_npi === element.doc_npi) {
                element.Insurance = ele.ins_name;
              }

            });
            // tslint:disable-next-line: no-string-literal
            this.vals.spec = element['spec'];
            // tslint:disable-next-line: no-string-literal
            this.vals.cond = element['cond'];
            this.vals.cond.forEach(el => {
              this.arr.push(el.cond_name);
            });
            this.vals.doctors.push({
              doc_npi: element.doc_npi,
              about_me: element.about_me,
              address: element.address,
              city: element.city,
              doc_email: element.doc_email,
              doc_exp: element.doc_exp,
              doc_name: element.doc_name,
              doc_password: element.doc_password,
              doc_phone_number: element.doc_phone_number,
              num_of_followers: element.num_of_followers,
              Specialty: this.vals.spec.specialtyname,
              Condition: this.arr,
              Rating: element.Rating,
              Insurance: element.Insurance
            });
            this.arr = [];

          });

        });
      this.rev.retrieveRev(email, password).subscribe(
        data => {
          if (data == null) {
            this.routerMod.navigate(['/login']);
          } else {
            this.ses.loginRevRequest(email, password).subscribe(
              // tslint:disable-next-line: no-shadowed-variable
              data => {
                this.vals.loggedRev = data;
              }
            );
            setTimeout(() => {this.routerMod.navigate(['/filter'])},1000);
          }
        }
      );
    }

  }

  DocLoggin(docEmail, docPassword) {
    this.ses.loginDocRequest(docEmail, docPassword).subscribe(
      data => {
        this.vals.loggedDoc = data;
      }
    );
    // tslint:disable-next-line: no-conditional-assignment

    this.setDoc.retrieveDoctor(docEmail, docPassword).subscribe(
      data => {
        if (data == null) {
          this.routerMod.navigate(['/login']);
        } else {
          setTimeout(() => {this.routerMod.navigate(['/dochome', data.doc_name])},1000);
          ;
        }
      }
    );
  }
}

