using Antlr4.Runtime;
using Compilador;

var filename = ".\\tests\\test1.fortall";

var fileContents = File.ReadAllText(filename);

AntlrInputStream inputStream = new AntlrInputStream(fileContents);

var fortallLexer = new FortallLexer(inputStream);
var commonTokenStream = new CommonTokenStream(fortallLexer);
var fortallParser = new FortallParser(commonTokenStream);
var programContext = fortallParser.program();
var visitor = new BasicFortallVisitor();        
visitor.Visit(programContext);