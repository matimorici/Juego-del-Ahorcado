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
    [Test]
    public void Adivinar_letra_presente_revela_todas_sus_ocurrencias()
    {
        var juego = new Ahorcado("ALA");
        juego.Adivinar("A");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("A _ A"));
    }
    [Test]
    public void Letras_jugadas_registra_la_letra_adivinada()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("A");
        Assert.That(juego.LetrasJugadas, Is.EqualTo("A"));
    }
    [Test]
    public void Letras_jugadas_acumula_las_letras_en_orden()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("A");
        juego.Adivinar("T");
        Assert.That(juego.LetrasJugadas, Is.EqualTo("AT"));
    }

    [Test]
    public void Palabra_vacia_usa_la_palabra_por_defecto()
    {
        var juego = new Ahorcado("");

        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ _ _ _ _ _ _"));
    }
    [Test]
    public void Adivinar_letra_ausente_descuenta_una_vida()
    {
        var juego = new Ahorcado("GATO");

        juego.Adivinar("E");

        Assert.That(juego.Vidas, Is.EqualTo(5));
    }
    [Test]
    public void Adivinar_dos_letras_ausentes_descuentan_dos_vidas()
    {
        var juego = new Ahorcado("GATO");

        juego.Adivinar("E");
        juego.Adivinar("X");

        Assert.That(juego.Vidas, Is.EqualTo(4));
    }

    [Test]
    public void Letra_repetida_no_descuenta_otra_vida()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("E");
        juego.Adivinar("E");
        Assert.That(juego.Vidas, Is.EqualTo(5));
    }
    [Test]
    public void Letra_repetida_queda_informada()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("E");
        juego.Adivinar("E");
        Assert.That(juego.UltimaJugadaRepetida, Is.True);
    }
	[Test]
	public void Gano_al_adivinar_todas_las_letras()
	{
    	var juego = new Ahorcado("GATO");

    	juego.Adivinar("G");
    	juego.Adivinar("A");
    	juego.Adivinar("T");
    	juego.Adivinar("O");

    	Assert.That(juego.Gano, Is.True);
	}
	[Test]
	public void No_gano_si_faltan_letras()
	{
	    var juego = new Ahorcado("GATO");

    	juego.Adivinar("G");
    	juego.Adivinar("A");
	    juego.Adivinar("T");

    	Assert.That(juego.Gano, Is.False);
	}
    [Test]
    public void Adivinar_letra_en_minuscula_revela_la_letra_en_mayuscula()
    {
        var juego = new Ahorcado("GATO");

        juego.Adivinar("a");

        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ A _ _"));
    }
}