# NOTES.md — Trazabilidad Historia de Usuario → Criterio → Escenario (AT) → Unit Tests

Mecanismo de trazabilidad elegido: **matriz en este archivo**, combinada con etiquetas de Gherkin
(`@HU-XX`, `@AC-X`) sobre cada Característica/Escenario en los `.feature`. La matriz es la vista humana
y ejecutable en la defensa; las etiquetas permiten filtrar (`dotnet test --filter Category=HU-02`).

Link al Story Map: https://miro.com/app/board/uXjVHv7dHMY=/?share_link_id=924213697848
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
| **HU-02** Adivinar letras | AC-5: Mayúsculas y minúsculas se tratan igual (GATO + `a` → `_ A _ _` y 6 vidas). | Mayúsculas y minúsculas se tratan igual (`AdivinarLetras.feature`) | `Adivinar_letra_en_minuscula_revela_la_letra_en_mayuscula`, `Adivinar_letra_en_minuscula_presente_no_descuenta_vida`, `Letras_jugadas_registra_la_letra_en_mayuscula` | Hecho |
| **HU-02** Adivinar letras | AC-6: Ingresar algo que no es una letra no cuesta vidas y avisa con el mensaje "Ingresá una sola letra" (GATO + `5` → 6 vidas y `_ _ _ _`). | Ingresar algo que no es una letra no cuesta vidas y avisa (`AdivinarLetras.feature`) | `Entrada_que_no_es_letra_no_descuenta_vida`, `Entrada_que_no_es_letra_queda_informada`, `Un_simbolo_tambien_queda_informado_como_entrada_invalida`, `Entrada_invalida_despues_de_una_repetida_no_queda_como_repetida` | Hecho |
| **HU-02** Adivinar letras | AC-7: Ingresar más de una letra a la vez no cuesta vidas y avisa con el mensaje "Ingresá una sola letra" (GATO + `AB` → 6 vidas y `_ _ _ _`). | Ingresar más de una letra a la vez no cuesta vidas y avisa (`AdivinarLetras.feature`) | `Entrada_de_mas_de_una_letra_no_descuenta_vida`, `Entrada_de_mas_de_una_letra_queda_informada`, `Otra_entrada_de_mas_de_una_letra_tambien_queda_informada`, `Cadena_vacia_queda_informada_sin_romper` (nace verde: la validación por longitud ya la cubría) | Hecho |
| **HU-03** Terminar partida | AC-1: Al completar todas las letras de la palabra se ve "GANASTE". | Ganar la partida (`TerminarPartida.feature`) | `Gano_al_adivinar_todas_las_letras`, `No_gano_si_faltan_letras` | Hecho |
| **HU-03** Terminar partida | AC-2: Al agotar las vidas del nivel (6 en el normal) se ve "PERDISTE" y la palabra revelada. | Perder la partida (`TerminarPartida.feature`) | `Perdio_al_agotar_las_vidas`, `No_perdio_con_cinco_fallos`, `Palabra_se_revela_al_perder` | Hecho |
| **HU-03** Terminar partida | AC-3: Con la partida terminada (ganada o perdida) no se aceptan más letras: las vidas no cambian. | Con la partida terminada no se descuentan vidas (`TerminarPartida.feature`) | `Adivinar_con_la_partida_perdida_no_descuenta_vidas`, `Adivinar_con_la_partida_ganada_no_descuenta_vidas` | Hecho |
| **HU-04** Jugar con tildes y ñ | AC-1: Una letra sin tilde revela la letra con tilde (CANCIÓN + `O` → `_ _ _ _ _ Ó _`). | Una letra sin tilde revela la letra con tilde (`TildesYEnie.feature`) | `Adivinar_letra_sin_tilde_revela_la_letra_con_tilde`, `Gano_con_palabra_con_tilde`, `Letras_jugadas_registra_la_letra_sin_tilde` | Hecho |
| **HU-04** Jugar con tildes y ñ | AC-2: La ñ es una letra distinta de la n (NIÑO + `N` → `N _ _ _`). | La ñ es una letra distinta de la n (`TildesYEnie.feature`) | `Adivinar_n_no_revela_la_enie` | Hecho (regresión, nace verde: la ñ ya funcionaba) |
| **HU-04** Jugar con tildes y ñ | AC-3: La ñ se descubre ingresando ñ (NIÑO + `Ñ` → `_ _ Ñ _`). | La ñ se descubre ingresando ñ (`TildesYEnie.feature`) | `Adivinar_enie_revela_la_enie`, `Letras_jugadas_conserva_la_enie` | Hecho (regresión, nace verde: la ñ ya funcionaba) |
| **HU-05** Palabra al azar | AC-1: Con una semilla dada (`?seed=0`) la partida elige siempre la misma palabra del banco (GATO → `_ _ _ _`). | Con la semilla 0 la palabra es siempre la misma (`PalabraAlAzar.feature`) | `Semilla_cero_elige_gato`, `Semilla_uno_elige_perro`, `Semilla_dos_elige_mariposa`, `Semilla_mayor_a_la_cantidad_de_palabras_da_la_vuelta` (nace verde: el `%` ya lo resolvía), `Semilla_negativa_elige_una_palabra_del_banco` | Hecho |
| **HU-05** Palabra al azar | AC-2: Semillas distintas eligen palabras distintas (`?seed=1` → PERRO → `_ _ _ _ _`). | Con la semilla 1 la palabra es otra (`PalabraAlAzar.feature`) | `Semilla_uno_elige_perro`, `Semilla_dos_elige_mariposa` (ya cubiertos en AC-1; este AC no agrega UT) | Hecho (regresión, nace verde: el banco ya elegía por semilla) |
| **HU-05** Palabra al azar | AC-3: Si se indica `?word=`, esa palabra gana sobre `?seed=` (`?word=SOL&seed=1` → `_ _ _`). | La palabra indicada gana sobre la semilla (`PalabraAlAzar.feature`) | Sin UT: la precedencia vive en la página (`Index.cshtml.cs`) y solo la cubre el AT | Hecho (regresión, nace verde: `OnGet` solo elige al azar si `word` viene vacío) |
| **HU-06** Dificultad | AC-1: Con `?level=dificil` la partida empieza con 4 vidas (GATO → 4 vidas y `_ _ _ _`). | Con nivel difícil se empieza con 4 vidas (`Dificultad.feature`) | `Partida_con_cuatro_vidas_iniciales_empieza_con_cuatro_vidas`, `Partida_con_cinco_vidas_iniciales_empieza_con_cinco_vidas`, `Nivel_dificil_tiene_cuatro_vidas`, `Nivel_desconocido_tiene_seis_vidas` (nace verde: cubre la rama por defecto que exige el Quality Gate) | Hecho |
| **HU-06** Dificultad | AC-2: Con `?level=facil` la partida empieza con 8 vidas (GATO → 8 vidas). | Con nivel fácil se empieza con 8 vidas (`Dificultad.feature`) | `Nivel_facil_tiene_ocho_vidas` | Hecho |
| **HU-06** Dificultad | AC-3: Sin `?level=`, o con un nivel que no existe, la partida empieza con 6 vidas (valor por defecto sin cambios). | Sin nivel se empieza con 6 vidas; Con un nivel desconocido se empieza con 6 vidas (`Dificultad.feature`) | `Nivel_desconocido_tiene_seis_vidas` (agregado en AC-1), `Nivel_vacio_tiene_seis_vidas` | Hecho (regresión, nace verde: el `_ => 6` de `Dificultad.Vidas` ya lo cubría) |
| **HU-06** Dificultad | AC-4: El nivel se mantiene al jugar y el dibujo cuenta errores (GATO + `dificil` + `E` → 3 vidas y dibujo "Cabeza"). | El nivel se mantiene al jugar y el dibujo cuenta errores (`Dificultad.feature`) | `Muneco_con_un_error_en_partida_de_cuatro_vidas_muestra_la_cabeza`, `Muneco_con_un_error_en_partida_de_ocho_vidas_muestra_la_cabeza` | Hecho |
| **HU-07** Dibujo del muñeco | AC-1: Cada error muestra una parte más del muñeco, en orden (GATO + `E` + `I` → "Cabeza, Torso"). | Cada error muestra una parte más del muñeco (`Dibujo.feature`) | `Muneco_con_un_error_muestra_la_cabeza`, `Muneco_con_dos_errores_muestra_cabeza_y_torso` | Hecho |
| **HU-07** Dibujo del muñeco | AC-2: Sin errores no se ve ninguna parte (GATO + `A` → sin partes). | Sin errores no se ve ninguna parte del dibujo (`Dibujo.feature`) | `Muneco_con_un_error_muestra_la_cabeza` (cubre el cálculo que hace que sin errores la lista quede vacía) | Hecho (regresión, nace verde: el cálculo ya lo cubría) |
| **HU-07** Dibujo del muñeco | AC-3: En nivel difícil el muñeco se arma en cuatro pasos (GATO + `dificil` + 4 errores → "Cabeza, Torso, Brazos, Piernas" y "PERDISTE"). | En nivel difícil el muñeco se arma en cuatro pasos (`Dibujo.feature`) | `Muneco_en_dificil_con_tres_errores_muestra_cabeza_torso_y_brazos` | Hecho |
| **HU-07** Dibujo del muñeco | AC-4: En nivel fácil el muñeco se arma en ocho pasos, con ojos y boca (GATO + `facil` + 8 errores → las 8 partes y "PERDISTE"). | En nivel fácil el muñeco se arma en ocho pasos (`Dibujo.feature`) | `Muneco_en_facil_con_dos_errores_muestra_cabeza_y_ojos` | Hecho |
## Decisiones técnicas
**Trazabilidad.** Elegimos la matriz de este archivo más etiquetas de Gherkin (`@HU-XX` en la Característica y `@AC-X` en cada escenario). Una Característica por historia, un escenario por criterio. La matriz es la vista para leer la cadena Historia → criterio → escenario → UT y ver si una historia está terminada (todos sus escenarios en verde). Las etiquetas permiten correr una historia sola (`dotnet test --filter Category=HU-02`). Descartamos los issues del tablero para las historias: tener el estado en dos lugares permite que se contradigan. Los UTs se enlazan por nombre en la matriz: la traza baja hasta el UT sin etiquetar el dominio, que no sabe nada de historias.

**Dónde vive la partida.** El estado no se guarda en el servidor. El formulario lleva las letras ya jugadas en un campo oculto (`played`) y en cada pedido la página crea un `Ahorcado` nuevo y le reaplica esas letras más la nueva. Así el dominio sigue puro (sin HTTP ni sesión) y los AT son deterministas con `?word=GATO`. Límite conocido: la partida viaja en la URL. Si hicieran falta "jugar de nuevo" con marcador, habría que pasar a sesión.

**Reglas en el dominio, no en la pantalla.** `Gano`, `Perdio`, `UltimaJugadaRepetida` y la palabra por defecto son del dominio; la página solo pregunta y muestra el mensaje.

**Tildes y ñ.** La normalización usa una tabla explícita (`ÁÉÍÓÚÜ` → `AEIOUU`) en lugar de `string.Normalize`: no depende del soporte Unicode del servidor y la `Ñ` queda fuera por construcción, porque para Unicode la `Ñ` es una `N` con una marca encima y se convertiría en `N`. Los escenarios de la ñ (HU-04 AC-2 y AC-3) son de regresión: nacen en verde a propósito, porque la ñ ya funcionaba, y protegen ese comportamiento.

**Pipeline.** `build → unit-tests (cobertura ≥ 90 % sobre el dominio) → sonar (quality gate bloqueante) → acceptance-tests → deploy`, encadenados con `needs`. El deploy dispara un hook de Render (con el auto-deploy apagado) y espera a que la URL responda con el juego. Corre en push a `main` y en pull requests; el deploy solo en `main`. El gate bloquea tanto en los pull requests como en `main`. El plan gratuito de SonarQube Cloud no deja consultar el estado del gate en ramas sueltas (da error si se analiza un push a una rama de trabajo), por eso el pipeline corre solo en push a `main` y en pull requests, que es donde el gate se puede consultar.

**Levantar la Web para los AT.** El hook `[BeforeTestRun]` de `WebServerHooks.cs` arranca `Ahorcado.Web` con `dotnet run`, espera un 200 (timeout 60 s) y la mata en `[AfterTestRun]`. Si la web no levanta, la corrida de AT falla (rojo honesto, Guía §6).

**Cosas que pasaron y cómo las resolvimos.** El primer `GREEN:` de HU-01 AC-2 entró sin su `RED:` y se rehízo el ciclo (queda duplicado en el historial; no se reescribió). Dos criterios abiertos en paralelo con el mismo número se renumeraron, y desde entonces los números se reservan en esta matriz antes de abrir un AT.

**Muñeco por nivel.** El muñeco tiene tantos pasos como vidas y su secuencia depende del nivel (difícil: cabeza, torso, brazos, piernas; normal: 6 partes; fácil: 8, con ojos y boca), así se completa justo al perder. La secuencia se elige por la cantidad de vidas iniciales, que es lo que ya recibe el dominio, para no cambiar su interfaz. Limitación: un nivel nuevo con otra cantidad de vidas usa la secuencia normal hasta que se le defina la suya.

## Funcionalidades extra (Aprobación Directa)

| Historia | Funcionalidad | Dónde está la lógica de dominio |
|---|---|---|
| HU-04 | Tildes y ñ | tabla explícita de normalización (`Normalizar` en `Ahorcado`); la `Ñ` queda fuera de la tabla |
| HU-05 | Palabra al azar | `BancoDePalabras.Elegir(semilla)`; el seam `?seed=` permite testear de forma determinista |
| HU-06 | Dificultad | `Dificultad.Vidas(nivel)` y las vidas iniciales de `Ahorcado` (`?level=facil` o `dificil`) |
| HU-07 | Dibujo del muñeco | `PartesDelMuneco` (una parte por error), dibujado en SVG |

## Evidencia de que cada etapa corta el pipeline

Probamos a propósito, en pull requests descartables (no se mergearon y las ramas se borraron), que un fallo en cada etapa detiene el resto:

| Etapa | Qué rompimos | PR | Resultado |
|---|---|---|---|
| Unit tests | un assert de un UT | #33 | `unit-tests` en rojo; las etapas siguientes omitidas |
| Cobertura | umbral de cobertura imposible | #34 | `unit-tests` en rojo; las etapas siguientes omitidas |
| Acceptance tests | el texto esperado de un escenario | #35 | `acceptance-tests` en rojo; `deploy` omitido |

El deploy está encadenado con `needs: acceptance-tests` y solo corre en push a `main`.