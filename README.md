#  TP1 · Juego de Plataformas 3D en Unity

> Proyecto de **Programación de Videojuegos** desarrollado con **Unity 2022.3.52f1** y **C#**.

**Autora:** Sara Miranda

---

## Descripción del proyecto

Este proyecto es un **juego de plataformas en 3D** en el que el jugador controla a un personaje (una cápsula) que debe recorrer un escenario lleno de desafíos hasta completar el objetivo final.
--

A lo largo del recorrido, el jugador tiene que:
* **Saltar** entre plataformas fijas y **plataformas móviles** que lo transportan.
* **Esquivar obstáculos** que se mueven por el escenario y **proyectiles** que se generan automáticamente.
* **Recoger un objeto** (una esfera), llevarlo consigo y soltarlo.
* Aprovechar un **potenciador de velocidad** temporal.
* **Entregar el objeto** en la zona de meta para ganar la partida.

---

## Controles

| Acción | Tecla |
|---|---|
| Moverse | `W` `A` `S` `D` o las **flechas** del teclado |
| Saltar | `Barra espaciadora` |
| Recoger objeto | `E` (estando cerca del objeto) |
| Soltar objeto | `Q` |

---

## Cómo abrir y ejecutar el proyecto

### Paso a paso

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/SaraBM06/TP1_Prg1.git
   ```
2. **Abrir Unity Hub** y pulsar **Add → Add project from disk**.
3. Seleccionar la carpeta `TP1_Prg1` que se acaba de clonar.
4. Abrir el proyecto (la primera vez puede tardar unos minutos en importar los recursos).
5. En la ventana **Project**, abrir la escena:
   `Assets/Scenes/EscenarioPrincipal.unity`
6. Pulsar el botón **▶ Play** en la parte superior de Unity.
7. Hacer **clic dentro de la ventana Game** para que reciba el teclado y ¡a jugar!

---

## El Juego posee: 

### Personaje y cámara

El personaje se mueve con el teclado y salta usando **Rigidbody**, por lo que le afecta la gravedad y choca con las plataformas. La cámara lo **sigue durante todo el recorrido** manteniendo una distancia (offset) configurable desde el Inspector.

### Escenario y plataformas

El nivel está formado por plataformas fijas y por **plataformas móviles** que van de un punto a otro. Estas últimas **llevan al jugador encima** mientras se desplazan y cambian de dirección cada cierto tiempo, controlado con `Invoke()`.

### Obstáculos y generador de proyectiles

Además de los obstáculos que se mueven por el escenario, hay un **Spawner** que genera proyectiles de forma periódica con `InvokeRepeating()`. Una **zona invisible** activa el generador cuando el jugador se acerca. Cada proyectil **se destruye solo** (por tiempo o al caer al vacío) para que nunca se acumulen.

###  Recoger y transportar un objeto

El jugador puede **recoger una esfera** con `E`: queda asociada al personaje mediante `SetParent()` y lo acompaña mientras camina. Con `Q` se **suelta**, recupera su independencia y vuelve a obedecer a la física.

###  Potenciador de velocidad

Un cubo verde otorga **velocidad x2 durante 5 segundos**. Después entra en **recarga durante 10 segundos**, tiempo en el que no puede reutilizarse. Está implementado con una **corrutina**.

### Meta y victoria

En el final del recorrido hay una **zona de entrega**. La victoria **no se logra solo con llegar**: hay que **depositar la esfera** dentro de la zona. Al hacerlo aparece el mensaje **"¡VICTORIA!"** y la zona cambia a verde.

---

## 🧑‍💻 Scripts principales

| Script | Función |
|---|---|
| `PlayerMovement` | Movimiento y salto del personaje |
| `CameraFollow` | Cámara que sigue al jugador |
| `Plataforma_Movil` | Plataformas que van y vienen entre dos puntos (`Invoke`) |
| `Spawner` | Genera proyectiles periódicamente (`InvokeRepeating`) |
| `ZonaSpawner` | Activa o detiene el Spawner según la posición del jugador |
| `Proyectil` | Mueve el proyectil y lo destruye para evitar acumulación |
| `Recoger` | Recoger y soltar objetos con `SetParent()` |
| `PowerUp` | Potenciador de velocidad con corrutina y cooldown |
| `ZonaEntrega` | Detecta la entrega del objeto y activa la victoria |

---

## Control de versiones

El proyecto se fue construyendo por etapas, con un commit por cada funcionalidad: escenario, personaje, cámara, plataformas móviles, generador de obstáculos, recolección de objetos, power-up y zona de victoria.

---

##  Notas Importante: 

* En Unity 2022 se usa `Rigidbody.velocity`. En Unity 6 esa propiedad se llama `linearVelocity`.
* Casi todos los valores (velocidades, tiempos, distancias, teclas) se pueden **ajustar desde el Inspector** sin tocar el código.
* Si el teclado no responde al pulsar Play, haz clic dentro de la ventana **Game**.

---

