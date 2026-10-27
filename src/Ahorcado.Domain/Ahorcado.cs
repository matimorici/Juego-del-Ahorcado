namespace Ahorcado.Domain;

public class Ahorcado
{
    private const string PalabraPorDefecto = "AHORCADO";
    private const int VidasIniciales = 6;

    private readonly string _palabra;
    private readonly HashSet<char> _letrasAdivinadas = new();
    private int _vidas = VidasIniciales;

    public Ahorcado(string palabra) =>
        _palabra = string.IsNullOrEmpty(palabra) ? PalabraPorDefecto : palabra;

    public int Vidas => _vidas;
    public bool Gano => _palabra.All(c => _letrasAdivinadas.Contains(c));
    public bool Perdio => _vidas <= 0;
    public string LetrasJugadas { get; private set; } = "";
    public bool UltimaJugadaRepetida { get; private set; }

    public void Adivinar(string letra)
    {
        var normalizada = char.ToUpperInvariant(letra[0]);

        UltimaJugadaRepetida = !_letrasAdivinadas.Add(normalizada);
        if (UltimaJugadaRepetida) return;

        LetrasJugadas += letra[0];
        if (!_palabra.Contains(normalizada)) _vidas--;
    }

    public string PalabraEnmascarada() =>
        string.Join(" ", _palabra.Select(c => Perdio || _letrasAdivinadas.Contains(c) ? c.ToString() : "_"));
}