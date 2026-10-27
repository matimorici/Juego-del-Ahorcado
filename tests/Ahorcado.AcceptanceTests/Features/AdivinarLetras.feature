# language: es
@HU-02
Característica: Adivinar letras
  Como jugador
  quiero adivinar letras
  para ir descubriendo la palabra

  @AC-1
  Escenario: Acertar una letra
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "A"
    Entonces veo la palabra "_ A _ _"
    Y veo 6 vidas

  @AC-3
  Escenario: Las letras acertadas se acumulan
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "A"
    Y adivino la letra "T"
    Entonces veo la palabra "_ A T _"
    Y veo 6 vidas