# language: es
@HU-03
Característica: Terminar la partida
  Como jugador
  quiero que la partida me avise cuando termina
  para saber si gané o perdí

  @AC-1
  Escenario: Ganar la partida
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "G"
    Y adivino la letra "A"
    Y adivino la letra "T"
    Y adivino la letra "O"
    Entonces veo el resultado "GANASTE"