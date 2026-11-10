namespace Ahorcado.Domain;

public class Ahorcado
{
    private const string PalabraPorDefecto = "AHORCADO";
    private const int VidasIniciales = 6;
    private const string ConTilde = "ÁÉÍÓÚÜ";
    private const string SinTilde = "AEIOUU";

    private readonly string _palabra;
    private readonly HashSet<char> _letrasAdivinadas = new();
    private static readonly string[] Partes =
        { "Cabeza", "Torso", "Brazo izquierdo", "Brazo derecho", "Pierna izquierda", "Pierna derecha" };
    private int _vidas = VidasIniciales;
    private int _vidasIniciales = VidasIniciales;
    public Ahorcado(string palabra) =>
        _palabra = string.IsNullOrEmpty(palabra) ? PalabraPorDefecto : palabra;
    public Ahorcado(string palabra, int vidasIniciales) : this(palabra)
    {
        _vidas = vidasIniciales;
        _vidasIniciales = vidasIniciales;
    }    public int Vidas => _vidas;
    public bool Gano => _palabra.All(c => _letrasAdivinadas.Contains(Normalizar(c)));
    public bool Perdio => _vidas <= 0;
    public string LetrasJugadas { get; private set; } = "";
    public IReadOnlyList<string> PartesDelMuneco =>
        Partes.Take(_vidasIniciales - _vidas).ToList();
    public bool UltimaJugadaRepetida { get; private set; }
    public bool UltimaJugadaInvalida { get; private set; }
    
    public void Adivinar(string letra) {
        if (Gano || Perdio) return;
        UltimaJugadaInvalida = letra.Length != 1 || !char.IsLetter(letra[0]);        if (UltimaJugadaInvalida)
        {
            UltimaJugadaRepetida = false;
            return;
        }
        
        var normalizada = Normalizar(letra[0]);

        UltimaJugadaRepetida = !_letrasAdivinadas.Add(normalizada);
        if (UltimaJugadaRepetida) return;

        LetrasJugadas += normalizada;
        if (!_palabra.Any(c => Normalizar(c) == normalizada)) _vidas--;
    }

    public string PalabraEnmascarada() =>
        string.Join(" ", _palabra.Select(c => Perdio || _letrasAdivinadas.Contains(Normalizar(c)) ? c.ToString() : "_"));

    private static char Normalizar(char c) {
        var mayuscula = char.ToUpperInvariant(c);
        var posicion = ConTilde.IndexOf(mayuscula);
        return posicion >= 0 ? SinTilde[posicion] : mayuscula;
    }
}