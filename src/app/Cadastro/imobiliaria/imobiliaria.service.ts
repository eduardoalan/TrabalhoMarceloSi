import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Imobiliaria } from './models/imobiliaria';
import { Observable } from 'rxjs-compat';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImobiliariaService {

constructor(private http:HttpClient) { }

save(imobiliaria: Imobiliaria): Observable<any>{
  return this.http.post(environment.urlApi+"imobiliarias/", imobiliaria)
  .catch((error: any) => Observable.throw(error));
}

update(imobiliaria: Imobiliaria): Observable<any>{
  return this.http.put(environment.urlApi+"imobiliarias/"+imobiliaria.idImobiliaria, imobiliaria)
  .catch((error: any) => Observable.throw(error));
}

findAll(): Observable<any>{
  return this.http.get(environment.urlApi+"imobiliarias/")
  .catch((error: any) => Observable.throw(error));
}

remove(idImobiliaria: number): Observable<any> {
  return this.http.delete(environment.urlApi+"imobiliarias/"+idImobiliaria)
  .catch((error: any) => Observable.throw(error));
}
}
