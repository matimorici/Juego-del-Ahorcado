# Juego-del-Ahorcado

Construcción del juego utilizando prácticas de ingeniería que permitan evolucionar, probar e integrar el producto de manera continua.

## Enlaces

- **App en producción:** https://juego-del-ahorcado-6spt.onrender.com/
- **Pipeline (GitHub Actions):** https://github.com/matimorici/Juego-del-Ahorcado/actions
- **Dashboard de calidad (SonarQube Cloud):** https://sonarcloud.io/summary/new_code?id=matimorici_Juego-del-Ahorcado&branch=main
- **Story Map y trazabilidad Historia → AT → UT:** ver [Notes.md](Notes.md)

## Pipeline

Cada push (y cada pull request) ejecuta, en orden y cortando ante el primer fallo:

1. **build:** compila la solución.
2. **unit-tests:** unit tests del dominio, con umbral de cobertura del 90% sobre `Ahorcado.Domain`.
3. **sonar:** análisis estático con SonarQube Cloud y quality gate bloqueante.
4. **acceptance-tests:** escenarios Gherkin (Reqnroll) con Playwright sobre la app real.
5. **deploy:** despliegue a Render, solo en push a `main`.

## Correr en local

```
dotnet run --project src/Ahorcado.Web
dotnet test
```

Para fijar la palabra en una partida: `http://localhost:5020/?word=GATO`
