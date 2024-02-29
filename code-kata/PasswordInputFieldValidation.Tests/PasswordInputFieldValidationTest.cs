namespace PasswordInputFieldValidation.Tests;

public class PasswordInputFieldValidationTest
{
    [Fact]
    public void Given7CharString_whenValidatePassword_thenThrowsExceptionWithMessage()
    {
        //Given
        var validator = new PasswordInputFieldValidation();
        var input = "Passwor";
        //When
        validator = validator.ValidatePassword(input);
        //Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must be at least 8 characters", validator.ErrorMessage);
    }
}