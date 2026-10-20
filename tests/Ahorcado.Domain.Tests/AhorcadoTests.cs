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

    [Test]
    public void Vidas_al_iniciar_la_partida_son_seis()
    {
        var juego = new Ahorcado("GATO");
        Assert.That(juego.Vidas, Is.EqualTo(6));
    }

    [Test]
    public void Adivinar_letra_presente_revela_su_posicion()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("A");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ A _ _"));
    }
}