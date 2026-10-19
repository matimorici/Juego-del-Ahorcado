namespace Ahorcado.Domain;

public class Ahorcado
{
    private readonly string _palabra;

    public Ahorcado(string palabra) => _palabra = palabra;
    
    public int Vidas => 6;

    public string PalabraEnmascarada() => string.Join(" ", _palabra.Select(_ => "_"));
}