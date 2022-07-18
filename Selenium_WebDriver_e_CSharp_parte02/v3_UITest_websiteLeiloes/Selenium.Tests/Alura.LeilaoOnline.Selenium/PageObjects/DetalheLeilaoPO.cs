using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using System.Globalization; // Namespace para uso da enumeração NumberStyles

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DetalheLeilaoPO
    {
        //
        // ATRIBUTO PRIVATIVO
        //
        private IWebDriver driver;
        private By byInputValor;
        private By byBotaoOfertar;
        private By byLanceAtual;

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public DetalheLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputValor = By.Id("Valor");
            byBotaoOfertar = By.Id("btnDarLance");
            byLanceAtual = By.Id("lanceAtual");
        }

        //
        // PROPRIEDADE CUSTOMIZADA
        //
        public double LanceAtual
        {
            get
            {
                var valorTexto = driver.FindElement(byLanceAtual).Text;
                var valor = double.Parse(valorTexto, NumberStyles.Currency); // NumberStyle determina os estilos permitidos em argumentos de cadeia de caracteres numéricos que são passados para o método Parse, Currency indica estilo de numero composto
                return valor;
            }
        }

        //
        // MÉTODOS
        //
        public void Visitar(int idLeilao)
        {
            driver.Navigate().GoToUrl($"http://localhost:5000/Home/Detalhes/{idLeilao}"); // Uso de interpolação para navegar para o id de cada leilão
        }

        public void OfertarLance(double valor)
        {
            driver.FindElement(byInputValor).Clear(); // Comando adicionado fora do curso para execução do teste 100%
            driver.FindElement(byInputValor).SendKeys(valor.ToString());
            driver.FindElement(byBotaoOfertar).Click();
        }
    }
}
