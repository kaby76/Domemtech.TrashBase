grammar Princeton;

prods : prod+ EOF ;
prod : (lhs SymSep rhs)? RuleSep ;
lhs : symbol ;
rhs : atom* ;
atom : symbol | String | OP atom* CP ;
symbol : Symbol ;

SymSep : '::=' ;
RuleSep : FRet ;
OP : '(' ;
CP : ')' ;
COMMENT : '#' ~[\n\r]*? -> channel(HIDDEN) ;
String : '"' .*? '"' | '\'' .*? '\'' ;
Symbol : FSymbol ;
WS : FWs -> channel(HIDDEN) ;
fragment FSymbol : [a-zA-Z0-9_.\-] [a-zA-Z0-9_.\-']* ;
fragment FWs : [ \t]+ ;
fragment FRet : [\n\r]+ ;