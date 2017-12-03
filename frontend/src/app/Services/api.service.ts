import { Injectable } from '@angular/core';
import { Http } from '@angular/http/src/http';
import { stringify } from 'querystring';
import { Fruta } from '../model';

@Injectable()
export class ApiService {

  private baseURL = 'http://127.0.0.1:5000';

  constructor(private http: Http) { }

  consulta(params: any) {
    return this.http.post(this.baseURL + '/api/consulta/', stringify(params));
  }

  getRecurso(resourceName: string) {
    return this.http.get(this.baseURL + '/api/resource/' + resourceName);
  }

  agregarFruta(resource: Fruta) {
    return this.http.post(this.baseURL + '/api/resource/fruta/', stringify(resource));
  }

  /**
   * this.api.get_Parameters().subscribe(response => {
      this.reportData(response.json());
    }, error => {
      alert('Parametros de Simulación no pudieron ser obtenidos');
    });
   */

  //post_Parameters(data:any) {
  // return this.http.post(this.baseURL + '/api/parametros', JSON.stringify(data));
  // }

}
