grammar Fortall;

program             : line* EOF ;
line                : statement | whileBlock | ifBlock | print | input;
statement           : assignment ';';

print               : 'print' '(' expression ')' ';' ;
input               : 'input' '(' ID ')' ';';
ifBlock             : 'if' expression block ('else' elseIfBlock)*;
elseIfBlock         : block | ifBlock;
whileBlock          : 'while' expression block ;
assignment          : ID '=' expression ;

expression          : constant                          #constantExpression
                    | ID                                #identifierExpression
                    | '(' expression ')'                #parenthesizedExpression
                    | '!' expression                    #negationExpression
                    | expression multOp expression      #multiplicativeExpression
                    | expression addOp expression       #additiveExpression
                    | expression compOp expression      #comparisonExpression
                    | expression boolOp expression      #booleanExpression
                    ;

multOp              : '*' | '/' | '%' ;
addOp               : '+' | '-' ;
compOp              : '==' | '!=' | '<' | '>' | '<=' | '>=' ;
boolOp              : BOOL_OPERATOR;

BOOL_OPERATOR       : 'and' | 'or' | '&&' | '||' ;

constant            : INTEGER
                    | FLOAT
                    | STRING
                    | BOOL
                    | NULL
                    ;

INTEGER             : [0-9]+ ;
FLOAT               : [0-9]+ '.' [0-9]+ ;
STRING              : ('"' ~'"'* '"') | ('\'' ~'\''* '\'') ;
BOOL                : 'true' | 'false' ;
NULL                : 'null' ;

block               : '{' line* '}' ;

ID                  : [a-zA-Z_][a-zA-Z0-9_]* ;
WHITESPACE          : [ \t\r\n]+ -> skip ;  