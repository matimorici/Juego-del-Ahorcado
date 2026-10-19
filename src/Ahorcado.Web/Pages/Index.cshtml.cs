using Microsoft.AspNetCore.Mvc.RazorPages;
using Juego = Ahorcado.Domain.Ahorcado;

namespace Ahorcado.Web.Pages;

public class IndexModel : PageModel
{
    public string PalabraEnmascarada { get; private set; } = "";

    public void OnGet()
    {
        var palabra = Request.Query["word"].ToString();
        PalabraEnmascarada = new Juego(palabra).PalabraEnmascarada();
    }
}
