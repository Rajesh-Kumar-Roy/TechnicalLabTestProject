import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Technical Lab Test';
  constructor(private toaster: ToastrService){}
  showSuccess() {
    this.toaster.success('Hello world!', 'Toastr fun!');
  }
}
