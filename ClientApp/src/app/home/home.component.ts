import { CalendarService } from '../services/calendar.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  constructor(private calendarService: CalendarService) { }

  onInitClick() {
    this.calendarService.initial().toPromise();
    alert('Now check the calendar tab');
  }

}
