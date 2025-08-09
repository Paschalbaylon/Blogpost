using System;
using Blog.Models;
using FluentValidation;

namespace Blog.Validation;

public class BlogPostDtoValidation : AbstractValidator<BlogPost>
{
    public BlogPostDtoValidation()
    {
        //Validate Tittle on Blog
        RuleFor(x => x.Tittle)
        .NotEmpty().WithMessage("It must have a tittle")
        .Length(4, 20).WithMessage("Will not be more than 30 characters");

        //Validate Content on the Blog
        RuleFor(x => x.Content)
        .NotEmpty().WithMessage("You should have a content on your post")
        .MinimumLength(10).WithMessage("Won't be less than 10 characters in your Content");
    }
}
