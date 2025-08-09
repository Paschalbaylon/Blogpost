using System;
using Blog.Repositories;

namespace Blog.DependencyInjection;

public static class RepositoryServiceCollection
{
    public static IServiceCollection AddRepositoryServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<BlogPostRepsitory>();
        services.AddScoped<UserRepository>();
        services.AddScoped<UnitOfWork>();
        services.AddScoped<CommentRepository>();
        services.AddScoped<LikeRepository>();

        return services;
    }
}
