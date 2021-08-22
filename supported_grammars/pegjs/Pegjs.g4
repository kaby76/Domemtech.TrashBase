
grammar Pegjs;

grammar_ : initializer? rule+ EOF;

initializer : CodeBlock eos ;

eos : ';'
  ;

rule : identifier StringLiteral? '=' expression eos ;

expression : choiceexpression ;

choiceexpression : actionexpression ('/' actionexpression)* ;

actionexpression : sequenceexpression CodeBlock? ;

sequenceexpression : labeledexpression labeledexpression* ;

labeledexpression : labelidentifier? prefixedexpression
  | labelidentifier prefixedexpression
  | prefixedexpression
  ;

labelidentifier : identifier ':' ;

prefixedexpression : prefixedoperator suffixedexpression
  | suffixedexpression
  ;

prefixedoperator : '$'
  | '&'
  | '!'
  ;

suffixedexpression : primaryexpression suffixedoperator
  | primaryexpression
  ;

suffixedoperator : '?'
  | '*'
  | '+'
  ;

primaryexpression : LiteralMatcher
  | CharacterClassMatcher
  | AnyMatcher
  | rulereferenceexpression
  | semanticpredicateexpression
  | '(' expression ')'
  ;

rulereferenceexpression : identifier  /* {! stringliteral? '=' }? */ ;

semanticpredicateexpression : semanticpredicateoperator CodeBlock ;

semanticpredicateoperator : '&' | '!' ;

SourceCharacter : . ;
WhiteSpace : [\t\r\f \u00a0\ufeff] ; // Zs.
LineTerminator : [\n\r\u2028\u2029] ;
LineTerminatorSequence : '\n' | '\r\n' | '\r' | '\u2028' | '\u2029' ;
Comment : MultiLineComment | SingleLineComment ;
MultiLineComment : '/*' .*? '*/' ;
SingleLineComment : '//' SourceCharacter* ;
identifier : identifierstart identifierpart* ;
identifierstart : UnicodeLetter | '$' | '_' | '\\' UnicodeEscapeSequence ;
identifierpart : identifierstart | UnicodeCombiningMark | UnicodeDigit | UnicodeConnectorPunctuation | '\u200c' | '\u200d' ;
UnicodeLetter
    : [\p{Lu}]
    | [\p{Ll}]
    | [\p{Lt}]
    | [\p{Lm}]
    | [\p{Lo}]
    | [\p{Nl}]
    ;

UnicodeCombiningMark
    : [\p{Mn}]
    | [\p{Mc}]
    ;

UnicodeDigit
    : [\p{Nd}]
    ;

UnicodeConnectorPunctuation
    : [\p{Pc}]
    ;

LiteralMatcher : StringLiteral 'i'? ;

StringLiteral : '"' .*? '"'
  | '\'' .*? '\''
  ;

CharacterClassMatcher : '{' CharacterPart* ']' 'i'? ;

CharacterPart : ClassCharacterRange | ClassCharacter ;

ClassCharacterRange : ClassCharacter '-' ClassCharacter ;

ClassCharacter : SourceCharacter | '\\' EscapeSequence | LineContinuation ;

LineContinuation : '\\' LineTerminatorSequence ;

EscapeSequence : CharacterEscapeSequence | '0' | HexEscapeSequence | UnicodeEscapeSequence ;

CharacterEscapeSequence : SingleEscapeCharacter | NonEscapeCharacter ;

SingleEscapeCharacter : '\'' | '"' | '\\' | 'b' | 'f' | 'n' | 'r' | 't' | 'v' ;

NonEscapeCharacter : SourceCharacter ;

EscapeCharacter : SingleEscapeCharacter | DecimalDigit | 'x' | 'u' ;

HexEscapeSequence : 'x' HexDigit HexDigit ;

UnicodeEscapeSequence : 'u' HexDigit HexDigit HexDigit HexDigit ;

DecimalDigit : [0-9] ;

HexDigit : [0-9a-fA-F] ;

AnyMatcher : '.' ;

CodeBlock : '{' .*? '}' ;
