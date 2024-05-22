using System.IO.Abstractions;
using AutoMapper;
using Collibri.Data;
using Collibri.Dtos;
using Microsoft.AspNetCore.Mvc;
using FileInfo = Collibri.Models.FileInfo;

namespace Collibri.Repositories.DbImplementation
{
	public class DbFileRepository : IFileRepository
	{
		private readonly IFileSystem _fileSystem;
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public DbFileRepository(DataContext dataContext, IMapper mapper, IFileSystem fileSystem)
		{
			_context = dataContext;
			_mapper = mapper;
			_fileSystem = fileSystem;
		}

		public FileInfoDTO? CreateFile(IFormFile file, string postId)
		{
			var path = _fileSystem.DirectoryInfo.New(
				_fileSystem.Path.Combine(
					_fileSystem.Directory.GetParent(Directory.GetCurrentDirectory()).FullName,
					"Collibri", "Data", "Files", postId)).FullName;
			var separator = _fileSystem.Path.DirectorySeparatorChar;

			if (!_fileSystem.Directory.Exists(path))
			{
				_fileSystem.Directory.CreateDirectory(path);
			}

			var id = Guid.NewGuid();
			var filePath = path + separator + id + _fileSystem.Path.GetExtension(file.FileName);

			if (_fileSystem.File.Exists(filePath))
			{
				return null;
			}

			var createdFileInfo = new FileInfoDTO(id, Guid.Parse(postId), filePath, file.FileName, file.ContentType,
				file.Length);
			_context.FileInfos.Add(_mapper.Map<FileInfo>(createdFileInfo));
			_context.SaveChanges();
			using (var fileStream = _fileSystem.File.Create(filePath))
			{
				file.CopyTo(fileStream);
			}

			return (FileInfoDTO?) createdFileInfo;
		}

		public FileInfoDTO? DeleteFile(string id)
		{
			var fileToDelete = _context.FileInfos.SingleOrDefault(i => i.Id == Guid.Parse(id));

			if (fileToDelete == null || !_fileSystem.File.Exists(fileToDelete.Path))
			{
				return null;
			}

			_fileSystem.File.Delete(fileToDelete.Path);
			_context.FileInfos.Remove(fileToDelete);
			_context.SaveChanges();

			return (FileInfoDTO?) _mapper.Map<FileInfoDTO>(fileToDelete);
		}

		public IEnumerable<FileInfoDTO> GetAllFiles(string postId)
		{
			return _mapper.Map<List<FileInfoDTO>>(_context.FileInfos.ToList().Where(x => x.PostId == Guid.Parse(postId)))
				.AsEnumerable();
		}

		public FileStreamResult? GetFile(string id)
		{
			var fileToGet = _context.FileInfos.SingleOrDefault(i => i.Id == Guid.Parse(id));

			if (fileToGet == null || !_fileSystem.File.Exists(fileToGet.Path))
			{
				return null;
			}
			
			var fileStream = _fileSystem.FileStream.New(fileToGet.Path, FileMode.Open, FileAccess.Read);
			return new FileStreamResult(fileStream, fileToGet.ContentType);
		}

		public FileInfoDTO? UpdateFileName(string id, string updatedName)
		{
			var fileToUpdate = _context.FileInfos.SingleOrDefault(i => i.Id == Guid.Parse(id));

			if (fileToUpdate == null)
			{
				return null;
			}
			fileToUpdate.Name = updatedName;
			var oldPath = fileToUpdate.Path;
			fileToUpdate.Path = oldPath[..oldPath.LastIndexOf(_fileSystem.Path.DirectorySeparatorChar)]
			                    + _fileSystem.Path.DirectorySeparatorChar + updatedName;
			_fileSystem.File.Move(oldPath, fileToUpdate.Path);
			_context.FileInfos.Update(fileToUpdate);
			_context.SaveChanges();

			return _mapper.Map<FileInfoDTO>(fileToUpdate);
		}
	}
}