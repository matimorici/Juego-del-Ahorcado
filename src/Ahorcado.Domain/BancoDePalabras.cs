namespace Ahorcado.Domain;

public static class BancoDePalabras
{
    private static readonly string[] Palabras =
        { "GATO", "PERRO", "MARIPOSA", "CANCIÓN", "NIÑO", "ELEFANTE" };

    public static string Elegir(int semilla) => Palabras[semilla % Palabras.Length];
}