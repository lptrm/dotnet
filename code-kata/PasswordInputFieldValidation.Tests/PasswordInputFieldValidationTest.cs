namespace PasswordInputFieldValidation.Tests;

public class PasswordInputFieldValidationTest
{
    [Fact]
    public void Given7CharString_whenValidatePassword_thenIsNotValidAndHasErrorMessage()
    {
        //Given
        var validator = new PasswordInputFieldValidation();
        var input = "Pa22wo!";
        //When
        validator = validator.ValidatePassword(input);
        //Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must be at least 8 characters", validator.ErrorMessage);
    }
    [Fact]
    public void Given8CharStringWithoutNumbers_whenValidatePassword_thenIsNotValidAndHasErrorMessage()
    {
        // Given
        var validator = new PasswordInputFieldValidation();
        var input = "Passwor!";
        // When
        validator = validator.ValidatePassword(input);    
        // Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must contain at least 2 numbers", validator.ErrorMessage);
    }
        [Fact]
    public void Given7CharStringWithoutNumbers_whenValidatePassword_thenIsNotValidAndHasErrorMessage()
    {
        // Given
        var validator = new PasswordInputFieldValidation();
        var input = "Passwo!";
        // When
        validator = validator.ValidatePassword(input);    
        // Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must be at least 8 characters\nPassword must contain at least 2 numbers", validator.ErrorMessage);
    }
    [Fact]
        public void Given8CharStringWithoutCaps_whenValidatePassword_thenIsNotValidAndHasErrorMessage()
    {
        // Given
        var validator = new PasswordInputFieldValidation();
        var input = "pa22wor!";
        // When
        validator = validator.ValidatePassword(input);    
        // Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must contain at least one capital letter", validator.ErrorMessage);
    }
    [Fact]
    public void Given8CharStringWithoutSpecialChars_whenValidatePassword_thenIsNotValidAndHasErrorMessage()
    {
        // Given
        var validator = new PasswordInputFieldValidation();
        var input = "Pa22word";
        // When
        validator = validator.ValidatePassword(input);    
        // Then
        Assert.False(validator.IsValid);
        Assert.Equal("Password must contain at least one special character", validator.ErrorMessage);
    }
    [Fact]
    public void Given8CharStringWithSpecialCharsNumbersAndCaps_whenValidatePassword_thenIsValidAndErrorMessageIsEmpty()
    {
        // Given
        var validator = new PasswordInputFieldValidation();
        var input = "Pa22wor!";
        // When
        validator = validator.ValidatePassword(input);    
        // Then
        Assert.True(validator.IsValid);
        Assert.True(string.IsNullOrEmpty(validator.ErrorMessage));
    }
}