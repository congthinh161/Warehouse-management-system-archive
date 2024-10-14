namespace WHM.Data.Dtos.Responses
{
    public class UserLoginResponseDto
    {
        public string AccessToken { get; set; }

        public UserLoginResponseDto(string accessToken)
        {
            AccessToken = accessToken;
        }
    }
}
