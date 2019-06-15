import { Component, OnInit } from '@angular/core';
import { Imovel } from './models/imovel.ts';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ImovelService } from './imovel.service';
import { Imobiliaria } from '../imobiliaria/models/imobiliaria';
import { ImobiliariaService } from '../imobiliaria/imobiliaria.service';

@Component({
  selector: 'app-imovel',
  templateUrl: './imovel.component.html',
  styleUrls: ['./imovel.component.css']
})
export class ImovelComponent implements OnInit {

  displayedColumns: string[] = ['actionsColumn', 'codigo', 'estado', 'cidade', 'rua', 'numero', 'cep', 'id'];
  imovel: Imovel;
  teste: any;
  imovels: Imovel[];
  imobiliarias: Imobiliaria[];  
  dataSource: any;
  edit: boolean;

  paginator: MatPaginator;
  sort: MatSort;

  constructor(private Service: ImovelService, private imobiliariaService : ImobiliariaService) { }

  ngOnInit() {
    this.imovel = new Imovel();
    this.imovels = new Array<Imovel>();
    this.imobiliarias = new Array<Imobiliaria>();
    this.imobiliariaService.findAll().subscribe(subscribe =>{
      this.imobiliarias = subscribe;
    })
    this.listAll();
  }
  listAll(){
    this.Service.findAll().subscribe(response => {
      if (response)
        this.loadTable(response);
        console.log(response);
    }, error => {
      console.log(error);
    });
  }

  loadTable(imovels: any){
    this.dataSource = new MatTableDataSource<Imovel>(imovels);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  salvar(){
    this.Service.save(this.imovel).subscribe(response => {
      if (response){
        alert('Salvou!!!!');
        this.listAll();
      }
    }, error => {
      console.log(error);
    });
    this.imovel = new Imovel();
  }

  excluir(IdImovel: number){
    this.Service.remove(IdImovel).subscribe(response => {
      if (response)
        alert('Deletou');      
        this.listAll();
    }, error => {
      console.log(error);
    });
  }

  markEdit(imovel: any){
    this.imovel = imovel;
    this.edit = true;
  }

  atualizar(){
    this.Service.update(this.imovel).subscribe(response => {
      if (response){
        alert('Atualizou!!!!');
        this.listAll();
        this.edit = false;
        this.imovel = new Imovel();
      }        
    }, error => {
      console.log(error);
    });
  }

}
