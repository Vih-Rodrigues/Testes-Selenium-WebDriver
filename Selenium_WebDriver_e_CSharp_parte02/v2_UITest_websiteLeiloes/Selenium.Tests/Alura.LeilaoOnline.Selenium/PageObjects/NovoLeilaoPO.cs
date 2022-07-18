// Classe Page Object para representar o formulário de inclusão de leilão

using OpenQA.Selenium; // Namespace para uso da classe IWebDriver
using System; // Namespace para uso do tipo DateTime
using System.Collections.Generic; // Namespace para uso do tipo IEnumerable
using OpenQA.Selenium.Support.UI; // Namespace para uso SelectElement
using System.Linq; // Namespace para uso do Select

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class NovoLeilaoPO
    {
        //
        // ATRIBUTOS PRIVATIVOS
        //
        private IWebDriver driver;
        private By byInputTitulo; // atributo para guardar a estratégia de localização do campo "Título"
        private By byInputDescricao; // atributo para guardar a estratégia de localização do campo "Descrição"
        private By byInputCategoria; // atributo para guardar a estratégia de localização do campo "Categoria"
        private By byInputValorInicial; // atributo para guardar a estratégia de localização do campo "Valor inicial"
        private By byInputImagem; // atributo para guardar a estratégia de localização do campo imagem
        private By byInputInicioPregao; // atributo para guardar a estratégia de localização do campo "Início Pregão"
        private By byInputTerminoPregao; // atributo para guardar a estratégia de localização do campo "Término Pregão"
        private By byBotaoSalvar;

        //
        // CONSTRUTOR - INICIALIZA OS OBJETOS
        //
        public NovoLeilaoPO(IWebDriver driver)
        {
            this.driver = driver;
            byInputTitulo = By.Id("Titulo");
            byInputDescricao = By.Id("Descricao");
            byInputCategoria = By.Id("Categoria");
            byInputValorInicial = By.Id("ValorInicial");
            byInputImagem = By.Id("ArquivoImagem");
            byInputInicioPregao = By.Id("InicioPregao");
            byInputTerminoPregao = By.Id("TerminoPregao");
            byBotaoSalvar = By.CssSelector("button[type=submit");
        }

        //
        // PROPRIEDADE
        //
        public IEnumerable<string> Categorias
        {
            get
            {
                var elementoCategoria = new SelectElement(driver.FindElement(byInputCategoria));
                return elementoCategoria.Options
                    .Where(opcao => opcao.Enabled) // Retorna se o objeto IWebElement está habilitado
                    .Select(opcao => opcao.Text);
            }
        }

        //
        // MÉTODOS
        //
        public void Visitar()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Leiloes/Novo");
        }

        public void PreencheFormulario(string titulo, string descricao, string categoria, double valor, string imagem, DateTime inicio, DateTime termino)
        {
            driver.FindElement(byInputTitulo).SendKeys(titulo); // SendKeys coloca valor dentro de um objeto do tipo IWebElement
            driver.FindElement(byInputDescricao).SendKeys(descricao);
            // Jeito da aula: driver.FindElement(byInputCategoria).SendKeys(categoria);
            driver.FindElement(byInputCategoria).GetAttribute($"option[value={categoria}]"); // Proposta de aluno para funcionar
            driver.FindElement(byInputValorInicial).SendKeys(valor.ToString()); // Converte double para string
            driver.FindElement(byInputImagem).SendKeys(imagem);
            driver.FindElement(byInputInicioPregao).SendKeys(inicio.ToString("dd/MM/yyyy")); // Converte DateTime para string
            driver.FindElement(byInputTerminoPregao).SendKeys(termino.ToString("dd/MM/yyyy")); // Converte DateTime para string
        }

        public void SubmeteFormulario()
        {
            driver.FindElement(byBotaoSalvar).Click();
        }
    }
}
