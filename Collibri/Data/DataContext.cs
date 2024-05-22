using Collibri.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FileInfo = Collibri.Models.FileInfo;

namespace Collibri.Data
{
	public class DataContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
	{
		public virtual DbSet<Document> Documents { get; set; }
		public virtual DbSet<Note> Notes { get; set; }
		public virtual DbSet<Post> Posts { get; set; }
		public virtual DbSet<Room> Rooms { get; set; }
		public virtual DbSet<Section> Sections { get; set; }
		public virtual DbSet<RoomMember> RoomMembers { get; set; }
		public virtual DbSet<Tag> Tags { get; set; }
		public virtual DbSet<PostTags> PostTags { get; set; }
		public virtual DbSet<FileInfo> FileInfos { get; set; }

		public DataContext()
		{
			
		}
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
	
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<PostTags>()
				.HasKey(pt => new { pt.TagId, pt.PostId });
			builder.Entity<PostTags>()
				.HasOne(pt => pt.Post)
				.WithMany(post => post.PostTags)
				.HasForeignKey(pt => pt.PostId);
			builder.Entity<PostTags>()
				.HasOne(pt => pt.Tag)
				.WithMany(tag => tag.PostTags)
				.HasForeignKey(pt => pt.TagId);
			
			builder.HasPostgresExtension("uuid-ossp");
		}
	}
}