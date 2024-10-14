namespace Whm.Infrastructure.Constants
{
    public static class CommonRouter
    {
        private const string BaseUrl = "~/api/v1";
        public const string CommonLogin = $"{BaseUrl}/common/login";
        public const string CommonLogout = $"{BaseUrl}/common/logout";
        public const string CommonRegister = $"{BaseUrl}/common/register";
        public const string CommonRefreshToken = $"{BaseUrl}/common/refresh-token";
        public const string CommonProfile = $"{BaseUrl}/common/profile";
    }

    public static class PublicRouter
    {
        private const string BaseUrl = "~/api/v1";
        public const string PlayBackVideo_1 = $"{BaseUrl}/playback/{{filmId}}/{{subFolder}}/{{fileName}}";
        public const string PlayBackVideo_2 = $"{BaseUrl}/playback/{{filmId}}/{{fileName}}";
        public const string LoadFilmSubtitle = $"{BaseUrl}/film/get-sub/{{filmId}}/{{subId}}";
        public const string SearchFilm = $"{BaseUrl}/film/search";
    }

    public static class AdminRouter
    {
        private const string BaseUrl = "~/api/v1";
        public const string UploadVideo = $"{BaseUrl}/admin/upload-video";

        public const string UpdateFilmInfo = $"{BaseUrl}/admin/update-film";
        public const string AddFilmInfo = $"{BaseUrl}/admin/add-film";

        public const string DeleteFilmInfo = $"{BaseUrl}/admin/delete-film";
        public const string AddActorInfo = $"{BaseUrl}/admin/add-actor";
    }
}
