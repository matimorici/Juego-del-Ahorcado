# NOTES.md — Trazabilidad Historia de Usuario → Criterio → Escenario (AT) → Unit Tests

Mecanismo de trazabilidad elegido: **matriz en este archivo**, combinada con etiquetas de Gherkin
(`@HU-XX`, `@AC-X`) sobre cada Característica/Escenario en los `.feature`. La matriz es la vista humana
y ejecutable en la defensa; las etiquetas permiten filtrar (`dotnet test --filter Category=HU-02`).

Link al Story Map: https://miro.com/welcomeonboard/R2w3Z2dKOFJjZjVUTTlFVnFqeDRZSmVlZjlJL2dUcUgrUlVpQVphM1JnTWZacmJVVUZUdGFaUS9kTStsaGxnekc0VGx4RTVuTjBOWFYvRzRlNldqOFdqT2UyY2d1NDZzTXhiTmllc2dHNnZBVU5zckR3QjljSi9rNzQ5SFRzNnNzVXVvMm53MW9OWFg5bkJoVXZxdFhRPT0hdjE=?share_link_id=377491566949

## Matriz

| HU | Criterio de aceptación | Escenario (AT) | Unit Tests | Estado |
|---|---|---|---|--------|
| **HU-01** Iniciar partida | AC-1: Ver un guion bajo por cada letra de la palabra. | Arrancar la partida con la palabra oculta (`IniciarPartida.feature`) | `Palabra_enmascarada_de_GATO_muestra_cuatro_guiones`, `Palabra_enmascarada_de_PERRO_muestra_cinco_guiones` | Hecho  |
| **HU-01** Iniciar partida | AC-2: Ver 6 vidas | Arrancar la partida con 6 vidas | `Vidas_al_iniciar_la_partida_son_seis` | Hecho  |
| **HU-01** Iniciar partida | AC-3: Arrancar sin indicar la palabra y ver una palabra oculta. | Arrancar la partida sin indicar una palabra (`IniciarPartida.feature`) | `Palabra_vacia_usa_la_palabra_por_defecto` | Hecho  |
| **HU-02** Adivinar letras | AC-1: Una letra presente se revela sin perder vidas. | Acertar una letra (`AdivinarLetras.feature`) | `Adivinar_letra_presente_revela_su_posicion`, `Adivinar_letra_presente_revela_todas_sus_ocurrencias` | Hecho  |
| **HU-02** Adivinar letras | AC-2: Una letra ausente cuesta una vida. | Fallar una letra (`AdivinarLetras.feature`) | `Adivinar_letra_ausente_descuenta_una_vida`, `Adivinar_dos_letras_ausentes_descuentan_dos_vidas` | Hecho  |
| **HU-02** Adivinar letras | AC-3: Las letras acertadas se acumulan (GATO + `A` + `T` → `_ A T _`). | Las letras acertadas se acumulan (`AdivinarLetras.feature`) | `Letras_jugadas_registra_la_letra_adivinada`, `Letras_jugadas_acumula_las_letras_en_orden` | Hecho |
| **HU-02** Adivinar letras | AC-4: Repetir una letra ya probada no cuesta vidas y avisa (GATO + `E` + `E` → 5 vidas y "Ya probaste la letra E"). | Repetir una letra ya probada no cuesta otra vida (`AdivinarLetras.feature`) | `Letra_repetida_no_descuenta_otra_vida`, `Letra_repetida_queda_informada` | Hecho |
| **HU-02** Adivinar letras | AC-3: Las letras acertadas se acumulan (GATO + `A` + `T` → `_ A T _`). | Las letras acertadas se acumulan (`AdivinarLetras.feature`) | `Letras_jugadas_registra_la_letra_adivinada`, `Letras_jugadas_acumula_las_letras_en_orden` | Hecho  |
| **HU-03** Terminar partida | AC-1: Al completar todas las letras de la palabra se ve "GANASTE". | Ganar la partida (`TerminarPartida.feature`) | `Gano_al_adivinar_todas_las_letras`, `No_gano_si_faltan_letras` | Hecho  |

## Decisiones técnicas
- **Levantar la Web para los AT:** el hook `[BeforeTestRun]` de `WebServerHooks.cs` arranca
  `Ahorcado.Web` con `dotnet run`, espera un 200 (timeout 60 s) y la mata en `[AfterTestRun]`.
  Si la web no levanta, la corrida de AT falla (rojo honesto, Guía §6).