grammar fortall;

programa: 'programa' ID ';' declaracao* funcaoPrincipal funcao* EOF;

funcaoPrincipal: 'retorna' 'nada' 'funcao' 'principal' '(' ')' bloco;

funcao: declaracaoFunc;

declaracao: declaracaoVar | declaracaoFunc

declaracaoVar: tipo ID ('=' expressao)? ';';

declaracaoFunc: 'retorna' (tipo | 'nada') 'funcao' ID '(' parametros? ')' bloco;

parametros: tipo ID (',' tipo ID)*;

tipo: 'int' | 'bool';

bloco: '{' comando* '}';

comando: 
    declaracaoVar |
    atribuicao |
    chamadaFunc ';' |
    comandoSe |
    comandoEnquanto |
    comandoEscreve |
    comandoLe |
    comandoRetorna |
    bloco;

