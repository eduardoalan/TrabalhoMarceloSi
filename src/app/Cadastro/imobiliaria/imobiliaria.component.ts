import { Component, OnInit } from '@angular/core';
import { Imobiliaria } from './models/imobiliaria';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { ImobiliariaService } from './imobiliaria.service';

@Component({
  selector: 'app-imobiliaria',
  templateUrl: './imobiliaria.component.html',
  styleUrls: ['./imobiliaria.component.css']
})
export class ImobiliariaComponent implements OnInit {

  displayedColumns: string[] = ['actionsColumn','codigo', 'nome'];
  imobiliaria: Imobiliaria;
  teste: any;
  imobiliarias: Imobiliaria[];
  dataSource: any;
  edit: boolean;

  paginator: MatPaginator;
  sort: MatSort;
  constructor(private Service: ImobiliariaService) { }

  ngOnInit() {
    this.imobiliaria = new Imobiliaria();
    this.imobiliarias = new Array<Imobiliaria>();
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

  loadTable(imobiliarias: any){
    this.dataSource = new MatTableDataSource<Imobiliaria>(imobiliarias);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  salvar(){
    this.Service.save(this.imobiliaria).subscribe(response => {
      if (response){
        alert('Salvou!!!!');
        this.listAll();
      }
    }, error => {
      console.log(error);
    });
    this.imobiliaria = new Imobiliaria();
  }

  excluir(IdImobiliaria: number){
    this.Service.remove(IdImobiliaria).subscribe(response => {
      if (response)
        alert('Deletou');      
        this.listAll();
    }, error => {
      console.log(error);
    });
  }

  markEdit(imobiliaria: any){
    this.imobiliaria = imobiliaria;
    this.edit = true;
  }

  atualizar(){
    this.Service.update(this.imobiliaria).subscribe(response => {
      if (response){
        alert('Atualizou!!!!');
        this.listAll();
        this.edit = false;
        this.imobiliaria = new Imobiliaria();
      }        
    }, error => {
      console.log(error);
    });
  }


}
