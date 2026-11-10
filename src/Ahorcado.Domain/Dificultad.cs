namespace Ahorcado.Domain;

public static class Dificultad
{
    public static int Vidas(string nivel) => nivel switch
    {
        "dificil" => 4,
        "facil" => 8,
        _ => 6
    };
    
}