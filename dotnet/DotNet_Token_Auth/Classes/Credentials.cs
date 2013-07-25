using System;
using System.Runtime.Serialization;

namespace DotNet_Token_Auth
{
  /// <summary>
  /// Represents the credentials portion of an authentication
  /// token.
  /// </summary>
  [DataContract]
  public class Credentials
  {
    [DataMember(Name="username")]
    public string Username { get; set; }

    [DataMember(Name="firstname")]
    public string FirstName { get; set; }

    [DataMember(Name="lastname")]
    public string LastName { get; set; }

    [DataMember(Name="email")]
    public string Email { get; set; }

    public Credentials ()
    {
    }
  }
}

