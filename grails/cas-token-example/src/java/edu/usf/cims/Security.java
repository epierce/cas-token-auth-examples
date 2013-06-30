package edu.usf.cims;

/**
 * https://github.com/stevenholder/PHP-Java-AES-Encrypt
 *
 **/

import javax.crypto.*;
import javax.crypto.spec.SecretKeySpec;
import javax.crypto.spec.DESKeySpec;
import javax.crypto.spec.IvParameterSpec;
import java.security.spec.KeySpec;
import java.io.UnsupportedEncodingException;
import org.apache.commons.codec.binary.Base64;


public class Security {

  public static String AESencrypt(String input, String key){
    byte[] crypted = null;
    try{
      SecretKeySpec skey = new SecretKeySpec(key.getBytes(), "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.ENCRYPT_MODE, skey);
        crypted = cipher.doFinal(input.getBytes());
      }catch(Exception e){
          System.out.println(e.toString());
      }
      return new String(Base64.encodeBase64(crypted));
  }

  public static String AESdecrypt(String input, String key){
      byte[] output = null;
      try{
        SecretKeySpec skey = new SecretKeySpec(key.getBytes(), "AES");
        Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
        cipher.init(Cipher.DECRYPT_MODE, skey);
        output = cipher.doFinal(Base64.decodeBase64(input));
      }catch(Exception e){
        System.out.println(e.toString());
      }
      return new String(output);
  } 

}
            
            
            
            
            