# Documentación Proyecto Unity

### Imagen Digital  
**Miguel Ángel Campón Iglesias**

---

## Índice de contenido
1. [Descripción del juego](#1-descripción-del-juego)
2. [Instrucciones de uso](#2-instrucciones-de-uso)
   - [Controles](#controles)
   - [Reglas](#reglas)
3. [Explicación de la lógica del juego](#3-explicación-de-la-lógica-del-juego)
4. [Detalles técnicos de la implementación](#4-detalles-técnicos-de-la-implementación)
   - [Herramientas y tecnologías usadas](#herramientas-y-tecnologías-usadas)
   - [Escenas del Juego](#escenas-del-juego)
   - [Componentes y scripts principales](#componentes-y-scripts-principales)
   - [Ciclo de juego](#ciclo-de-juego)
   - [Aspectos destacados](#aspectos-destacados)
5. [Mejoras y características futuras](#5-mejoras-y-características-futuras)

---

## 1. Descripción del juego
**Nombre del juego:** Maze Hunter

**Resumen:** Este es un juego de laberinto en 3D en el que dos jugadores deben competir para llegar a la meta. Los jugadores pueden dispararse entre sí con proyectiles para hacer que el oponente vuelva a su posición de inicio, otorgando una ventaja al jugador que haya disparado el proyectil.

**Objetivo:** Llegar a la meta antes que el oponente usando habilidades de movimiento y disparo para ganar ventaja y evitar que el adversario complete el recorrido primero.

---

## 2. Instrucciones de uso

### Controles
- **Jugador 1 (Rojo):**
  - Movimiento: Teclas de flecha (arriba, abajo, izquierda, derecha).
  - Disparo de proyectiles: Tecla Enter para disparar.

- **Jugador 2 (Azul):**
  - Movimiento: Teclas W, A, S, D.
  - Disparo de proyectiles: Tecla Shift.

### Reglas
- Los jugadores deben evitar los muros y obstáculos del laberinto.
- Si un jugador es golpeado por un proyectil, vuelve a su posición de inicio.
- Al llegar a la meta, se activa una pantalla de victoria para el jugador que haya alcanzado primero la meta.

---

## 3. Explicación de la lógica del juego

**Movimientos de los jugadores:** Los jugadores se mueven por el laberinto utilizando las teclas de dirección o las teclas WASD. La velocidad de movimiento es constante, sin aceleración, y se implementa con un Rigidbody para una física controlada.

**Disparo de proyectiles:** Cuando un jugador presiona la tecla de disparo, se genera un proyectil que se mueve en la dirección que el jugador está mirando. El proyectil se mueve a una velocidad establecida y se destruye automáticamente después de 3 segundos o cuando impacta a otro jugador.

**Colisiones:**
- **Con muros:** Los jugadores deben evitar los muros. Si chocan con uno, se detienen momentáneamente y, en algunos casos, pueden cambiar de dirección.
- **Con otros jugadores:** Si un proyectil impacta a un jugador, este regresa a su posición de inicio. Esto permite al jugador que disparó ganar ventaja al hacer que el oponente pierda tiempo.
- **Con la meta:** Si un jugador llega a la meta, se activa una escena de victoria.

**Mecánica de disparo entre jugadores:** Los proyectiles pueden impactar a ambos jugadores. Al golpear a un jugador, este es teletransportado a su posición de inicio, y el jugador que disparó recibe una ventaja estratégica. Los proyectiles están programados para moverse en línea recta hasta que chocan con un objeto o expiran.

---

## 4. Detalles técnicos de la implementación

### Herramientas y tecnologías usadas
- Motor de juego: Unity 3D
- Lenguaje de programación: C#
- Sistema de control de colisiones: Collider (BoxCollider, SphereCollider, etc.)
- Sistema de física: Rigidbody para el movimiento controlado de los jugadores y los proyectiles.

### Escenas del Juego
1. **Game:** Esta es la escena principal del juego, donde los jugadores interactúan y compiten entre sí. Contiene los elementos de juego, como los personajes, proyectiles, obstáculos y la lógica que gestiona la partida.
2. **Instructions:** Pantalla de inicio que incluye la portada del juego y las instrucciones para los jugadores. Aquí se presenta la interfaz que permite conocer las reglas básicas y cómo jugar.
3. **GanaAzul:** Pantalla de victoria para el jugador azul. Se muestra cuando el jugador logra alcanzar la meta o cumplir los objetivos establecidos para ganar.
4. **GanaRojo:** Pantalla de victoria para el jugador rojo. Se activa cuando el jugador rojo logra completar el objetivo y ganar la partida.

### Componentes y scripts principales
- **ColorChanger.cs:** Cambia el color de los objetos en la escena, permitiendo respuestas visuales interactivas. Se usa para resaltar elementos o indicar eventos, como impactos de proyectiles.
- **Jug1_mov.cs:** Controla el movimiento, disparos y la lógica del juego del jugador 1. Permite moverse, disparar proyectiles y manejar colisiones, como la detección de impacto con muros o el reinicio de la posición al ser golpeado.
- **Jug2_mov.cs:** Similar a Jug1_mov, pero para el jugador 2. Gestiona el movimiento, disparos y las colisiones, con la misma funcionalidad pero personalizada para el segundo jugador.
- **MenuManager.cs:** Maneja la pantalla de inicio y el cambio de escenas para comenzar el juego. Controla la interfaz de usuario y la transición entre menús y la partida.
- **Projectile.cs:** Controla el movimiento y la destrucción de los proyectiles disparados por los jugadores. Asegura un movimiento a velocidad constante y la eliminación al chocar con muros u otros objetos.
- **Restart.cs:** Controla el reinicio de la partida tras pulsar cualquier tecla en la pantalla de victoria de alguno de los jugadores.

### Ciclo de juego
1. Los jugadores inician en sus respectivas posiciones en el laberinto.
2. Los jugadores se mueven por el laberinto y pueden dispararse entre sí.
3. Cuando un proyectil impacta a un jugador, este regresa a su posición inicial.
4. El jugador que primero llega a la meta gana y se muestra una pantalla de victoria.

### Aspectos destacados
- El juego incluye una mecánica de disparo que añade un nivel de estrategia.
- El sistema de colisiones está optimizado para detectar impactos de proyectiles y muros.
- La física se mantiene sencilla, con movimiento constante sin aceleración.

---

## 5. Mejoras y características futuras
- **Enemigo móvil:** Enemigo que se desplace por el mapa de forma autónoma. Este enemigo perseguirá y se moverá por el laberinto, y si llega a chocar con alguno de los jugadores, estos se reiniciarán en su posición de inicio, lo que otorgará una ventaja al jugador que no ha sido alcanzado. Esto incrementaría la complejidad y dinamismo del juego, ofreciendo nuevos desafíos y estrategias para los jugadores. Debido a limitaciones de tiempo y la complejidad técnica, no se implementó la funcionalidad.
