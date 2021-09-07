parser grammar rexParser;

options { tokenVocab = rexLexer; }

grammar_  : prolog syntaxDefinition lexicalDefinition? encore? EOF ;
prolog   : processingInstruction* ;
processingInstruction : '<?' Name ( Space+ DirPIContents? )? '?>'
          /* ws: explicit */
	  ;
syntaxDefinition : syntaxProduction+ ;
syntaxProduction : Name '::=' syntaxChoice option* ;
syntaxChoice : syntaxSequence ( ( '|' syntaxSequence )+ | ( '/' syntaxSequence )+ )? ;
syntaxSequence : syntaxItem* ;
syntaxItem : syntaxPrimary ( '?' | '*' | '+' )? ;
syntaxPrimary : nameOrString | '(' syntaxChoice ')' | processingInstruction ;
lexicalDefinition : '<?TOKENS?>' ( lexicalProduction | preference | delimiter | equivalence )* ;
lexicalProduction : ( Name | '.' ) '?'? '::=' contextChoice option* ;
contextChoice : contextExpression ( '|' contextExpression )* ;
lexicalChoice : lexicalSequence ( '|' lexicalSequence )* ;
contextExpression : lexicalSequence ( '&' lexicalItem )? ;
lexicalSequence : | lexicalItem ( '-' lexicalItem | lexicalItem* ) ;
lexicalItem : lexicalPrimary ( '?' | '*' | '+' )? ;
lexicalPrimary : ( Name | '.' ) | StringLiteral | '(' lexicalChoice ')' | '$' | CharCode | charClass ;
nameOrString : Name context? | StringLiteral context? ;
context  : CaretName ;
charClass : ( '[' | '[^' ) ( Char | CharCode | CharRange | CharCodeRange )+ ']'
          /* ws: explicit */
	  ;
option : '/*' Space* 'ws' ':' Space* ( 'explicit' | 'definition' ) Space* '*/'
          /* ws: explicit */
	  ;
preference : nameOrString ( '>>' nameOrString+ | '<<' nameOrString+ ) ;
delimiter : Name '\\' nameOrString+ ;
equivalence : EquivalenceLookAhead equivalenceCharRange '==' equivalenceCharRange ;
equivalenceCharRange : StringLiteral | '[' ( Char | CharCode | CharRange | CharCodeRange ) ']'
          /* ws: explicit */
	  ;
encore : '<?ENCORE?>' processingInstruction* ;

