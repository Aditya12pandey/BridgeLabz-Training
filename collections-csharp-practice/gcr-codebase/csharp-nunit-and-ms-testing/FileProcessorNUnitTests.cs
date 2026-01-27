using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests
{
    internal class FileProcessorNUnitTests
    {

        private FileProcessor _fileProcessor;
        private string _testFile;

        [SetUp]
        public void Setup()
        {
            _fileProcessor = new FileProcessor();
            _testFile = "testfile.txt";
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(_testFile))
            {
                File.Delete(_testFile);
            }
        }

        [Test]
        public void WriteAndReadFile_ShouldReturnSameContent()
        {
            string content = "Hello Unit Testing";

            _fileProcessor.WriteToFile(_testFile, content);
            string result = _fileProcessor.ReadFromFile(_testFile);

            Assert.AreEqual(content, result);
        }

        [Test]
        public void WriteToFile_ShouldCreateFile()
        {
            _fileProcessor.WriteToFile(_testFile, "Test");

            Assert.IsTrue(File.Exists(_testFile));
        }

        [Test]
        public void ReadFromFile_FileDoesNotExist_ShouldThrowIOException()
        {
            Assert.Throws<IOException>(() =>
            {
                _fileProcessor.ReadFromFile("missing.txt");
            });
        }
    }
}
