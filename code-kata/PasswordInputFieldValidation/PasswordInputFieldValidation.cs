using System.Text;
using System.Text.RegularExpressions;

namespace PasswordInputFieldValidation;

public partial class PasswordInputFieldValidation
{
    public bool IsValid { get; private set; }
    public string ErrorMessage { get; private set; }
    public PasswordInputFieldValidation()
    {
        IsValid = true;
        ErrorMessage = "";
    }
    public PasswordInputFieldValidation ValidatePassword(string input)
    {
        var errorMessageBuilder = new StringBuilder();
        if (input.Length < 8)
        {
            Invalidate("Password must be at least 8 characters", errorMessageBuilder);
        }
        if (NumberRegex().Count(input) < 2)
        {
            Invalidate("Password must contain at least 2 numbers", errorMessageBuilder);
        }
        if (CapsRegex().Count(input) < 1)
        {
            Invalidate("Password must contain at least one capital letter", errorMessageBuilder);
        }
        if (SpecialCharsRegex().Count(input) < 1)
        {
            Invalidate("Password must contain at least one special character", errorMessageBuilder);
        }
        ErrorMessage = errorMessageBuilder.ToString();
        return this;
    }
    private void Invalidate(string message, StringBuilder errorMessageBuilder)
    {
        if (IsValid) { IsValid = false; }
        if (errorMessageBuilder.Length > 0) { errorMessageBuilder.AppendLine(); }
        errorMessageBuilder.Append(message);
    }
    [GeneratedRegex(@"\d")]
    private static partial Regex NumberRegex();
    [GeneratedRegex("[A-Z]")]
    private static partial Regex CapsRegex();
    [GeneratedRegex(@"[!@#$%^&*()_+\-=\[\]{};':\\|,.<>\/?]")]
    private static partial Regex SpecialCharsRegex();
}
