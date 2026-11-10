# language: es
@HU-06
Característica: Dificultad
  Como jugador
  quiero elegir el nivel de dificultad
  para jugar con más o menos vidas

  @AC-1
  Escenario: Con nivel difícil se empieza con 4 vidas
    Dado que ingreso con la palabra "GATO" y el nivel dificil
    Entonces veo 4 vidas
    Y veo la palabra "_ _ _ _"