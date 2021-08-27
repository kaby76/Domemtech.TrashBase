grammar xtext ;
start : ( 'grammar' ( ( grammarID ) ) ( 'with' ( ( grammarID ) ) ( ',' ( ( grammarID ) ) ) * ) ? ( ( ( 'hidden' ) ) '(' ( ( ( ruleID ) ) ( ',' ( ( ruleID ) ) ) * ) ? ')' ) ? ( ( abstractMetamodelDeclaration ) ) * ( ( abstractRule ) ) + ) EOF ;
grammarID : ( validID ( '.' validID ) * ) ;
abstractRule : ( parserRule_ | terminalRule | enumRule ) ;
abstractMetamodelDeclaration : ( generatedMetamodel | referencedMetamodel ) ;
generatedMetamodel : ( 'generate' ( ( validID ) ) ( ( RULE_STRING ) ) ( 'as' ( ( validID ) ) ) ? ) ;
referencedMetamodel : ( 'import' ( ( RULE_STRING ) ) ( 'as' ( ( validID ) ) ) ? ) ;
annotation : ( '@' ( ( RULE_ID ) ) ) ;
parserRule_ : ( ( ( annotation ) ) * ( ( ( ( 'fragment' ) ) ruleNameAndParams ( ( ( '*' ) ) | ( 'returns' ( ( typeRef ) ) ) ? ) ) | ( ruleNameAndParams ( 'returns' ( ( typeRef ) ) ) ? ) ) ( ( ( 'hidden' ) ) '(' ( ( ( ruleID ) ) ( ',' ( ( ruleID ) ) ) * ) ? ')' ) ? ':' ( ( alternatives ) ) ';' ) ;
ruleNameAndParams : ( ( ( validID ) ) ( '<' ( ( ( parameter ) ) ( ',' ( ( parameter ) ) ) * ) ? '>' ) ? ) ;
parameter : ( ( RULE_ID ) ) ;
typeRef : ( ( ( ( RULE_ID ) ) '::' ) ? ( ( RULE_ID ) ) ) ;
alternatives : ( conditionalBranch ( ( ) ( '|' ( ( conditionalBranch ) ) ) + ) ? ) ;
conditionalBranch : ( unorderedGroup | ( ( ) '<' ( ( disjunction ) ) '>' ( ( abstractToken ) ) + ) ) ;
unorderedGroup : ( group ( ( ) ( '&' ( ( group ) ) ) + ) ? ) ;
group : ( abstractToken ( ( ) ( ( abstractToken ) ) + ) ? ) ;
abstractToken : ( abstractTokenWithCardinality | action ) ;
abstractTokenWithCardinality : ( ( assignment | abstractTerminal ) ( ( ( '?' | '*' | '+' ) ) ) ? ) ;
action : ( '{' ( ( typeRef ) ) ( '.' ( ( validID ) ) ( ( ( '=' | '+=' ) ) ) 'current' ) ? '}' ) ;
abstractTerminal : ( keyword | ruleCall | parenthesizedElement | predicatedKeyword | predicatedRuleCall | predicatedGroup ) ;
keyword : ( ( RULE_STRING ) ) ;
ruleCall : ( ( ( ruleID ) ) ( '<' ( ( namedArgument ) ) ( ',' ( ( namedArgument ) ) ) * '>' ) ? ) ;
namedArgument : ( ( ( ( RULE_ID ) ) ( ( '=' ) ) ) ? ( ( disjunction ) ) ) ;
literalCondition : ( ( ) ( ( ( 'true' ) ) | 'false' ) ) ;
disjunction : ( conjunction ( ( ) '|' ( ( conjunction ) ) ) * ) ;
conjunction : ( negation ( ( ) '&' ( ( negation ) ) ) * ) ;
negation : ( atom | ( ( ) '!' ( ( negation ) ) ) ) ;
atom : ( parameterReference | parenthesizedCondition | literalCondition ) ;
parenthesizedCondition : ( '(' disjunction ')' ) ;
parameterReference : ( ( RULE_ID ) ) ;
terminalRuleCall : ( ( ruleID ) ) ;
ruleID : ( validID ( '::' validID ) * ) ;
validID : ( RULE_ID | 'true' | 'false' ) ;
predicatedKeyword : ( ( ( ( '=>' ) ) | ( ( '->' ) ) ) ( ( RULE_STRING ) ) ) ;
predicatedRuleCall : ( ( ( ( '=>' ) ) | ( ( '->' ) ) ) ( ( ruleID ) ) ( '<' ( ( namedArgument ) ) ( ',' ( ( namedArgument ) ) ) * '>' ) ? ) ;
assignment : ( ( ( ( '=>' ) ) | ( ( '->' ) ) ) ? ( ( validID ) ) ( ( ( '+=' | '=' | '?=' ) ) ) ( ( assignableTerminal ) ) ) ;
assignableTerminal : ( keyword | ruleCall | parenthesizedAssignableElement | crossReference ) ;
parenthesizedAssignableElement : ( '(' assignableAlternatives ')' ) ;
assignableAlternatives : ( assignableTerminal ( ( ) ( '|' ( ( assignableTerminal ) ) ) + ) ? ) ;
crossReference : ( '[' ( ( typeRef ) ) ( '|' ( ( crossReferenceableTerminal ) ) ) ? ']' ) ;
crossReferenceableTerminal : ( keyword | ruleCall ) ;
parenthesizedElement : ( '(' alternatives ')' ) ;
predicatedGroup : ( ( ( ( '=>' ) ) | ( ( '->' ) ) ) '(' ( ( alternatives ) ) ')' ) ;
terminalRule : ( ( ( annotation ) ) * 'terminal' ( ( ( ( 'fragment' ) ) ( ( validID ) ) ) | ( ( ( validID ) ) ( 'returns' ( ( typeRef ) ) ) ? ) ) ':' ( ( terminalAlternatives ) ) ';' ) ;
terminalAlternatives : ( terminalGroup ( ( ) ( '|' ( ( terminalGroup ) ) ) + ) ? ) ;
terminalGroup : ( terminalToken ( ( ) ( ( terminalToken ) ) + ) ? ) ;
terminalToken : ( terminalTokenElement ( ( ( '?' | '*' | '+' ) ) ) ? ) ;
terminalTokenElement : ( characterRange | terminalRuleCall | parenthesizedTerminalElement | abstractNegatedToken | wildcard | eOF ) ;
parenthesizedTerminalElement : ( '(' terminalAlternatives ')' ) ;
abstractNegatedToken : ( negatedToken | untilToken ) ;
negatedToken : ( '!' ( ( terminalTokenElement ) ) ) ;
untilToken : '->' terminalTokenElement ;
wildcard : '.' ;
eOF : 'EOF' ;
characterRange : ( keyword ( ( ) '..' ( ( keyword ) ) ) ? ) ;
enumRule : ( ( ( annotation ) ) * 'enum' ( ( validID ) ) ( 'returns' ( ( typeRef ) ) ) ? ':' ( ( enumLiterals ) ) ';' ) ;
enumLiterals : ( enumLiteralDeclaration ( ( ) ( '|' ( ( enumLiteralDeclaration ) ) ) + ) ? ) ;
enumLiteralDeclaration : ( ( ( validID ) ) ( '=' ( ( keyword ) ) ) ? ) ;
RULE_ID : '^' ? ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' ) * ;
RULE_INT : ( '0' .. '9' ) + ;
RULE_STRING : ( '"' ( '\\' . | ~ ( '\\' | '"' ) ) * '"' | '\'' ( '\\' . | ~ ( '\\' | '\'' ) ) * '\'' ) ;
RULE_ML_COMMENT : '/*' ( . ) * ? '*/' -> channel(HIDDEN) ;
RULE_SL_COMMENT : '//' ~ ( '\n' | '\r' ) * ( '\r' ? '\n' ) ? -> channel(HIDDEN) ;
RULE_WS : ( ' ' | '\t' | '\r' | '\n' ) + -> channel(HIDDEN) ;
RULE_ANY_OTHER : . ; 
