using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace DotNet_Token_Auth
{
  /// <summary>
  /// A simple helper class to make serializing a Token
  /// to JSON easier.
  /// </summary>
  public class JSON
  {
    public JSON ()
    {
    }

    public static String Stringify(Object obj) {
      MemoryStream ms = new MemoryStream();
      DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(object));

      serializer.WriteObject(ms, obj);

      return Encoding.UTF8.GetString(ms.ToArray());
    }
  }
}

