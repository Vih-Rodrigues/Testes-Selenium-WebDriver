using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using Alura.LeilaoOnline.Selenium.Fixtures; // Namespace para uso da classe TestFixture
using Xunit;
using Alura.LeilaoOnline.Selenium.PageObjects; // Namespace para uso da classe RegistroPO

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        // ATRIBUTO
        private IWebDriver driver;

        // CONSTRUTOR
        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        // 1º MÉTODO-TESTE
        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimentos()
        {
            //
            // ARRANGE
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            // Método FindElement = captura os elementos em HTML da página atual
            // O método FindElement recebe várias estratégias de localização, uma delas é a "By.Id"

            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            // SendKeys = método para informar valores ao elemento
            inputNome.SendKeys("Vitoria Mercado");
            inputEmail.SendKeys("andrader.vitoria@gmail.com");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            // Botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //
            // ACT
            //
            // Quando o botão for clicado, o formulário será submetido à aplicação.
            botaoRegistro.Click();

            //
            // ASSERT
            //
            Assert.Contains("Obrigado", driver.PageSource);
        }

        // 2º MÉTODO-TESTE
        // Theory indica os testes que devem ser feitos em sequência, na classe abaixo
        [Theory]
        [InlineData("", "andrader.vitoria@gmail.com", "123", "123")] // 1º teste: nome vazio
        [InlineData("Vitoria Mercado", "andrader", "123", "123")] // 2º teste: email inválido
        [InlineData("Vitoria Mercado", "andrader.vitoria@gmail.com", "123", "456")] // 3º teste: confirmação de senha inválida
        [InlineData("Vitoria Mercado", "andrader.vitoria@gmail.com", "123", "")] // 4º teste: confirmação de senha vazia
        public void DadoInformacoesInvalidasDeveContinuarNaHome(string nome, string email, string senha, string confirmSenha)
        {
            //
            // ARRANGE
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            var inputNome = driver.FindElement(By.Id("Nome"));
            var inputEmail = driver.FindElement(By.Id("Email"));
            var inputSenha = driver.FindElement(By.Id("Password"));
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            // SendKeys = método para informar valores ao elemento
            inputNome.SendKeys("nome");
            inputEmail.SendKeys("email");
            inputSenha.SendKeys("senha");
            inputConfirmSenha.SendKeys("confirmSenha");

            // Botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //
            // ACT
            //
            // Quando o botão for clicado, o formulário será submetido à aplicação.
            botaoRegistro.Click();

            //
            // ASSERT
            //
            // "Onde contêm a tag do tipo section 'section-registro' no código fonte da página..."
            Assert.Contains("section-registro", driver.PageSource);
        }

        // 3º MÉTODO-TESTE
        // Verifica se o texto "The Nome field is required" (erro para campo "Nome" vazio) aparece no momento em que o botão "Registrar" é clicado
        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            //
            // ARRANGE
            //
            driver.Navigate().GoToUrl("http://localhost:5000");

            // ATENÇÃO: Não vai ser necessário capturar nada, logo deixamos apenas a declaração do botão!

            // Botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //
            // ACT
            //
            botaoRegistro.Click();

            //
            // ASSERT 
            //
            // Regra span.msg-erro[data-valmsg-for=Nome] criada no código fonte HTML da página de Leilões
            IWebElement elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            // Verifica se a mensagem The Nome field is required está sendo exibida no span
            Assert.Equal("The Nome field is required.", elemento.Text);
        }

        // 4º MÉTODO-TESTE
        // Verifica se o texto "The Nome field is required" (erro para campo "Nome" vazio) aparece no momento em que o botão "Registrar" é clicado
        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            //
            // ARRANGE
            //
            var registroPO = new RegistroPO(driver);
            
            // Chamada do método para navegar para a URL do site
            registroPO.Visitar();

            registroPO.PreencheFormulario(nome: "", email: "vitoria", senha: "", confirmSenha: "");

            //
            // ACT
            //
            // clicado o botão "Registrar"
            registroPO.SubmeteFormulario();

            //
            // ASSERT 
            //
            // Verifica se a mensagem Please enter a valid email address está sendo exibida no span
            Assert.Equal("Please enter a valid email address.", registroPO.EmailMensagemErro);
        }
    }
}
