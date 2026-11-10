namespace Ahorcado.Domain.Tests;

public class DificultadTests
{
    [Test]
    public void Nivel_dificil_tiene_cuatro_vidas()
    {
        Assert.That(Dificultad.Vidas("dificil"), Is.EqualTo(4));
    }
    [Test]
    public void Nivel_desconocido_tiene_seis_vidas()
    {
        Assert.That(Dificultad.Vidas("xyz"), Is.EqualTo(6));
    }
    
    [Test]
    public void Nivel_facil_tiene_ocho_vidas()
    {
        Assert.That(Dificultad.Vidas("facil"), Is.EqualTo(8));
    }
}