using System;
using System.Collections.Generic;
using Facebook;

namespace LifeMap.Facebook.Samples.Facebook
{
    public static class GraphApiSamples
    {
        public static void RunSamples(string accessToken)
        {
            //GetSampleWithoutAccessToken();
            GetSampleWithAccessToken(accessToken);

            //var postId = PostToMyWall(accessToken, "message posted from Facebook C# SDK sample using graph api");

            //Console.WriteLine();
            //Console.WriteLine("Goto www.facebook.com and check if the message was posted in the wall. Then press any key to continue");
            //Console.ReadKey();

            //Delete(accessToken, postId);

            //Console.WriteLine();
            //Console.WriteLine("Goto www.facebook.com and check if the message was deleted in the wall. Then press any key to continue");
            //Console.ReadKey();
        }

        public static void GetSampleWithoutAccessToken()
        {
            try
            {
                var fb = new FacebookClient();

                var result = (IDictionary<string, object>)fb.Get("/4");

                var id = (string)result["id"];
                var name = (string)result["name"];
                var firstName = (string)result["first_name"];
                var lastName = (string)result["last_name"];

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("First Name: {0}", firstName);
                Console.WriteLine("Last Name: {0}", lastName);
                Console.WriteLine();

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }
        }

		public static void GetSampleWithAccessToken(string accessToken)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Get("/me");

                var id = (string)result["id"];
                var name = (string)result["name"];
                var firstName = (string)result["first_name"];
                var lastName = (string)result["last_name"];

                Console.WriteLine("Id: {0}", id);
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("First Name: {0}", firstName);
                Console.WriteLine("Last Name: {0}", lastName);
                Console.WriteLine();

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }
        }

		public static string PostToMyWall(string accessToken, string message)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post("/me/feed", new Dictionary<string, object>
                                                                                   {
                                                                                       { "message", message }
                                                                                   });
                var postId = (string)result["id"];

                Console.WriteLine("Post Id: {0}", postId);

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());

				return postId;
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }

			return null;
        }

		public static void Delete(string accessToken, string id)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var result = fb.Delete(id);

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }
        }

		public static string UploadPictureToWall(string accessToken, string filePath)
        {
            // sample usage: UploadPictureToWall(accessToken, @"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg");

            var mediaObject = new FacebookMediaObject
                                  {
                                      FileName = System.IO.Path.GetFileName(filePath),
                                      ContentType = "image/jpeg"
                                  };

            mediaObject.SetValue(System.IO.File.ReadAllBytes(filePath));

            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post("me/photos", new Dictionary<string, object>
                                       {
                                           { "source", mediaObject },
                                           { "message","photo" }
                                       });

                var postId = (string)result["id"];

                Console.WriteLine("Post Id: {0}", postId);

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());

                return postId;
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }
        }

		public static string GetPageAccessToken(string accessToken, string pageId)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var parameters = new Dictionary<string, object>();

                // Note that the access_token field is a non-default field and
                // must be requested explicitly via the fields URL parameter.
                // In addition, you must use a user access_token with the 
                // manage_pages permission to make this request, 
                // where the user is an administrator of the Page. 
                parameters["fields"] = "access_token";
                var result = (IDictionary<string, object>)fb.Get(pageId, parameters);

                var pageAccessToken = (string)result["access_token"];

                Console.WriteLine("Access Token: {0}", accessToken);
                Console.WriteLine();

                // Note: This json result is not the original json string as returned by Facebook.
                Console.WriteLine("Json: {0}", result.ToString());

                return pageAccessToken;
            }
            catch (FacebookApiException ex)
            {
                // Note: make sure to handle this exception.
                throw;
            }
        }
    }
}