namespace Token

type Token =
  | NumberToken of float 
  | IdentificationToken of string
  | PlusToken
  | MinusToken
  | MultiplyToken
  | DevideToken
  | LeftParentToken
  | RightParentToken
  | EndOfToken