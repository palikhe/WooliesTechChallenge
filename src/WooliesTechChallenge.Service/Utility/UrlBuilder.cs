using System;
using System.Web;

namespace WooliesTechChallenge.Service.Utility
{
    public static class UrlBuilder
    {

        public static Uri CombineUrl(string url1, string url2)
        {
            url1 = url1.TrimEnd('/');
            url2 = url2.TrimStart('/');

            return new Uri($"{url1}/{url2}");
        }

        public static Uri AddQueryString(this Uri uri, string key, string value)
        {
            var uriBuilder = new UriBuilder(uri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[key] = HttpUtility.UrlEncode(value);
            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri;
        }

    }
}
