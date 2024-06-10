import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Administrador de tareas';
  userData = {
    username: '',
    password: ''
  };

  onSubmit() {
    // Aquí puedes manejar la lógica de inicio de sesión, como enviar los datos al servidor, etc.
    console.log('Datos de inicio de sesión:', this.userData);
  }
}
