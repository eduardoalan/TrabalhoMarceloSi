import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Imovel } from './models/imovel.ts';
import { Observable } from 'rxjs-compat';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ImovelService {

constructor(private http:HttpClient) { }

save(imovel: Imovel): Observable<any>{
  return this.http.post(environment.urlApi+"imovels/", imovel)
  .catch((error: any) => Observable.throw(error));
}

update(imovel: Imovel): Observable<any>{
  return this.http.put(environment.urlApi+"imovels/"+imovel.idImovel, imovel)
  .catch((error: any) => Observable.throw(error));
}

findAll(): Observable<any>{
  return this.http.get(environment.urlApi+"imovels/")
  .catch((error: any) => Observable.throw(error));
}

remove(idImovel: number): Observable<any> {
  return this.http.delete(environment.urlApi+"imovels/"+idImovel)
  .catch((error: any) => Observable.throw(error));
}

}
