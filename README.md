# FDV-ScriptProgramming
C#. Programación de Scripts.

Implementar una aplicación en Unity3D en la que habrá una serie de objetos dispuestos en la escena y que proporcionarán poderes al jugador (otro objeto).
1) Todos los objetos pueden ser formas básicas (cubos, esferas, cilindros).
2) Inicialmente los objetos se ubicarán en la escena aleatoriamente, y cada cierto tiempo se cambia su posición.
3) Cada tipo de objeto propociona una cantidad diferente de poder.
4) El jugador incrementa un determinado poder siempre que esté a una distancia menor que un umbral del objeto.
5) Cuando el jugador adquiere el poder de un objeto el color de este debe cambiar a un color que se elija para el estado "gastado".

Para esta actividad he generado dos scripts:

**PlayerController:** es el encargado de controlar y gestionar las entradas y realizar el movimiento del jugador, en este caso, la bola azul.

**Buff:** representa un *buffos* o beneficio que puede utilizar el jugador. Para realizar la escena se crearon tres *GameObjects*, cada uno con su script *Buff* asociado, indicando vía parámetros las estadísticas o poderes a modificar del jugador, tiempos de reaparición, radio de aparición y el límite de detección para comprobar la posición del jugador.

![](Gif-FDV1.gif)
