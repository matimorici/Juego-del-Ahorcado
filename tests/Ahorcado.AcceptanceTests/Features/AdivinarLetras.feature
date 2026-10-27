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

  @AC-2
  Escenario: Fallar una letra
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "E"
    Entonces veo la palabra "_ _ _ _"
    Y veo 5 vidas

  @AC-3
  Escenario: Las letras acertadas se acumulan
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "A"
    Y adivino la letra "T"
    Entonces veo la palabra "_ A T _"
    Y veo 6 vidas

  @AC-4
  Escenario: Repetir una letra ya probada no cuesta otra vida
    Dado que ingreso con la palabra "GATO"
    Cuando adivino la letra "E"
    Y adivino la letra "E"
    Entonces veo 5 vidas
    Y veo el mensaje "Ya probaste la letra E"