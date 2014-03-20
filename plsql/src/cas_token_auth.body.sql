create or replace
package body cas_token_auth as

  function encrypt_token(in_token in json) return varchar2 as
    iv_bytes        raw(16);
    key_bytes       raw(16);
    token_bytes     raw(32767);
    data_bytes      blob;
    encrypted_bytes blob;
    b64raw_bytes    raw(32767);
    output          raw(32767);
  begin
    iv_bytes := dbms_crypto.randombytes(16);
    key_bytes := utl_raw.cast_to_raw(token_key);
    token_bytes := utl_raw.cast_to_raw(in_token.to_char());

    dbms_lob.createtemporary(data_bytes, false);
    dbms_lob.write(data_bytes, 16, 1, iv_bytes);
    dbms_lob.write(data_bytes, utl_raw.length(token_bytes), 17, token_bytes);

    dbms_lob.createtemporary(encrypted_bytes, false);
    encrypted_bytes := dbms_crypto.encrypt(
      src => data_bytes,
      key => key_bytes,
      iv => iv_bytes,
      typ => dbms_crypto.encrypt_aes128 + dbms_crypto.chain_cbc + dbms_crypto.pad_pkcs5
    );

    b64raw_bytes := dbms_lob.substr(encrypted_bytes);
    output := utl_encode.base64_encode(encrypted_bytes);

    dbms_lob.freetemporary(encrypted_bytes);
    dbms_lob.freetemporary(data_bytes);

    return utl_raw.cast_to_varchar2(output);
  end encrypt_token;

  function get_token(in_details in cas_token_details) return json as
    token json := json();
  begin
    token.put('generated', unix_time() * 1000);
    token.put('credentials', in_details.to_json().to_json_value());
    return token;
  end get_token;

  function get_url(in_token in json, in_username in varchar2, in_service_url in varchar2) return varchar2 as
    out_url varchar2(2083);
  begin
    out_url := cas_base_url || cas_login_url || '?service=' || utl_url.escape(in_service_url, true) ||
      '&username=' || in_username || '&token_service=' || utl_url.escape(token_key_name, true) ||
      '&auth_token=' || utl_url.escape(encrypt_token(in_token), true);

    return out_url;
  end get_url;

end cas_token_auth;