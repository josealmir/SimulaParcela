import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Simulacao } from './model/simulacao';
import { SimulacaoService } from './simulacao.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'Simula Parcela';

  form: FormGroup;
  simulao: Simulacao = new Simulacao();
  dataSource: Simulacao[] = null;
  displayedColumns: string[] = ['id',
                                'quantidadeDeParcela',
                                'dataDaCompra',
                                'valorJuros',
                                'valorTotalCompra',
                                'valorTotalAPagar'];

  constructor(private simulacaoService: SimulacaoService,
              private formBuilder: FormBuilder)
  { }

  ngOnInit(): void {
    this.configurarFormulario();
  }

  public configurarFormulario(): void {
    this.form = this.formBuilder.group({
      valorTotalCompra: [''],
      valorJuros: [''],
      dataDaCompra: [''],
      quantidadeDeParcela: ['']
    });
  }

  public onSubmit(): void {
    this.simulacaoService.addAsync(this.form.value).then((response: Response) => {
        this.getAll();
        this.configurarFormulario();
    });
  }

  public getAll(): void {
      this.simulacaoService.getAllAsync().subscribe((data: Simulacao[]) => {
        this.dataSource = data;
      });
  }

  public getSimulacao(): Simulacao {
    this.simulao.valorJuros = this.form.get('valorJuros').value;
    this.simulao.dataDaCompra = this.form.get('dataDaCompra').value;
    this.simulao.valorTotalCompra = this.form.get('valorTotalCompra').value;
    this.simulao.quantidadeDeParcela = this.form.get('quantidadeDeParcela').value;
    return this.simulao;
  }

}
