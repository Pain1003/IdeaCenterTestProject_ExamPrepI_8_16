﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17.Exam_Prep_I.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url = BaseUrl + "/Users/Login";

        public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@name='Email']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@name='Password']"));

        public IWebElement SignInButton => driver.FindElement(By.XPath("//button[text()='Sign in']"));

        public void Login(string email, string password)
        {
            EmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SignInButton.Click();
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

    }
}
