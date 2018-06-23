using FluentValidation;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Validates <see cref="UpdateHiveSectionRequest"/> as described below.
    /// </summary>
    public class UpdateHiveSectionRequestValidator : AbstractValidator<UpdateHiveSectionRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateHiveSectionRequestValidator"/> class.
        /// Constructor which checks <see cref="UpdateHiveSectionRequest"/> for being valid.
        /// </summary>
        public UpdateHiveSectionRequestValidator()
        {
            RuleFor(r => r.Name).Length(4, 60);
            RuleFor(r => r.Code).Length(5);
            RuleFor(r => r.Id).GreaterThan(0);
        }
    }
}
