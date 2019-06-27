import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Simulacao } from './simulacao';
import { SimulacaoService } from './simulacao.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'SimulaParcelaUi';

  form: FormGroup;
  simulaParcela: Simulacao = new Simulacao();

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
      quantidadeDeParcela: [''],
      dataDaCompra: ['']
    });
  }

  public onSubmit(): void {

  }

  public calcular() {

  }

  public getSimulaParcela(): Simulacao {
    this.simulaParcela.dataDaCompra = this.form.get('dataDaCompra').value;
    this.simulaParcela.quantidadeDeParcela = this.form.get('quantidadeDeParcela').value;
    this.simulaParcela.valorJuros = this.form.get('valorJuros').value;
    this.simulaParcela.valorTotalCompra = this.form.get('valorTotalCompra').value;
    return this.simulaParcela;
  }

}
