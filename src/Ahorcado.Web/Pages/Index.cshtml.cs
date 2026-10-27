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

    public void OnGet()
    {
        Palabra = Request.Query["word"].ToString();
        var jugadas = Request.Query["played"].ToString();
        var letra = Request.Query["letter"].ToString();

        var juego = new Juego(Palabra);
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
        }

        PalabraEnmascarada = juego.PalabraEnmascarada();
        Vidas = juego.Vidas;
        Gano = juego.Gano;
        LetrasJugadas = juego.LetrasJugadas;
    }
}
