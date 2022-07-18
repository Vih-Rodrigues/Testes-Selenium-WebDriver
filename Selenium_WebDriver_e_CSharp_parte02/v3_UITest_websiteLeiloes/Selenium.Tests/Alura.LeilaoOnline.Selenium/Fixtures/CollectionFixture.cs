using Xunit; // Namespace para uso da classe ICollectionFixture

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    [CollectionDefinition("Chrome Driver")]
    public class CollectionFixture : ICollectionFixture<TestFixture>
    {
    }
}
