using OpenQA.Selenium; // Namespace para uso da classe IWebDriver

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPO
    {
        // 
        // ATRIBUTOS PRIVATIVOS - LOCALIZADORES
        //
        private IWebDriver driver;
        private By byInputLogin;
        private By byInputSenha;
        private By byBotaoLogin;

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        // 
        public LoginPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputSenha = By.Id("Password");
            byBotaoLogin = By.Id("btnLogin");
        }

        //
        // MÉTODOS COM LINGUAGEM FLUENTE
        //
        public LoginPO Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
            return this;
        }

        public LoginPO PreencheFormulario(string login, string senha)
        {
            return InformarEmail(login).InformarSenha(senha);
        }

        public LoginPO InformarEmail(string login)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            return this;
        }

        public LoginPO InformarSenha(string senha)
        {
            driver.FindElement(byInputSenha).SendKeys(senha);
            return this;
        }

        public LoginPO EfetuarLogin()
        {
            return SubmeteFormulario();
        }

        public LoginPO SubmeteFormulario()
        {
            driver.FindElement(byBotaoLogin).Submit();
            return this;
        }

        // Método terminal - onde as operações terminam de executar
        public void EfetuarLoginComCredenciais(string login, string senha)
        {
            // Métodos encadeados
            Visitar().PreencheFormulario(login, senha).SubmeteFormulario();
        }
    }
}
