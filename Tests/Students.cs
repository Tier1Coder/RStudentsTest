namespace RStudents.Tests
{
    [TestFixture]
    public class Students : WebDriverSetup
    {
        string studentsListTitleId = "students-list-title";
        string newStudentButtonId = "new-student-button";
        string studentsTableId = "students-table";
        string student1Id = "student-1";

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
        public void studentsTable()
        {
            navigationHelper.GoToStudentsPage();
            Assert.That(assertsHelper.IsElementDisplayed(studentsTableId), Is.True, $"{studentsTableId} is displayed.");
        }

        //[Test]
        //public void student()
        //{
        // further tests, e.g. create group and add student into
        //navigationHelper.GoToStudentsPage();
        //Assert.That(assertsHelper.IsElementDisplayed(student1Id), Is.True, $"{student1Id} is displayed.");
        //}

    }
}
