# language: es
@HU-01
Característica: Iniciar partida
  Como jugador
  quiero iniciar una partida
  para ver la palabra oculta y empezar a adivinarla

  @AC-1
  Escenario: Arrancar la partida con la palabra oculta
    Dado que ingreso con la palabra "GATO"
    Entonces veo la palabra "_ _ _ _"
