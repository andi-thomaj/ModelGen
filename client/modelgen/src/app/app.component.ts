declare var google: any;
import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'modelgen';

  ngOnInit(): void {
    google.accounts.id.initialize({
      client_id: '38261928520-530d6eme2a2gdku2p88jjmn6puc4r10o.apps.googleusercontent.com',
      callback: (resp: any) => {
        console.log(resp);
      }
    });

    google.accounts.id.renderButton(document.getElementById('google-btn'), {
      theme: 'filled_blue',
      size: 'large',
      shape: 'rectangle',
      width: 350
    });
  }
}
