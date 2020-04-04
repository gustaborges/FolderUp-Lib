using FolderizerLib;
using FolderizerLib.Configuration;
using NUnit.Framework;
using System.IO;


namespace FolderizerLibTest.UnitTests
{
    public class ConfigurationOptionsTest
    {

        private ConfigurationOptions configurations;

        [SetUp]
        public void Setup()
        {
            configurations = new ConfigurationOptions();
        }

        #region Set Base Path Tests
        [Test]
        public void SetBasePath_WhenExistentDirectory_BasePathPropertyShouldBeSet()
        {
            configurations.BasePath = TestPaths.ValidBasePath;
            Assert.AreEqual(TestPaths.ValidBasePath, configurations.BasePath);
        }

        [Test]
        public void SetBasePath_WhenNotExistentDirectory_ShouldThrowDirectoryNotFoundException()
        {
            Assert.Throws<DirectoryNotFoundException>(() => configurations.BasePath = "");
        }
        #endregion

        #region Set Output Path Tests
        [Test]
        public void SetmountingPath_WhenNotSet_ShouldBeSameAsBasePath()
        {
            configurations.MountingPath = TestPaths.ValidMountingPath;
            Assert.AreEqual(TestPaths.ValidMountingPath, configurations.MountingPath);
        }

        [Test]
        public void SetmountingPath_WhenExistentDirectory_mountingPathPropertyShouldBeSet()
        {
            configurations.MountingPath = TestPaths.ValidMountingPath;
            Assert.AreEqual(TestPaths.ValidMountingPath, configurations.MountingPath);
        }


        [Test]
        public void SetmountingPath_WhenNotExistentDirectory_mountingPathPropertyShouldBeSet()
        {
            configurations.MountingPath = TestPaths.NotCreatedDirectory;
            Assert.AreEqual(TestPaths.NotCreatedDirectory, configurations.MountingPath);
        }
        #endregion


        #region Set Operation Method Tests
        [Test]
        public void SetOperationMethod_WhenDifferentFromDefaultMethod_OperationMethodPropertyShouldBeSet()
        {
            configurations.OperationMethod = OperationMethod.MoveFiles;
            Assert.AreEqual(OperationMethod.MoveFiles, configurations.OperationMethod);
        }

        [Test]
        public void SetOperationMethod_WhenNotSet_OperationMethodPropertyShouldBeCopy()
        {
            Assert.AreEqual(OperationMethod.CopyFiles, configurations.OperationMethod);
        }

        #endregion

        #region Set Maximum Search Depth Tests
        [Test]
        public void SetMaxSearchDepth_WhenDepthNotSet_DepthShouldBeZero()
        {
            Assert.AreEqual(0, configurations.MaxSearchDepth);
        }

        [Test]
        public void SetMaxSearchDepth_WhenDepthBiggerThanFive_ShouldThrowSearchDepthExceedsAcceptableLimitException()
        {
            Assert.Throws<SearchDepthExceedsAcceptableLimitException>(() => configurations.MaxSearchDepth = 6);
        }

        [Test]
        public void SetMaxSearchDepth_WhenDepthLesserThanOrEqualToFive_SearchDepthPropertyShouldBeSet()
        {
            configurations.MaxSearchDepth = 5;
            Assert.AreEqual(5, configurations.MaxSearchDepth);
        }

        #endregion
    }
}