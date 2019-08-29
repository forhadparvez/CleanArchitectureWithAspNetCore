using FluentValidation;

namespace App.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
