# NOTES.md — Trazabilidad Historia de Usuario → Criterio → Escenario (AT) → Unit Tests

Mecanismo de trazabilidad elegido: **matriz en este archivo**, combinada con etiquetas de Gherkin
(`@HU-XX`, `@AC-X`) sobre cada Característica/Escenario en los `.feature`. La matriz es la vista humana
y ejecutable en la defensa; las etiquetas permiten filtrar (`dotnet test --filter Category=HU-02`).

## Matriz

| HU | Criterio de aceptación | Escenario (AT) | Unit Tests | Estado |
|---|---|---|---|---|
| **HU-01** Iniciar partida | AC-1: Ver un guion bajo por cada letra de la palabra. | Arrancar la partida con la palabra oculta |  | Pendiente |
| **HU-01** Iniciar partida | AC-2: Ver 6 vidas | Arrancar la partida con 6 vidas |  | Pendiente |
