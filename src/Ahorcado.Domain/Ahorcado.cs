namespace Ahorcado.Domain;

public class Ahorcado
{
    private readonly string _palabra;
    private readonly HashSet<char> _letrasAdivinadas = new();

    public string PalabraEnmascarada() =>
        string.Join(" ", _palabra.Select(c => _letrasAdivinadas.Contains(c) ? c.ToString() : "_"));
	public bool Gano => _palabra.All(c => _letrasAdivinadas.Contains(c));    private const string PalabraPorDefecto = "AHORCADO";
    public Ahorcado(string palabra) =>
        _palabra = string.IsNullOrEmpty(palabra) ? PalabraPorDefecto : palabra;

    private int _vidas = 6;

    public int Vidas => _vidas;

    public string LetrasJugadas { get; private set; } = "";
    public bool UltimaJugadaRepetida { get; private set; }

    public void Adivinar(string letra)
    {
		UltimaJugadaRepetida = !_letrasAdivinadas.Add(char.ToUpperInvariant(letra[0]));
        if (UltimaJugadaRepetida) return;

        LetrasJugadas += letra[0];
        if (!_palabra.Contains(letra[0])) _vidas--;
    }
}