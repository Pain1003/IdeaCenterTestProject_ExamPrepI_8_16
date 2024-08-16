using _17.Exam_Prep_I.Pages;
using OpenQA.Selenium.DevTools.V125.HeapProfiler;

namespace _17.Exam_Prep_I.Tests
{
    public class IdeaCenterTests : BaseTest
    {
        public string lastCreatedIdeaTitle;
        public string lastCreatedIdeaDescription;

        [Test, Order(1)]
        public void CreateIdeaWithInvalidDataTest()
        {
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea("", "", "");

            createIdeaPage.AssertErrorMessages();
        }
        [Test, Order(2)]
        public void CreateRandomIdeaWithValidDataTest()
        {
            lastCreatedIdeaTitle = "Idea " + GenerateRandomString(5);
            lastCreatedIdeaDescription = "Description " + GenerateRandomString(5);
            
            createIdeaPage.OpenPage();

            createIdeaPage.CreateIdea(lastCreatedIdeaTitle, "", lastCreatedIdeaDescription);

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL is not correct");
            Assert.That(myIdeasPage.DescriptionLastIdea.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Descriptions do not match");
        }
        
        [Test, Order(3)]
        public void ViewLastCreatedIdea()
        {
            myIdeasPage.OpenPage();
            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(lastCreatedIdeaTitle), "Title does not match");

            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(lastCreatedIdeaDescription), "Description does not match");
        }

        [Test, Order(4)]
        public void EditIdeaTitle()
        {
            myIdeasPage.OpenPage();
            myIdeasPage.EditButtonLastIdea.Click();

            string updatedTitle = "Changed Title: " + lastCreatedIdeaTitle;

            ideasEditPage.TitleInput.Clear();
            ideasEditPage.TitleInput.SendKeys(updatedTitle);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL does not match");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaTitle.Text.Trim(), Is.EqualTo(updatedTitle), "Title does not match");
        }

        [Test, Order(5)]
        public void EditIdeaDescription()
        {
            myIdeasPage.OpenPage();
            myIdeasPage.EditButtonLastIdea.Click();

            string updatedDescription = "Changed Description: " + lastCreatedIdeaDescription;

            ideasEditPage.DescriptionInput.Clear();
            ideasEditPage.DescriptionInput.SendKeys(updatedDescription);
            ideasEditPage.EditButton.Click();

            Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url), "URL does not match");

            myIdeasPage.ViewButtonLastIdea.Click();

            Assert.That(ideasReadPage.IdeaDescription.Text.Trim(), Is.EqualTo(updatedDescription), "Description does not match");
        }

        [Test, Order(6)]
        public void DeleteLastIdea()
        {
            myIdeasPage.OpenPage();
            myIdeasPage.DeleteButtonLastIdea.Click();

            bool isIdeaDeleted = myIdeasPage.IdeasCards.All(card => card.Text.Contains(lastCreatedIdeaDescription));

            Assert.IsFalse(isIdeaDeleted, "The idea was not deleted");
        }
    }
}
