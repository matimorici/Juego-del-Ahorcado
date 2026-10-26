namespace Ahorcado.Domain;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _letrasAdivinadas = new();

    // public Ahorcado(string palabra) => _palabra = palabra;

    public int Vidas => 6;

    public void Adivinar(string letra)
    {
        _letrasAdivinadas.Add(letra[0]);
        LetrasJugadas += letra[0];
    }

    public string PalabraEnmascarada() =>
        string.Join(" ", _palabra.Select(c => _letrasAdivinadas.Contains(c) ? c.ToString() : "_"));
    private const string PalabraPorDefecto = "AHORCADO";

    public Ahorcado(string palabra) =>
        _palabra = string.IsNullOrEmpty(palabra) ? PalabraPorDefecto : palabra;

    public string LetrasJugadas { get; private set; } = "";
    
}