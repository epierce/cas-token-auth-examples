create or replace type cas_token_details as object
(
  username    varchar2(128),
  firstname   varchar2(128),
  lastname    varchar2(128),
  email       varchar2(128),
  member function to_json(self in cas_token_details) return json
)