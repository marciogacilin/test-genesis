import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

interface CalculationCdbRequest {
  initialValue: number;
  months: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public mode: number = 1;
  public calculationResponse: any;
  public formCalculate: FormGroup = new FormGroup({
    'valueInvestment': new FormControl(null, [Validators.required]),
    'period': new FormControl(null, [Validators.required])
  })  

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  calculate() {
    let request: CalculationCdbRequest = {
      initialValue: this.formCalculate.value.valueInvestment,
      months: this.formCalculate.value.period
    }

    this.http.post('/api/calculationcdb', request).subscribe({
      next: (data) => {
        this.calculationResponse = data;
        this.mode = 2;
      },
      error: (error) => alert(error.error.errors[0])
    })
  }

  back() {
    this.mode = 1;
  }

  formatValue(event: any) {
    let value = event.target.value.replace(/[^0-9]/g, '');
    event.target.value = value;
  }

  title = 'testgenesis.client';
}
