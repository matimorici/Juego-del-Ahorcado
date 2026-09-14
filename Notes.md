# NOTES.md — Trazabilidad Historia de Usuario → Criterio → Escenario (AT) → Unit Tests

Mecanismo de trazabilidad elegido: **matriz en este archivo**, combinada con etiquetas de Gherkin
(`@HU-XX`, `@CA-X`) sobre cada Característica/Escenario en los `.feature`. La matriz es la vista humana
y ejecutable en la defensa; las etiquetas permiten filtrar (`dotnet test --filter Category=HU-02`).

Link al Story Map / tablero: `<pegar acá el link del Story Map o del tablero de issues>`

## Matriz

| HU | Criterio de aceptación | Escenario (AT) | Unit Tests | Estado |
|---|---|---|---|---|
| **HU-01** Iniciar partida | Arranca con la palabra oculta y las vidas iniciales completas | Arranca con la palabra oculta y las vidas completas | `Al_crear_la_palabra_queda_totalmente_oculta`<br>`Al_crear_las_vidas_iniciales_son_6` | Pendiente |
| **HU-02** Ingresar letra | CA-1: una letra presente se revela sin perder vidas | Acierta una letra | `Revela_todas_las_ocurrencias_de_la_letra_acertada`<br>`La_letra_acertada_no_descuenta_vidas` | Pendiente |
| **HU-02** Ingresar letra | CA-2: una letra ausente cuesta una vida | Falla una letra | `La_letra_ausente_descuenta_una_vida` | Pendiente |
| **HU-02** Ingresar letra | CA-3: una letra repetida no penaliza | Re-ingresa una letra ya intentada | `Repetir_letra_no_descuenta_vidas_ni_cambia_estado` | Pendiente |
| **HU-02** Ingresar letra | CA-4: una entrada que no es letra no se procesa | Ingresa un carácter inválido | `Entrada_no_alfabetica_es_ignorada`<br>`Entrada_sobre_partida_terminada_es_ignorada` | Pendiente |
| **HU-03** Terminar la partida | CA-1: completar todas las letras termina en victoria | Gana la partida | `Partida_termina_en_victoria_cuando_se_revela_toda_la_palabra` | Pendiente |
| **HU-03** Terminar la partida | CA-2: agotar las vidas termina en derrota y revela la palabra | Pierde la partida | `Partida_termina_en_derrota_tras_agotar_las_vidas`<br>`Al_perder_se_expone_la_palabra_completa` | Pendiente |
