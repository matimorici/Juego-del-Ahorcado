# NOTES.md — Trazabilidad Historia de Usuario → Criterio → Escenario (AT) → Unit Tests

Mecanismo de trazabilidad elegido: **matriz en este archivo**, combinada con etiquetas de Gherkin
(`@HU-XX`, `@AC-X`) sobre cada Característica/Escenario en los `.feature`. La matriz es la vista humana
y ejecutable en la defensa; las etiquetas permiten filtrar (`dotnet test --filter Category=HU-02`).

Link al Story Map: https://miro.com/welcomeonboard/R2w3Z2dKOFJjZjVUTTlFVnFqeDRZSmVlZjlJL2dUcUgrUlVpQVphM1JnTWZacmJVVUZUdGFaUS9kTStsaGxnekc0VGx4RTVuTjBOWFYvRzRlNldqOFdqT2UyY2d1NDZzTXhiTmllc2dHNnZBVU5zckR3QjljSi9rNzQ5SFRzNnNzVXVvMm53MW9OWFg5bkJoVXZxdFhRPT0hdjE=?share_link_id=377491566949

## Matriz

| HU | Criterio de aceptación | Escenario (AT) | Unit Tests | Estado |
|---|---|---|---|---|
| **HU-01** Iniciar partida | AC-1: Ver un guion bajo por cada letra de la palabra. | Arrancar la partida con la palabra oculta |  | Pendiente |
| **HU-01** Iniciar partida | AC-2: Ver 6 vidas | Arrancar la partida con 6 vidas |  | Pendiente |


## Pendientes técnicos

- **Levantar la Web automáticamente para los AT (CI):** en Playwright-JS el `webServer` del
  `playwright.config.ts` levanta la app solo antes de correr los tests. En .NET/Reqnroll no viene
  gratis: por ahora levantamos `Ahorcado.Web` a mano en otra terminal antes de correr
  `dotnet test` en `Ahorcado.AcceptanceTests`. Antes del pipeline de CI (§3.5 del TP, etapa 5)
  hay que resolver esto sin intervención manual. Opciones a evaluar:
  - Spawnear el proceso (`dotnet run --project src/Ahorcado.Web`) desde un hook
    `[BeforeTestRun]` en `PlaywrightHooks.cs`, esperar a que responda 200, y matarlo en
    `[AfterTestRun]`.
  - Usar `WebApplicationFactory<T>` / `TestServer` de ASP.NET Core para hostear la Web
    in-process y apuntar Playwright a esa instancia (evita levantar un proceso aparte, pero
    hay que chequear que sea compatible con Playwright apuntando a una URL real).
  - Un script/step de CI que levanta la Web en background (`dotnet run &`), espera el health
    check, corre los AT, y la mata al final.