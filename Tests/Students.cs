using OpenQA.Selenium;

namespace RStudents.Tests
{
    [TestFixture]
    public class Students : WebDriverSetup
    {
        string studentsListTitleId = "students-list-title";
        string newStudentButtonId = "new-student-button";
        string studentsTableId = "students-table";
        string createStudentFirstNameId = "first-name";
        string createStudentLastNameId = "last-name";
        string createStudentAgeId = "age";
        string createStudentSubmitButtonId = "submit-button";
        string deleteStudentButtonCSSSelector = "a[id^='delete-student-']";

        [Test]
        public void StudentsListTitle()
        {
            navigationHelper.GoToStudentsPage();
            Assert.That(assertsHelper.IsElementDisplayed(studentsListTitleId), Is.True, $"{studentsListTitleId} is displayed.");
        }

        [Test]
        public void NewStudentButton()
        {
            navigationHelper.GoToStudentsPage();
            Assert.That(assertsHelper.IsElementDisplayed(newStudentButtonId), Is.True, $"{newStudentButtonId} is displayed.");
        }

        [Test]
        public void StudentsTable()
        {
            navigationHelper.GoToStudentsPage();
            Assert.That(assertsHelper.IsElementDisplayed(studentsTableId), Is.True, $"{studentsTableId} is displayed.");
        }

        [Test]
        public void StudentAddDelete()
        {
            string firstName = "imie";
            string lastName = "nazwisko";
            string age = "20";

            navigationHelper.GoToCreateStudentPage();
            assertsHelper.SendKeys(createStudentFirstNameId, firstName);
            assertsHelper.SendKeys(createStudentLastNameId, lastName);
            assertsHelper.SendKeys(createStudentAgeId, age);
            assertsHelper.Click(createStudentSubmitButtonId, SelectorType.Id);

            Assert.That(() => assertsHelper.AreTextsDisplayedUnderElement(studentsTableId, new List<string>() { firstName, lastName, age }), Is.True.After(10).Seconds.PollEvery(1), $"Student is added.");

            ReLocateDeleteButtonAndClick(firstName, lastName);

            assertsHelper.WaitForAlert();
            assertsHelper.AcceptAlert();
            Assert.That(() => assertsHelper.AreTextsUndisplayedUnderElement(studentsTableId, new List<string>() { firstName, lastName, age }), Is.True.After(10).Seconds.PollEvery(1), $"Student is deleted.");
        }

        private void ReLocateDeleteButtonAndClick(string firstName, string lastName)
        {
            var rows = driver.FindElements(By.CssSelector("#students-table tbody tr"));
            foreach (var row in rows)
            {
                if (row.Text.Contains(firstName) && row.Text.Contains(lastName))
                {
                    var deleteButton = row.FindElement(By.CssSelector(deleteStudentButtonCSSSelector));
                    deleteButton.Click();
                    break;
                }
            }
        }

    }
}
