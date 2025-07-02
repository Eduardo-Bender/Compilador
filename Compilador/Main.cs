using Antlr4.Runtime;
using Compilador;
using System;

Console.WriteLine("Digite o número do teste (1-5) ou 'T' para rodar todos:");
string? opcao = Console.ReadLine();

List<string> arquivos = new List<string>
{
    ".\\tests\\test1.fortall",
    ".\\tests\\test2.fortall",
    ".\\tests\\test3.fortall",
    ".\\tests\\test4.fortall",
    ".\\tests\\test5.fortall"
};

void RodarTeste(string filename)
{
    try
    {
        var fileContents = File.ReadAllText(filename);
        var inputStream = new AntlrInputStream(fileContents);
        var fortallLexer = new FortallLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(fortallLexer);
        var fortallParser = new FortallParser(commonTokenStream);
        var programContext = fortallParser.program();
        var visitor = new BasicFortallVisitor();
        visitor.Visit(programContext);
        Console.WriteLine($"[OK] {filename}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERRO] {filename}: {ex.Message}");
    }
}

if (opcao?.ToUpper() == "T")
{
    foreach (var arquivo in arquivos)
    {
        RodarTeste(arquivo);
    }
}
else if (int.TryParse(opcao, out int index) && index >= 1 && index <= arquivos.Count)
{
    RodarTeste(arquivos[index - 1]);
}
else
{
    Console.WriteLine("Opção inválida.");
}