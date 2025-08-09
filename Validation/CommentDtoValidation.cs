using System;
using Blog.Models;
using FluentValidation;

namespace Blog.Validation;

public class CommentDtoValidation : AbstractValidator<BlogPost>
{
    public CommentDtoValidation()
    {
        //Validate Content
        RuleFor(x => x.Content)
        .NotEmpty().WithMessage("You should have a content on your post")
        .WithMessage("Make a comment");
    }
}
