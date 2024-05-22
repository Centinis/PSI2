using Collibri.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Collibri.Repositories
{
    public interface IFileRepository
    {
        FileInfoDTO? CreateFile(IFormFile file, string postId);
        FileInfoDTO? DeleteFile(string id);
        IEnumerable<FileInfoDTO>? GetAllFiles(string postId);
        FileStreamResult? GetFile(string id);
        FileInfoDTO? UpdateFileName(string fileName, string updatedName);
    }
}