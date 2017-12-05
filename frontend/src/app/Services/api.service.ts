
import { Injectable } from '@angular/core';
import { Http, RequestOptions, Headers, URLSearchParams } from '@angular/http';
import { stringify } from 'querystring';
import { Fruta } from '../model';

@Injectable()
export class ApiService {

  private baseURL = 'http://localhost:64665';

  constructor(private http: Http) { }

  consulta(params: any) {
    const requestOptions = new RequestOptions();
    requestOptions.headers = new Headers();
    requestOptions.headers.append('Content-Type', 'application/json');
    requestOptions.headers.append('Accept', 'application/json');
    return this.http.post(this.baseURL + '/api/consulta/', params,requestOptions);
  }

  getRecurso(resourceName: string) {
    return this.http.get(this.baseURL + '/api/resource/' + resourceName);
  }

  agregarFruta(resource: Fruta) {
    return this.http.post(this.baseURL + '/api/resource/fruta/', stringify(resource));
  }

  eliminarFruta(resourceName: string) {
    return this.http.delete(this.baseURL + '/api/resource/fruta/' + resourceName);
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
