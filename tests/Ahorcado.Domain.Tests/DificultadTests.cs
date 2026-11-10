namespace Ahorcado.Domain.Tests;

public class DificultadTests
{
    [Test]
    public void Nivel_dificil_tiene_cuatro_vidas()
    {
        Assert.That(Dificultad.Vidas("dificil"), Is.EqualTo(4));
    }
}