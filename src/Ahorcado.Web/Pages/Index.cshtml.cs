using Ahorcado.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Juego = Ahorcado.Domain.Ahorcado;

namespace Ahorcado.Web.Pages;

public class IndexModel : PageModel
{
    public string Palabra { get; private set; } = "";
    public string PalabraEnmascarada { get; private set; } = "";
    public int Vidas { get; private set; }
    public string LetrasJugadas { get; private set; } = "";
    public string Mensaje { get; private set; } = "";
    public bool Gano { get; private set; }
    public bool Perdio { get; private set; }
    public string Muneco { get; private set; } = "";
    public IReadOnlyList<string> Partes { get; private set; } = Array.Empty<string>();
    public string Nivel { get; private set; } = "";
    public void OnGet()
    {
        Palabra = Request.Query["word"].ToString();
        if (Palabra.Length == 0)
        {
            Palabra = int.TryParse(Request.Query["seed"], out var semilla)
                ? BancoDePalabras.Elegir(semilla)
                : BancoDePalabras.Elegir(Random.Shared.Next());
        }
        var jugadas = Request.Query["played"].ToString();
        var letra = Request.Query["letter"].ToString();

        Nivel = Request.Query["level"].ToString();
        var juego = new Juego(Palabra, Dificultad.Vidas(Nivel));
        
        foreach (var anterior in jugadas)
        {
            juego.Adivinar(anterior.ToString());
        }

        if (letra.Length > 0)
        {
            juego.Adivinar(letra);
            if (juego.UltimaJugadaRepetida)
            {
                Mensaje = $"Ya probaste la letra {letra}";
            }
            else if (juego.UltimaJugadaInvalida)
            {
                Mensaje = "Ingresá una sola letra";
            }
        }
        
        PalabraEnmascarada = juego.PalabraEnmascarada();
        Vidas = juego.Vidas;
        Gano = juego.Gano;
        Perdio = juego.Perdio;
        LetrasJugadas = juego.LetrasJugadas;
        Partes = juego.PartesDelMuneco;
        Muneco = string.Join(", ", Partes);
    }
}