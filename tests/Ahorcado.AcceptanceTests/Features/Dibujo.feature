# language: es
@HU-07
Característica: Dibujo del muñeco
  Como jugador
  quiero ver el muñeco aparecer a medida que me equivoco
  para saber qué tan cerca estoy de perder

  @AC-1
  Escenario: Cada error muestra una parte más del muñeco
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "E"
    Y adivino la letra "I"
    Entonces veo el dibujo "Cabeza, Torso"
    Y veo 4 vidas

  @AC-2
  Escenario: Sin errores no se ve ninguna parte del dibujo
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "A"
    Entonces no veo partes del dibujo