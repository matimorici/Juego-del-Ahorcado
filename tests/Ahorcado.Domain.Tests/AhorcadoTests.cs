using Ahorcado.Domain;

namespace Ahorcado.Domain.Tests;

public class AhorcadoTests
{
    [Test]
    public void Palabra_enmascarada_de_GATO_muestra_cuatro_guiones()
    {
        var juego = new Ahorcado("GATO");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ _ _"));
    }

    [Test]
    public void Palabra_enmascarada_de_PERRO_muestra_cinco_guiones()
    {
        var juego = new Ahorcado("PERRO");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ _ _ _"));
    }
}