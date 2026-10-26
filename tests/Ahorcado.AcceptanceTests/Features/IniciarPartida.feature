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
    
  @AC-2
  Escenario: Arrancar la partida con 6 vidas
    Dado que ingreso con la palabra "GATO"
    Entonces veo 6 vidas
  @AC-3
  Escenario: Arrancar la partida sin indicar una palabra
    Dado que ingreso sin indicar una palabra
    Entonces veo una palabra oculta
    Y veo 6 vidas
