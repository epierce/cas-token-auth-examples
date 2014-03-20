create or replace
type body cas_token_details as

  member function to_json(self in cas_token_details) return json as
    output      json := json();
  begin
    output.put('username', self.username);
    output.put('firstname', self.firstname);
    output.put('lastname', self.lastname);
    output.put('email', self.email);

    return output;
  end to_json;

end;