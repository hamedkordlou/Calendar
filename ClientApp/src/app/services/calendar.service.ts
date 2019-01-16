import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {

  constructor(private http: HttpClient) { }

  initial() {
    return this.http.get('/api/general');
  }

  getMonthes() {
    return this.http.get('/api/calendar');
  }
  getAppointments(monthId) {
    return this.http.get('/api/calendar/' + monthId);
  }
}
