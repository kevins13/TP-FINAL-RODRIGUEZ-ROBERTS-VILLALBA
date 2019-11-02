Laboratorio de Programación Orientada a Objetos

  
  


Krausecord

  


_Llegó la hora de poner en práctica todo lo que aprendimos en estos años, vamos a hacer un aplicación de escritorio que emule el funcionamiento de discord para redes LAN._

  
  
  
  
  
  
  
  
  


Trabajo Final

2019

Pautas de trabajo

-   El trabajo debe resolverse en grupos de 3 personas. El docente determinará los grupos.
-   Este es un trabajo de investigación, por lo cual es responsabilidad de los alumnos autocapacitarse en las tecnologías elegidas para el desarrollo de la solución.
-   Se puede proponer al docente formas de resolver los requerimientos.
-   No hay restricciones en cuanto al lenguaje de programación elegido, pero debe utilizarse software que esté disponible en el laboratorio o en su defecto que no sea complejo instalar.
-   Por cada entrega se le debe enviar al docente el repositorio de github donde se estuvo trabajando.

# Primer entrega: Chat entre PCs

La primer parte del trabajo consiste en enviar mensajes entre computadoras, para esto habrá una computadora que funcionará como servidor, que podrá tener múltiples clientes.

La arquitectura será la siguiente:

  


![](https://lh5.googleusercontent.com/dhxoUPzx62rEAjJOd0MbZaqBYcZXl1NuS9Vwm-k0MRAO4ORlHarIzo6vXbkxr9BFjvR75zW3YCpmHSniRco6Wv2fajsCkM2-uqm7LJvB0sxt3z5NXi7aHaQ7ZyfG6KZ7H6EBqDTm)

### Consideraciones

-   El servidor es el responsable de distribuir el mensaje a todas las computadoras.
-   Las computadoras deberían conectarse al servidor mediante su ip y su puerto.
-   Se recomienda investigar el uso de Sockets e hilos de ejecución (Threads). En caso de no hacerse así, una alternativa podría ser comunicarse mediante conexiones http (GET, POST, PUT, DELETE).
-   Se deberá presentar un diagrama de clases al profesor para explicar la solución.

  


Fecha de entrega: 25/10

  
  


Anexo - Envío de mensajes

Luego de establecida la conexión, las computadoras podrán enviar mensajes al servidor, de la siguiente manera:

![](https://lh5.googleusercontent.com/GthpFQyhwOgtzc1VEtwx6jRx7ArpB2Opj3MX4SsDoo3Wh6GgQ9RQN2HinUsZFVrK_oEQ4LDRMnJ7Xoxz9dLmsXW-A0yzC5vBtU3AGyyiBVnf5YJJsjGbMrC0UUd7vja1zFcTFHnl)

  


El servidor será el responsable de replicar ese mensaje a todas las computadoras conectadas al chat.

![](https://lh6.googleusercontent.com/UmKaq6LojwP6fgbphMM2MilBIB1WtDON_xoJBguy1NalyL9yQrgesBAc_kco5Bbuoq3o3ilSVNGO2672CiH4Cbk0bFD34kD-ewP-RHrnP0E8JHhnLFxD4U4pJuzvbaESZqRnuUA4)

# Segunda entrega: Mejorando el chat

Para esta entrega se deberá agregar una interfaz gráfica a nuestro chat y la posibilidad de enviar archivos a través del mismo. El programa debe permitir arrastrar archivos hasta el chat y que todos los usuarios conectados tengan la posibilidad de descargarlo. Por cada mensaje se debe poder ver el nombre de la persona que lo envió (pedir un nick).

  


### Consideraciones

-   Investigar como hacer un drag and drop.
-   Utilizar proyectos de tipo WPF, para hacer interfaces más “estéticas”.
-   Investigar sobre el manejo de archivos.

  


Fecha de entrega: 8/11

  


# Tercera entrega: Ya parece algo de verdad

La idea de esta entrega es que el servidor permite registrar usuarios (guardar su usuario y, contraseña) y que pueda recordar todos los mensajes enviados por el chat.

  


### Consideraciones

-   Se deberá implementar una capa de persistencia, esta última debe ser capaz de persistir mensajes/usuarios de las siguientes maneras:

    -   Bases de datos
    -   Archivos

-   Para el punto anterior, investigar sobre el patrón Adapter y sobre JSON.

  


Fecha de entrega: 18/11

  


### Criterios de evaluación

-   Por cada entrega debe presentarse un diagrama de clases y una muestra del programa en ejecución.
-   Siempre se evaluará la correcta separación de capas en el proyecto (Modelo, Presentación, Persistencia). De no cumplirse esto y haber secciones de código en lugares no correspondientes, se considerará la entrega como no aprobada.
-   Se espera que se realicen test del Modelo cuando sea posible.
-   El docente determinará si los alumnos aprueban cada entrega en base al cumplimiento de los requerimientos y los ítems anteriormente mencionados.
-   Habrá una nota de trabajo y una nota individual.
