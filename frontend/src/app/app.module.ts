import { PresentacionViewComponent } from './Views/presentacion-view/presentacion-view.component';
import { AuthGuard } from './Auth/auth-guard.service';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NotAuthorizedComponent } from './not-authorized/not-authorized.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes  } from '@angular/router';
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
    path: 'recurso',
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
    AutoresComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(views)
  ],
  providers: [
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
