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
  
  @AC-2
  Escenario: Con nivel fácil se empieza con 8 vidas
    Dado que ingreso con la palabra "GATO" y el nivel facil
    Entonces veo 8 vidas

  @AC-3
  Escenario: Sin nivel se empieza con 6 vidas
    Dado que ingreso con la palabra "GATO"
    Entonces veo 6 vidas

  @AC-3
  Escenario: Con un nivel desconocido se empieza con 6 vidas
    Dado que ingreso con la palabra "GATO" y el nivel xyz
    Entonces veo 6 vidas
    
  @AC-4
  Escenario: El nivel se mantiene al jugar y el dibujo cuenta errores
    Dado que ingreso con la palabra "GATO" y el nivel dificil
    Cuando adivino la letra "E"
    Entonces veo 3 vidas
    Y veo el dibujo "Cabeza"