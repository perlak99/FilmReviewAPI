using FilmReviewAPI.DTOs.Comment;
using System.ComponentModel.DataAnnotations;

namespace FilmReviewAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommentValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var comment = value as AddCommentDto;

            if (comment == null)
            {
                throw new Exception("Can't cast value to AddCommentDto");
            }

            if (comment.DirectorId == null && comment.FilmId == null)
            {
                throw new ArgumentException("Either FilmId or DirectorId must be provided.");
            }

            if (comment.DirectorId != null && comment.FilmId != null)
            {
                throw new ArgumentException("Comment can't have both FilmId and DirectorId.");
            }
            

            return ValidationResult.Success;
        }
    }
}
