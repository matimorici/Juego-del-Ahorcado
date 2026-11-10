namespace Ahorcado.Domain;

public static class Dificultad
{
    public static int Vidas(string nivel) => nivel == "dificil" ? 4 : 6;
    
}