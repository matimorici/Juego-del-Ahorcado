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

  @AC-2
  Escenario: Perder la partida
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "B"
    Y adivino la letra "C"
    Y adivino la letra "D"
    Y adivino la letra "E"
    Y adivino la letra "F"
    Y adivino la letra "H"
    Entonces veo el resultado "PERDISTE"
    Y veo la palabra "G A T O"
    Y veo 0 vidas