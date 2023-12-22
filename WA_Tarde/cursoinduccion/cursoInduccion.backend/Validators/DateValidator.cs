using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace cursoInduccion.backend.Validators
{
    public class DateValidator : ValidationAttribute
    {
        private const string DEFAULT_MESSAGE = "{0} debe ser {1} a {2}.";
        private DateOnly _value;
        private DateOnly _since;
        private Comparation _compare;

        public enum Comparation
        {
            BEFORE, AFTER, EQUAL
        }

        public DateValidator() : this(DEFAULT_MESSAGE) { }
        public DateValidator(string errorMessage) : this(DateOnly.FromDateTime(DateTime.Now), Comparation.BEFORE, errorMessage) { }
        public DateValidator(Comparation compare) : this(DateOnly.FromDateTime(DateTime.Now), compare, DEFAULT_MESSAGE) { }
        public DateValidator(DateOnly since, string errorMessage) : this(since, Comparation.BEFORE, errorMessage) { }
        public DateValidator(Comparation compare, string errorMessage) : this(DateOnly.FromDateTime(DateTime.Now), compare, errorMessage) { }
        public DateValidator(DateOnly since, Comparation compare, string errorMessage) : base(errorMessage)
        {
            _since = since;
            _compare = compare;
        }
        public override bool IsValid(object? objValue)
        {
            return (objValue as DateOnly? ?? new DateOnly())
                .CompareTo(_since) == CompareValue();
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, CompareString(), _since); ;
        }

        protected override ValidationResult? IsValid(object? objValue,
                                                       ValidationContext validationContext)
        {
            _value = objValue as DateOnly? ?? new DateOnly();
            if (IsValid(_value))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }

        private int CompareValue()
        {
            switch (_compare)
            {
                case Comparation.BEFORE: return 1;
                case Comparation.EQUAL: return 0;
                case Comparation.AFTER: return -1;
                default: return 0;
            }
        }

        private string CompareString()
        {
            switch (_compare)
            {
                case Comparation.BEFORE: return "anterior";
                case Comparation.EQUAL: return "igual";
                case Comparation.AFTER: return "posterior";
                default: return "";
            }
        }
    }
}
