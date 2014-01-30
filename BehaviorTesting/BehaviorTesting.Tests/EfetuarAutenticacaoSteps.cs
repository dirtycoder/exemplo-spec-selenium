using TechTalk.SpecFlow;
using OpenQA.Selenium.Firefox;
using FluentAssertions;
using System.Diagnostics;

namespace OpenTravel.Tests
{
    [Binding]
    public class EfetuarAutenticacaoSteps
    {
        private FirefoxDriver _browser;
        private static Process _processo;

        [BeforeTestRun]
        public static void IniciarIISExpress()
        {
            _processo = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"C:\Program Files\IIS Express\iisexpress.exe";
            psi.Arguments = @"/path:c:\Projetos\OpenTravel\OpenTravel /port:8080";
            psi.UseShellExecute = true;
            _processo.StartInfo = psi;
            _processo.Start();
        }

        [BeforeScenario]
        public void AbrirNavegador()
        {
            _browser = new FirefoxDriver();
        }

        [AfterScenario]
        public void FecharNavegador()
        {
            _browser.Dispose();
        }

        [AfterTestRun]
        public static void FecharIISExpress()
        {
            _processo.Kill();
        }

        [Given(@"que estou na home na aplicação")]
        public void DadoQueEstouNaHomeNaAplicacao()
        {
            _browser.Navigate().GoToUrl("http://localhost:8080/");
        }

        [Given(@"clico em Log In")]
        public void DadoClicoEmLogIn()
        {
            _browser.FindElementByCssSelector("#loginLink").Click();
        }

        [Given(@"preencho o usuário com ""(.*)""")]
        public void DadoPreenchoOUsuarioCom(string p0)
        {
            _browser.FindElementByCssSelector("#UserName").SendKeys(p0);
        }

        [Given(@"preencho a senha com ""(.*)""")]
        public void DadoPreenchoASenhaCom(string p0)
        {
            _browser.FindElementByCssSelector("#Password").SendKeys(p0);
        }

        [When(@"clico no botão de Log In")]
        public void QuandoClicoNoBotaoDeLogIn()
        {
            _browser.FindElementByCssSelector(".btn.btn-default").Click();
        }

        [Then(@"vejo ""(.*)""")]
        public void EntaoVejo(string p0)
        {
            _browser.PageSource.Contains(p0).Should().BeTrue();
        }
    }
}
