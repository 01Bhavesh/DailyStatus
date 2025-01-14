namespace UserLoginPage.Models
{
    public class UserContest
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){ Username = "vinay admin" , Password = "6789" , EmailAddress = "vinay@gmail"
                ,Role="Admin" , Surname="Indulkar",GivenName="Vinay"},
            new UserModel(){ Username = "deepak admin" , Password = "1234" , EmailAddress = "deepak@gmail"
                ,Role="buyer" , Surname="Vydande",GivenName="Deepak"},
            new UserModel(){ Username = "mayur admin" , Password = "3456" , EmailAddress = "mayur@gmail"
                ,Role="buyer" , Surname="Patil",GivenName="Mayur"}
        };
    }
}
