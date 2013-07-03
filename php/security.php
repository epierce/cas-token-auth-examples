<?php
class Security {
    public static function encrypt($input, $key) {
        srand((double) microtime() * 1000000); //for MCRYPT_RAND

        $size = mcrypt_get_block_size(MCRYPT_RIJNDAEL_128, MCRYPT_MODE_CBC); 
        $input = Security::pkcs5_pad($input, $size); 

        $td = mcrypt_module_open(MCRYPT_RIJNDAEL_128, '', MCRYPT_MODE_CBC, ''); 
        $iv = mcrypt_create_iv(mcrypt_enc_get_iv_size($td), MCRYPT_RAND); 

        mcrypt_generic_init($td, $key, $iv); 
        $data = mcrypt_generic($td, $input); 
        mcrypt_generic_deinit($td); 
        mcrypt_module_close($td); 

        return base64_encode($iv.$data);
    } 

    private static function pkcs5_pad ($text, $blocksize) { 
        $pad = $blocksize - (strlen($text) % $blocksize); 
        return $text . str_repeat(chr($pad), $pad); 
    } 

    public static function decrypt($sStr, $sKey) {
      $td = mcrypt_module_open(MCRYPT_RIJNDAEL_128, '', MCRYPT_MODE_CBC, '');
  
      $str = base64_decode($sStr);
      $iv_size = mcrypt_enc_get_iv_size($td);
      $iv = substr($str,0,$iv_size);
      $string = substr($str,$iv_size);

      $decrypted= mcrypt_decrypt(
          MCRYPT_RIJNDAEL_128,
          $sKey, 
          $string, 
          MCRYPT_MODE_CBC,
          $iv
      );

     $dec_s = strlen($decrypted); 
     $padding = ord($decrypted[$dec_s-1]); 
     $decrypted = substr($decrypted, 0, -$padding);
     
     return $decrypted;
    }
}
?>