# language: es
@HU-05
Característica: Palabra al azar
  Como jugador
  quiero que la partida elija una palabra por mí
  para poder jugar sin ponerme de acuerdo con nadie

  @AC-1
  Escenario: Con la semilla 0 la palabra es siempre la misma
    Dado que ingreso con la semilla 0
    Entonces veo la palabra "_ _ _ _"
    Y veo 6 vidas