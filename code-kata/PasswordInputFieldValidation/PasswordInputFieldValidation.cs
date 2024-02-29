using Microsoft.VisualBasic;

namespace PasswordInputFieldValidation;

public class PasswordInputFieldValidation
{   
    public bool IsValid {get; private set;}
    public string ErrorMessage {get; private set;}
    public PasswordInputFieldValidation(){
        IsValid = false;
        ErrorMessage = "";
    }
    public PasswordInputFieldValidation ValidatePassword(string input){
        IsValid = true;
        if (input.Length < 8){
            IsValid = false;
            ErrorMessage = "Password must be at least 8 characters";
        }
        return this;
    }
}
