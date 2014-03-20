# PL/SQL Example #

This is an example showing how to write a PL/SQL module that can create a valid
authentication token. The example is fully functional, and is actually being
used in production.

## Requirements ##

1. Oracle 11gR2 (At least, that's what I developed it on. 10g might work.)
2. The `unix_time` function from
[http://jrfom.com/2012/02/10/oracle-and-unix-timestamps-revisited/](http://jrfom.com/2012/02/10/oracle-and-unix-timestamps-revisited/)
1. The PL/JSON library installed --
[http://sourceforge.net/projects/pljson/](http://sourceforge.net/projects/pljson/)
or
[https://github.com/jsumners/pljson](https://github.com/jsumners/pljson)

## Example Usage ##

~~~sql
declare
  token   json;
  details cas_token_details;

  encrypted_token varchar2(32767);
  dst_url varchar2(2083);
begin
  details := cas_token_details('foobar', 'Foo', 'Bar', 'foobar@example.com');

  token := cas_token_auth.get_token(details);
  token.print();

  encrypted_token := cas_token_auth.encrypt_token(token);
  dbms_output.put_line(encrypted_token);

  dst_url := cas_token_auth.get_url(token, 'foobar', 'https://login.example.com/?auth');
  dbms_output.put_line(dst_url);
end;
/
~~~

## License ##

THE MIT LICENSE (MIT)
Copyright © 2014 James Sumners <james.sumners@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.