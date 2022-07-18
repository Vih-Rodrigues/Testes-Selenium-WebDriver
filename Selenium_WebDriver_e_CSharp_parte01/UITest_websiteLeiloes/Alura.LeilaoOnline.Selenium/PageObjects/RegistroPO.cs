using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPO
    {
        //
        // ATRIBUTOS PRIVADOS
        //
        private IWebDriver driver;

        // Armazenamento de todos os localizadores necessários para realizar as ações que 
        // são feitas na classe RegistroPO 
        private By byFormRegistro; // Localizador do formulário de registro
        private By byInputNome;
        private By byInputEmail;
        private By byInputSenha;
        private By byInputConfirmSenha;
        private By byBotaoRegistro;
        private By bySpanErroEmail;

        //
        // Propriedade com expressão LAMBDA - somente para leitura
        //
        public string EmailMensagemErro => driver.FindElement(bySpanErroEmail).Text;

        //
        // CONSTRUTOR
        //
        // Injeção de dependência - "A classe RegistroPO depende de um objeto IWebDriver"
        public RegistroPO(IWebDriver driver)
        {
            this.driver = driver;

            // Inicializando os atributos privados
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputSenha = By.Id("Password");
            byInputConfirmSenha = By.Id("ConfirmPassword");
            byBotaoRegistro = By.Id("btnRegistro");
            bySpanErroEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        //
        // MÉTODOS
        //
        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        // Método para encapsulamente do clique no botão "Registrar"
        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoRegistro).Click();
        }

        public void PreencheFormulario(string nome, string email, string senha, string confirmSenha)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputSenha).SendKeys(senha);
            driver.FindElement(byInputConfirmSenha).SendKeys(confirmSenha);
        }
    }
}
