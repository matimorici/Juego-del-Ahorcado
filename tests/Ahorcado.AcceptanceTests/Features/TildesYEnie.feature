# language: es
@HU-04
Característica: Jugar con tildes y eñes
  Como jugador
  quiero que las letras con tilde se descubran al ingresar su letra base
  para no tener que escribir tildes

  @AC-1
  Escenario: Una letra sin tilde revela la letra con tilde
    Dado que ingreso con la palabra "CANCIÓN"
    Cuando adivino la letra "O"
    Entonces veo la palabra "_ _ _ _ _ Ó _"
    Y veo 6 vidas

  @AC-2
  Escenario: La ñ es una letra distinta de la n
    Dado que ingreso con la palabra "NIÑO"
    Cuando adivino la letra "N"
    Entonces veo la palabra "N _ _ _"
    Y veo 6 vidas

  @AC-3
  Escenario: La ñ se descubre ingresando ñ
    Dado que ingreso con la palabra "NIÑO"
    Cuando adivino la letra "Ñ"
    Entonces veo la palabra "_ _ Ñ _"
    Y veo 6 vidas