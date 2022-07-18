using System.IO; // Biblioteca para uso da API IO do .Net "Path"
using System.Reflection; // Biblioteca para uso do método GetDirectoryName + Assembly

namespace Alura.LeilaoOnline.Selenium.Helpers
{
    public static class TestHelper
    {
        // Método com expressão Lambda
        public static string PastaDoExecutavel => Path.GetDirectoryName
            (Assembly.GetExecutingAssembly().Location);
    }
}
