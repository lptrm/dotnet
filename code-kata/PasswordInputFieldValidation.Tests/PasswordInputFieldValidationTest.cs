namespace PasswordInputFieldValidation.Tests;

public class PasswordInputFieldValidationTest
{
    [Fact]
    public void Given7CharString_whenValidatePassword_thenThrowsExceptionWithMessage()
    {
        //Given
        var input = "Passwor";
        //When Then
        var ex = Assert.Throws<FormatException> (() => PasswordInputFieldValidation.ValidatePassword(input));
        Assert.Equal("Password must be at least 8 characters", ex.Message);
    }
}