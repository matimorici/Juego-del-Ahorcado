using Ahorcado.Domain;

namespace Ahorcado.Domain.Tests;

public class AhorcadoTests
{
    [Test]
    public void PalabraEnmascarada_ConGato_MuestraCuatroGuionesSeparadosPorEspacio()
    {
        var juego = new Ahorcado("GATO");

        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ _ _"));
    }
}