﻿# Título de Proyecto
OntoFrutis - Ontología de Frutas

## Objetivo General: 
Crear una aplicación web capaz de realizar búsqueda de frutas por características específicas con un nivel de complejidad elevado.

## Objetivos Específicos: 
Permitir la inserción de nuevos datos a la base de datos 
Visualizar los resultados de inferencia dado los valores ingresados en el proceso de consulta. 
Mostrar la lista de datos disponibles en la base de datos.
Posibilitar la eliminación de datos de la base de datos.

## Tecnología y Herramientas
Para diseñar la ontologia se utilizó OWL, un lenguaje de web semántica que tiene como objetivo facilitar un modelo de marcado construido sobre RDF y codificado en XML.

Para facilitar el diseño  de la ontologia se utilizó el framework Protégé, el cual facilita realizar inferencias mediante el complemento Pellet.

Para permitir el ingreso de instacias a la ontología se utilizó una base de datos relacional en  un servidor creado con Apache Jena Fuseki.

La aplicación se desarrollará en el lenguaje de programacion C# y se utilizará la libreria dotNetRDF que permite analizar, administrar, consultar y escribir RDF.

### Pre-requisitos

Todo lo que necesitas instalar para la configuración del proyecto.

-Apache jena Fuseki v.2.4  
-Servidor NodeJS (Angular) / NodeJS Server (Angular):

```
npm install -g @angular/cli
```

### Inicio / Run
Abra la terminal en la ruta del repositorio
-Servidor Apache Jena Fuseki
```
cd backend
```

-Servidor NodeJS (Angular)
```
cd frontend 
ng serve –open
``` 

## ScreenShots / Capturas
Vista de Presentación
![Image](https://github.com/miguel3010/Ontologia_Frutas/blob/master/01.png)

Vista de Consulta
![Image](https://github.com/miguel3010/Ontologia_Frutas/blob/master/02.png)

Formulario de Parámetros
![Image](https://github.com/miguel3010/Ontologia_Frutas/blob/master/03.png)

## Software usado
* [Angular](https://angular.io/) - Frontend JS Framework
* [Bootstrap 4](https://v4-alpha.getbootstrap.com/) - CSS Framework
* [DotnetRDF](https://github.com/dotnetrdf/) - RDF & SPARQL API
* [WEB API](https://www.asp.net/web-api) - REST Framework para C#
* [Fuseki](https://jena.apache.org/index.html) - OWL Server

## Autores

* **Miguel Ángel Campos** - *Fullstack Developer* - [Twitter](https://twitter.com/Miguel_Angel_30)
* **Luis Yao Yang** - *Fullstack Developer* - [Twitter](https://twitter.com/notLwiz)
* **José Varela** - *Fullstack Developer* - [Instagram](https://www.instagram.com/jose_vr26/)
* **Anell Zheng** - *Fullstack Developer* - [Facebook](https://www.facebook.com/anell.zheng)
* **David Soto** - *Fullstack Developer* - [Facebook](https://www.facebook.com/stfu.u.n00bster)

## Agradecimientos / Acknowledgments

* Ing. Belén Bonilla -Professor-
