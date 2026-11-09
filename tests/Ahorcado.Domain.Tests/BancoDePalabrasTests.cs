namespace Ahorcado.Domain.Tests;

public class BancoDePalabrasTests
{
    [Test]
    public void Semilla_cero_elige_gato()
    {
        Assert.That(BancoDePalabras.Elegir(0), Is.EqualTo("GATO"));
    }
    [Test]
    public void Semilla_uno_elige_perro()
    {
        Assert.That(BancoDePalabras.Elegir(1), Is.EqualTo("PERRO"));
    }
    [Test]
    public void Semilla_dos_elige_mariposa()
    {
        Assert.That(BancoDePalabras.Elegir(2), Is.EqualTo("MARIPOSA"));
    }
    
}