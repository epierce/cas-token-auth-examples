using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace DotNet_Token_Auth
{
	class MainClass
	{
    /// <summary>
    /// An example program to send a token authentication request. Lines
    /// that start with three slashes (///) are comments for a line(s)
    /// of code that you should configure for your testing. Other comments
    /// are merely present for clarity.
    /// </summary>
    /// <param name="args">None.</param>
		public static void Main(string[] args)
		{
      /// Set to the base URL of your CAS server.
      string casUrl = "https://cas.example.com";
      /// Set to the path of the login page for your CAS server.
      string casLoginUrl = "/login";
      /// Set to the name of the key you will be sending.
      string tokenServiceName = "my_key";
      /// Set to the value of the key you will using for encryption.
      string tokenEncryptionKey = "R1XUS8YM2U7IDBCN";

      /// Configure the following Credentials object to a user that
      /// you want to be logged in.
      Credentials credentials = new Credentials();
      credentials.Username = "jblow";
      credentials.FirstName = "Joe";
      credentials.LastName = "Blow";
      credentials.Email = "joe.blow@example.com";

      // Create the token and encrypt it.
      Token token = new Token(credentials);
      String b64String = Encryptor.Encrypt(JSON.Stringify(token), tokenEncryptionKey);

      // Now we need to construct our web request parameters in order
      // to communicate with the remote CAS server.
      WebClient webClient = new WebClient();
      webClient.BaseAddress = casUrl;
      webClient.QueryString.Set("token_service", tokenServiceName);
      webClient.QueryString.Set("auth_token", b64String);
      webClient.QueryString.Set("username", credentials.Username);

      // Write the result of the web request to the console.
      byte[] data = webClient.DownloadData(casLoginUrl);
      Console.WriteLine("--- WebClient Result ---");
      Console.WriteLine(Encoding.ASCII.GetString(data));
		}
	}
}
