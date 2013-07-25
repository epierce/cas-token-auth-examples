using System;
using System.Runtime.Serialization;

namespace DotNet_Token_Auth
{
  /// <summary>
  /// Represents a token to be sent to the remote CAS server.
  /// It uses the DataContract feature from System.Runtime.Serialization
  /// to name the properties in the JSON string.
  /// </summary>
  [DataContract]
  public class Token
  {
    [DataMember(Name="generated")]
    public double Generated { get; private set; }

    [DataMember(Name="credentials")]
    public Credentials Credentials { get; set; }

    public Token(Credentials Credentials)
    {
      this.Credentials = Credentials;

      DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0);
      this.Generated = Math.Floor((DateTime.UtcNow - unixEpoch).TotalMilliseconds);
    }

    public Token() : this(null)
    {
    }
  }
}

