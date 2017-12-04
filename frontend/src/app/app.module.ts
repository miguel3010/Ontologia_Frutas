import { PresentacionViewComponent } from './Views/presentacion-view/presentacion-view.component';
import { AuthGuard } from './Auth/auth-guard.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core'; 
import { AppComponent } from './app.component';
import { ConsultaViewComponent } from './/Views/consulta-view/consulta-view.component';
import { ResultadosComponent } from './/Components/resultados/resultados.component';
import { ParamBusquedaComponent } from './/Components/param-busqueda/param-busqueda.component';
import { RecursoViewComponent } from './/Views/recurso-view/recurso-view.component';
import { FrutaComponent } from './/Components/fruta/fruta.component';
import { VitaminaComponent } from './/Components/vitamina/vitamina.component';
import { MineralComponent } from './/Components/mineral/mineral.component';
import { DashViewComponent } from './/Views/dash-view/dash-view.component';
import { ItemResultadoComponent } from './/Components/item-resultado/item-resultado.component';
import { AutoresComponent } from './/Components/autores/autores.component';
import { AgregarFrutaComponent } from  './/Components/agregar-fruta/agregar-fruta.component';
import { ApiService } from './Services/api.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http'

const views: Routes = [
  {
    path: '',
    component: PresentacionViewComponent
  },
  {
    path: 'consulta',
    component: ConsultaViewComponent
  },
  {
    path: 'recurso/:resource',
    component: RecursoViewComponent
  },
  {
    path: 'dash',
    component: DashViewComponent
  },
  {
    path: 'not-authorized',
    component: NotAuthorizedComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }

];

@NgModule({
  declarations: [
    AppComponent,
    NotAuthorizedComponent,
    PageNotFoundComponent,
    PresentacionViewComponent,
    ConsultaViewComponent,
    ResultadosComponent,
    ParamBusquedaComponent,
    RecursoViewComponent,
    FrutaComponent,
    VitaminaComponent,
    MineralComponent,
    DashViewComponent,
    ItemResultadoComponent,
    AutoresComponent,
    AgregarFrutaComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(views)
  ],
  providers: [
    AuthGuard,
    ApiService, 
    RouterModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }


