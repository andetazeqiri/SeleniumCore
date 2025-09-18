﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCore;

[TestClass]
public class HomepageFeauture { 

     IWebDriver _driver;
    [TestMethod]
    public void shouldBeAbleToLogIn()
    {
         _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com");

        var loginButtonLocator = By.ClassName("submit-button");
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(loginButtonLocator));

        var userNameField = _driver.FindElement(By.Id("user-name"));
        var passwordField = _driver.FindElement(By.Id("password"));
        var loginButton = _driver.FindElement(loginButtonLocator);

        userNameField.SendKeys("standard_user");
        passwordField.SendKeys("secret_sauce");
        loginButton.Click();

        Assert.IsTrue(_driver.Url.Contains("inventory.html"));

    }
    [TestCleanup]
    public void CleanUp()
    {
    _driver.Quit();
    }
}
