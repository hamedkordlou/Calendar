import { CalendarService } from './../services/calendar.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  displayDetails = false;
  monthes: any[];
  month: any;
  appointments: any[];
  appointment: any;
  attendees: any[];

  constructor(private calendarService: CalendarService) { }

  ngOnInit() {
    this.calendarService.getMonthes().subscribe((monthes: any[]) => {
      this.monthes = monthes;
      // console.log('MONTHES', this.monthes);
    });

  }

  onMonthClick(monthId) {
    // console.log('MONTH', monthId);
    this.calendarService.getAppointments(monthId).subscribe((appointments: any[]) => {
      this.appointments = appointments;
      this.appointment = {};
      this.displayDetails = false;
      // console.log('APPOINTMENTS', this.appointments);
    });
  }

  onAppointmentClick(appointmentId: number) {
    // console.log('ID', appointmentId);
    this.appointment = this.appointments.find(a => a.id === appointmentId);
    this.attendees = this.appointment.attendees;
    this.displayDetails = true;
    // console.log('ATTENDEES', this.attendees);
  }
}
