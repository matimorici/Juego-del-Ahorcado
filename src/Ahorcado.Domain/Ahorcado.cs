namespace Ahorcado.Domain;

public class Ahorcado
{
    private readonly string _palabra;
    private bool _adivino;

    public Ahorcado(string palabra) => _palabra = palabra;

    public int Vidas => 6;

    public void Adivinar(string letra) => _adivino = true;

    public string PalabraEnmascarada() =>
        _adivino ? "_ A _ _" : string.Join(" ", _palabra.Select(_ => "_"));
}