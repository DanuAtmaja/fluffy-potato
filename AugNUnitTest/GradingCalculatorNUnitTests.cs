using NUnit.Framework;

namespace Aug
{
    [TestFixture]
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator _gradingCalculator;

        [SetUp]
        public void Setup()
        {
            _gradingCalculator = new GradingCalculator();
        }

        [Test]
        public void GradeCalc_InputScore95Attendance90_GetAGrede()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 90;
            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("A"));
        }
        
        [Test]
        public void GradeCalc_InputScore85Attendance90_GetBGrede()
        {
            _gradingCalculator.Score = 85;
            _gradingCalculator.AttendancePercentage = 90;
            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }
        
        [Test]
        public void GradeCalc_InputScore65Attendance90_GetCGrede()
        {
            _gradingCalculator.Score = 65;
            _gradingCalculator.AttendancePercentage = 90;
            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("C"));
        }
        
        [Test]
        public void GradeCalc_InputScore95Attendance65_GetBGrede()
        {
            _gradingCalculator.Score = 95;
            _gradingCalculator.AttendancePercentage = 65;
            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("B"));
        }
        
        
        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GradeCalc_FailureScenarios_GetFGrede(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            string result = _gradingCalculator.GetGrade();
            Assert.That(result, Is.EqualTo("F"));
        }
        
        
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GradeCalc_AllGradeLogicalScenarios_GradeOutput(int score, int attendance)
        {
            _gradingCalculator.Score = score;
            _gradingCalculator.AttendancePercentage = attendance;
            return _gradingCalculator.GetGrade();
        }
    }
}