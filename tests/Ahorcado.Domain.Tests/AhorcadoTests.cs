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
    public void Perdio_al_agotar_las_vidas()
    {
        var juego = new Ahorcado("GATO");

        foreach (var letra in new[] { "B", "C", "D", "E", "F", "H" })
            juego.Adivinar(letra);

        Assert.That(juego.Perdio, Is.True);
    }
    [Test]
    public void No_perdio_con_cinco_fallos()
    {
        var juego = new Ahorcado("GATO");

        foreach (var letra in new[] { "B", "C", "D", "E", "F" })
            juego.Adivinar(letra);

        Assert.That(juego.Perdio, Is.False);
    }
    [Test]
    public void Palabra_se_revela_al_perder()
    {
        var juego = new Ahorcado("GATO");

        foreach (var letra in new[] { "B", "C", "D", "E", "F", "H" })
            juego.Adivinar(letra);

        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("G A T O"));
    }
    [Test]
    public void Adivinar_letra_en_minuscula_revela_la_letra_en_mayuscula()
    {
        var juego = new Ahorcado("GATO");

        juego.Adivinar("a");

        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ A _ _"));
    }
    [Test]
    public void Adivinar_letra_en_minuscula_presente_no_descuenta_vida()
    {
        var juego = new Ahorcado("GATO");

        juego.Adivinar("a");

        Assert.That(juego.Vidas, Is.EqualTo(6));
    }

    [Test]
    public void Adivinar_con_la_partida_perdida_no_descuenta_vidas()
    {
        var juego = new Ahorcado("GATO");
        foreach (var letra in "BCDEFH") juego.Adivinar(letra.ToString());
        juego.Adivinar("Z");
        Assert.That(juego.Vidas, Is.EqualTo(0));
    }
    [Test]
    public void Adivinar_con_la_partida_ganada_no_descuenta_vidas()
    {
        var juego = new Ahorcado("SOL");
        foreach (var letra in "SOL") juego.Adivinar(letra.ToString());
        juego.Adivinar("Z");
        Assert.That(juego.Vidas, Is.EqualTo(6));
    }

    [Test]
    public void Adivinar_letra_sin_tilde_revela_la_letra_con_tilde()
    {
        var juego = new Ahorcado("CANCIÓN");
        juego.Adivinar("O");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ _ _ _ Ó _"));
    }
    [Test]
    public void Gano_con_palabra_con_tilde()
    {
        var juego = new Ahorcado("CANCIÓN");
        foreach (var letra in "CANIO") juego.Adivinar(letra.ToString());
        Assert.That(juego.Gano, Is.True);
    }
    [Test]
    public void Adivinar_n_no_revela_la_enie()
    {
        var juego = new Ahorcado("NIÑO");
        juego.Adivinar("N");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("N _ _ _"));
    }
    [Test]
    public void Adivinar_enie_revela_la_enie()
    {
        var juego = new Ahorcado("NIÑO");
        juego.Adivinar("Ñ");
        Assert.That(juego.PalabraEnmascarada(), Is.EqualTo("_ _ Ñ _"));
    }

    [Test]
    public void Muneco_con_un_error_muestra_la_cabeza()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("E");
        Assert.That(juego.PartesDelMuneco, Is.EqualTo(new[] { "Cabeza" }));
    }
    [Test]
    public void Muneco_con_dos_errores_muestra_cabeza_y_torso()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("E");
        juego.Adivinar("I");
        Assert.That(juego.PartesDelMuneco, Is.EqualTo(new[] { "Cabeza", "Torso" }));
    }
    
    [Test]
    public void Entrada_que_no_es_letra_no_descuenta_vida()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("5");
        Assert.That(juego.Vidas, Is.EqualTo(6));
    }
    [Test]
    public void Entrada_que_no_es_letra_queda_informada()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("5");
        Assert.That(juego.UltimaJugadaInvalida, Is.True);
    }
    [Test]
    public void Un_simbolo_tambien_queda_informado_como_entrada_invalida()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("#");
        Assert.That(juego.UltimaJugadaInvalida, Is.True);
    }
    [Test]
    public void Entrada_invalida_despues_de_una_repetida_no_queda_como_repetida()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("E");
        juego.Adivinar("E");
        juego.Adivinar("5");
        Assert.That(juego.UltimaJugadaRepetida, Is.False);
    }
    
    [Test]
    public void Entrada_de_mas_de_una_letra_no_descuenta_vida()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("EX");
        Assert.That(juego.Vidas, Is.EqualTo(6));
    }
    [Test]
    public void Entrada_de_mas_de_una_letra_queda_informada()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("EX");
        Assert.That(juego.UltimaJugadaInvalida, Is.True);
    }
    [Test]
    public void Otra_entrada_de_mas_de_una_letra_tambien_queda_informada()
    {
        var juego = new Ahorcado("GATO");
        juego.Adivinar("XYZ");
        Assert.That(juego.UltimaJugadaInvalida, Is.True);
    }
}