namespace Ahorcado.Domain.Tests;

public class BancoDePalabrasTests
{
    [Test]
    public void Semilla_cero_elige_gato()
    {
        Assert.That(BancoDePalabras.Elegir(0), Is.EqualTo("GATO"));
    }
}