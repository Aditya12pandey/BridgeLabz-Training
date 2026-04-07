using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Tests
{
    internal class FileProcessorMSTests
    {
        private FileProcessor _fileProcessor;
        private string _testFile;

        [TestInitialize]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFile = "testfile.txt";
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }
        }

        [TestMethod]
        public void WriteAndReadFile_ShouldReturnSameContent()
        {
            string content = "Hello MSTest";

            _fileProcessor.WriteToFile(_testFile, content);
            string result = _fileProcessor.ReadFromFile(_testFile);

            Assert.AreEqual(content, result);
        }

        [TestMethod]
        public void WriteToFile_ShouldCreateFile()
        {
            _fileProcessor.WriteToFile(_testFile, "Test");

            Assert.IsTrue(File.Exists(_testFile));
        }

        [TestMethod]
        public void ReadFromFile_FileDoesNotExist_ShouldThrowIOException()
        {
            Assert.Throws<IOException>(() =>
            {
                _fileProcessor.ReadFromFile("missing.txt");
            });
        }
    }
}
