using System.IO.Abstractions.TestingHelpers;
using Collibri.Repositories.FileBasedImplementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = Collibri.Models.File;

namespace Collibri.Tests.Repositories.Files
{
    public class FileRepositoryTests
    {
        [Theory]
        [ClassData(typeof(CreateFileData))]
        public void CreateFile_Should_ReturnFileTest(MockFileSystem fileSystem, IFormFile fileData,
            string postId, File? expected)
        {
            // Arrange
            var fileRepository = new FileRepository(fileSystem.FileSystem);

            // Act
            var actual = fileRepository.CreateFile(fileData, postId);
            
            // Assert
            if(expected == null)
                Assert.Null(actual);
            else
            {
                Assert.Equivalent(expected, actual);
                Assert.True(fileSystem.File.Exists(expected.Path));
            }
        }

        [Theory]
        [ClassData(typeof(DeleteFileData))]
        public void DeleteFile_Should_ReturnFileTest(MockFileSystem fileSystem, string fileName,
            string postId, File? expected)
        {
            // Arrange
            var fileRepository = new FileRepository(fileSystem.FileSystem);
            
            // Act
            var actual = fileRepository.DeleteFile(fileName, postId);
            
            // Assert
            if(expected == null)
                Assert.Null(actual);
            else
            {
                Assert.Equivalent(expected, actual);
                Assert.True(!fileSystem.FileExists(expected.Path));
            }
        }

        [Theory]
        [ClassData(typeof(GetFileData))]
        public void GetFile_Should_ReturnFileStreamResultTest(MockFileSystem fileSystem, string fileName,
            string postId, FileStreamResult? expected)
        {
            // Arrange
            var fileRepository = new FileRepository(fileSystem.FileSystem);
            
            // Act
            var actual = fileRepository.GetFile(fileName, postId);
            
            // Assert
            if(expected == null)
                Assert.Null(actual);
            else
            {
                Assert.True(FileTestHelper.StreamEquals(expected.FileStream, actual.FileStream));
            }
        }

        [Theory]
        [ClassData(typeof(UpdateFileNameData))]
        public void UpdateFileName_Should_ReturnFileTest(MockFileSystem fileSystem, string fileName, string postId,
            string updatedName, File? expected)
        {
            // Arrange
            var path = FileTestHelper.GetPath(postId);
            var fileRepository = new FileRepository(fileSystem.FileSystem);
            
            // Act
            var actual = fileRepository.UpdateFileName(fileName, postId, updatedName);
            
            // Assert
            if(expected == null)
                Assert.Null(actual);
            else
            {
                Assert.Equivalent(expected, actual);
                Assert.True(!fileSystem.FileExists(path + fileName));
                Assert.True(fileSystem.FileExists(expected.Path));
            }
        }
    }
}