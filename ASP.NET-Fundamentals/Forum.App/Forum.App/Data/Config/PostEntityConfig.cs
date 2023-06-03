namespace Forum.App.Data.Config
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Seeding;

    public class PostEntityConfig : IEntityTypeConfiguration<Post>
    {
        private readonly PostSeeder postSeeder;

        public PostEntityConfig()
        {
            this.postSeeder = new PostSeeder();
        }

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(this.postSeeder.GeneratePost());
        }
    }
}
